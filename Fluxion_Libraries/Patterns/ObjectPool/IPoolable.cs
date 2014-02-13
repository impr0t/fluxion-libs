using System;

namespace Ca.Fluxion.Patterns.ObjectPool
{
	public interface IPoolable
	{
		int PersistantIdentity{ get; }
	}
}

