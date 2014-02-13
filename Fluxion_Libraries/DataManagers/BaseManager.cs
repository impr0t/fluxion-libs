using System;
using Ca.Fluxion.Transports.Data;
using Ca.Fluxion.Managers.Data.Models;

namespace Ca.Fluxion.Managers.Data
{
	/// <summary>
	/// Base manager class in which all other managers will inherit from.
	/// </summary>
	public abstract class BaseManager<T> : IManager<T>
	{

		#region Private Fields

		/// <summary>
		/// Databus interface.
		/// </summary>
		private readonly IDataBus dataBus;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="Ca.Fluxion.Managers.Data.BaseManager"/> class.
		/// </summary>
		/// <param name="connectionType">Connection type.</param>
		/// <param name="path">Path.</param>
		protected BaseManager (ConnectionType connectionType, string path)
		{
			switch (connectionType) {
			case ConnectionType.Sqlite:
				dataBus = new SqliteDataBus (path);
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

		#endregion

	}
}

