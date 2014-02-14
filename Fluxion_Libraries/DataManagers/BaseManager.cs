using System;
using System.Collections.Generic;
using System.Text;
using Ca.Fluxion.Managers.Data.Models;
using Ca.Fluxion.Transports.Data;

namespace Ca.Fluxion.Managers.Data
{
	/// <summary>
	/// Base manager class in which all other managers will inherit from.
	/// </summary>
	public abstract class BaseManager<T> : IManager<T>
	{
		static List<IDataBus> activeConnections;

		#region Private Fields

		protected IDataBus dataBus;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="Ca.Fluxion.Managers.Data.BaseManager"/> class.
		/// </summary>
		/// <param name="connectionType">Connection type.</param>
		/// <param name="path">Path.</param>
		protected BaseManager (ConnectionType connectionType, string path)
		{
			// ensure active connections is available.
			if (activeConnections == null) {
				activeConnections = new List<IDataBus> ();
			}

			switch (connectionType) {
			case ConnectionType.Sqlite:

				// always try to piggy-back on a connection.
				foreach (var connection in activeConnections) {
					if (connection is SqliteDataBus) {
						if (((SqliteDataBus)connection).DbPath == path) {
							this.dataBus = connection;
							break;
						}
					}
				}

				if (dataBus == null) {
					activeConnections.Add (dataBus = new SqliteDataBus (path, true));
				}

				break;
			default:
				throw new ArgumentOutOfRangeException ();
			}
		}

		#endregion

		/// <summary>
		/// Init this instance.
		/// </summary>
		protected virtual void Init ()
		{
			// intentionally blank.
			// can be overridden.
		}

		#region IManager implementation

		/// <summary>
		/// Gets or sets the state of the connection.
		/// </summary>
		/// <value>The state of the connection.</value>
		public ConnectionState ConnectionState {
			get {
				try {
					if (dataBus.Ready) {
						return ConnectionState.Open;
					} else {
						return ConnectionState.Closed;
					}
				} catch (Exception) {
					return ConnectionState.Error;
				}
			}
			set {
				ConnectionState = value;
			}
		}

		#endregion

	}
}

