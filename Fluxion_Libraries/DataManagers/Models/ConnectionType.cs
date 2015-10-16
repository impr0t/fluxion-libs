using System;

namespace Ca.Fluxion.Managers.Data.Models
{
	/// <summary>
	/// Representation of connection type for databus connections.
	/// Used in managers.
	/// </summary>
	public enum ConnectionType
	{
		/// <summary>
		/// Databus connection is of Xml.
		/// </summary>
		Xml = 0,
		/// <summary>
		/// Databus connection is of Sqlite.
		/// </summary>
		Sqlite = 1
	}
}

