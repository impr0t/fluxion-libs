using System;

namespace Ca.Fluxion.Transports.Data
{
	/// <summary>
	/// Initializer interface.
	/// </summary>
	public interface IInitializer
	{
		/// <summary>
		/// Validate the specified type.
		/// </summary>
		/// <param name="objType">Object type.</param>
		/// <param name="message">Message.</param>
		bool Validate (Type objType, out string message);

		/// <summary>
		/// Process the specified type.
		/// </summary>
		/// <param name="objType">Object type.</param>
		string[] Process (Type objType);
	}
}

