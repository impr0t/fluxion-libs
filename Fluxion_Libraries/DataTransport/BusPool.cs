using System;
using Ca.Fluxion.Patterns.ObjectPool;

namespace Ca.Fluxion.Transports.Data
{
	/// <summary>
	/// Pool holding databus objects.
	/// </summary>
	public class BusPool : Pool<IDataBus>
	{
		/// <summary>
		/// Cleanup a databus in the pool.
		/// </summary>
		/// <param name="obj">Object.</param>
		protected override void Sweep (IDataBus obj)
		{
			obj.Close ();
		}
	}
}

