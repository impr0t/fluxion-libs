using System;
using System.Collections.Generic;

namespace Ca.Fluxion.Patterns.ObjectPool
{
	public abstract class Pool<T> where T : PoolableObject, new()
	{
		private List<T> available = new List<T> ();
		private List<T> inUse = new List<T> ();

		/// <summary>
		/// Get a specified object.
		/// </summary>
		public T Get ()
		{
			lock (available) {
				if (available.Count != 0) {
					T obj = available [0];
					inUse.Add (obj);
					available.RemoveAt (0);
					return obj;
				} else {
					T obj = new T ();
					inUse.Add (obj);
					return obj;
				}
			}
		}

		/// <summary>
		/// Release the specified obj.
		/// </summary>
		/// <param name="obj">Object.</param>
		public void Release (T obj)
		{
			Sweep (obj);

			lock (available) {
				available.Add (obj);
				inUse.Remove (obj);
			}
		}

		/// <summary>
		/// Sweep the specified obj.
		/// </summary>
		/// <param name="obj">Object.</param>
		protected virtual void Sweep (T obj)
		{
			//Intentionally blank, used for concrete implementation cleanup.
		}
	}
}

