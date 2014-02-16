using Ca.Fluxion.Managers.Data.Models;
using System;

namespace Ca.Fluxion.Managers.Data
{
	/// <summary>
	/// Manager interface, all managers are to use this interface.
	/// </summary>
	public interface IManager<T>
	{

		#region Public Properties

		/// <summary>
		/// Gets or sets the state of the connection.
		/// </summary>
		/// <value>The state of the connection.</value>
		ConnectionState ConnectionState { get; set; }

		#endregion

	}
}

