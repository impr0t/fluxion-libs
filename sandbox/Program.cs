using System;
using Ca.Fluxion;

namespace sandbox
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			dbSandbox db = new dbSandbox ();
			db.Write ();
		}
	}
}
