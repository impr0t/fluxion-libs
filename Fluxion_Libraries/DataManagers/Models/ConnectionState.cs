using System;

namespace Ca.Fluxion.Managers.Data.Models
{
	/// <summary>
	/// Represents the connection state of any manager.
	/// </summary>
	public enum ConnectionState
	{
		/// <summary>
		/// The connection is in a closed state.
		/// </summary>
		Closed = 0,
		/// <summary>
		/// The connection is is an open state.
		/// </summary>
		Open = 1,
		/// <summary>
		/// The connection is in an error state.
		/// </summary>
		Error = 2
	}
}

