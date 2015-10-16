using System;

namespace Ca.Fluxion.Patterns.ObjectPool
{
	public abstract class PoolableObject : IPoolable
	{
		private static object paramLock = new object ();
		private static int identity = 0;

		/// <summary>
		/// Gets an objects persistant identity.
		/// </summary>
		/// <value>The persistant identity.</value>
		public int PersistantIdentity {
			get;
			private set;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Ca.Fluxion.PoolableObject"/> class.
		/// </summary>
		public PoolableObject ()
		{
			lock (paramLock) {
				this.PersistantIdentity = identity++;
			}
		}
	}
}

