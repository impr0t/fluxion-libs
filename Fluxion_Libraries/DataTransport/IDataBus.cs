using System;

namespace Ca.Fluxion.Transports.Data
{
	/// <summary>
	/// Interface for databus objects.
	/// </summary>
	public interface IDataBus
	{
		/// <summary>
		/// Open this instance.
		/// </summary>
		bool Open ();

		/// <summary>
		/// Close this instance.
		/// </summary>
		bool Close ();

		/// <summary>
		/// Gets a value indicating whether this <see cref="Ca.Fluxion.IDataBus"/> is ready.
		/// </summary>
		/// <value><c>true</c> if ready; otherwise, <c>false</c>.</value>
		bool Ready { get; }

		/// <summary>
		/// Initialize a database and / or table for a specified type of object.
		/// </summary>
		/// <param name="obj">Object.</param>
		void Init (Type obj);
	}
}

