using NUnit.Framework;
using Ca.Fluxion.Transports.Data;
using System.IO;
using System;

namespace FluxionLibrariesTests
{
	[TestFixture ()]
	public class FluxionDataBusTest
	{
		SqliteDataBus dataBus;

		[OneTimeSetUp ()]
		public void TestDataBusContructor ()
		{
			dataBus = new SqliteDataBus (Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments), "test.db"), true);
			Assert.IsNotNull (dataBus);
		}

		[Test ()]
		public void TestDataBusOpen ()
		{
			dataBus.Open ();
			Assert.IsTrue (dataBus.Ready, "Connection failed to open, connection is not ready.");
			dataBus.Close ();
		}

		[Test ()]
		public void TestDataBusNonQuery ()
		{
			string[] commands = new [] {
				"CREATE TABLE [items] (Key ntext, Value ntext);",
				"INSERT INTO [items] ([Key], [Value]) VALUES ('sample', 'text');"
			};

			var result = dataBus.ExecuteNonQuery (commands);

			Assert.AreEqual (0, result);
		}
	}
}

