using System;
using Ca.Fluxion.Patterns.ObjectPool;

namespace sandbox
{
	public class designPatternSandbox
	{
		public designPatternSandbox ()
		{
			SampleItemPool pool = new SampleItemPool ();
			var item = pool.Get ();
			var item2 = pool.Get ();

			Console.WriteLine (item.DoSomething ());
			Console.WriteLine (item2.DoSomething ());

			pool.Release (item);
			pool.Release (item2);

			item = pool.Get ();
			Console.WriteLine (item.DoSomething ());
			pool.Release (item);
			item2 = pool.Get ();
			Console.WriteLine (item.DoSomething ());
			pool.Release (item2);
		}
	}

	public class SampleItem : PoolableObject
	{
		public string DoSomething ()
		{
			return this.PersistantIdentity.ToString ();
		}
	}

	/// <summary>
	/// Sample item pool.
	/// </summary>
	public class SampleItemPool : Pool<SampleItem>
	{
		protected override void Sweep (SampleItem obj)
		{
			obj = null;
		}
	}
}

