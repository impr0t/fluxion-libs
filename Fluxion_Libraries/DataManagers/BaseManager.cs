using System;
using System.Collections.Generic;
using System.IO;
using Ca.Fluxion.Managers.Data.Models;
using Ca.Fluxion.Transports.Data;

namespace Ca.Fluxion.Managers.Data
{
	/// <summary>
	/// Base manager class in which all other managers will inherit from.
	/// </summary>
	public abstract class BaseManager<T> : IManager<T>
	{
		/// <summary>
		/// Retained list of active connections to one datasource or another.
		/// </summary>
		static List<IDataBus> activeConnections;

		#region Private Fields

		/// <summary>
		/// Currently used databus.
		/// </summary>
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
			// ensure active connections are available.
			if (activeConnections == null) {
				activeConnections = new List<IDataBus> ();
			}

			switch (connectionType) {
			case ConnectionType.Sqlite:

				// ensure our path ends with .db.
				path = Path.ChangeExtension (path, ".db");

				// always try to piggy-back on a connection.
				foreach (var connection in activeConnections) {
					if (connection is SqliteDataBus) {
						if (((SqliteDataBus)connection).DbPath == path) {
							this.dataBus = connection;
							this.Init (typeof(T));
							break;
						}
					}
				}

				if (dataBus == null) {
					activeConnections.Add (dataBus = new SqliteDataBus (path, true));
					this.Init (typeof(T));
				}

				break;
			default:
				throw new ArgumentOutOfRangeException ();
			}
		}

		#endregion

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

		/// <summary>
		/// Initialize a database and / or table for the specified object.
		/// </summary>
		/// <param name="obj">Object.</param>
		private void Init (Type obj)
		{
			this.dataBus.Init (obj);
		}

		#endregion

	}
}

