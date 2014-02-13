using NUnit.Framework;
using Ca.Fluxion.Logging;
using Ca.Fluxion.Logging.Models;

namespace FluxionLibrariesTests
{
	[TestFixture ()]
	public class FluxionLoggingTest
	{
		private XLog log;

		[TestFixtureSetUp ()]
		public void TestLogConstructor ()
		{
			log = new XLog ();
			Assert.AreEqual (log.FileName, "log.xlog");
		}

		[Test ()]
		public void TestLogWrite ()
		{
			log.Write (LogLevel.Error, "THIS IS ERROR");
			log.Write (LogLevel.General, "THIS IS GENERAL");
		}
	}
}

