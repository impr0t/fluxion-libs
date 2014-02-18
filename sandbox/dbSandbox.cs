using System;
using Ca.Fluxion.Logging;
using Ca.Fluxion.Logging.Models;

namespace sandbox
{
	public class dbSandbox
	{
		XLog log;

		public dbSandbox ()
		{
			//log = new XLog (Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments), "test");
			XLogDB db = new XLogDB ("log", true);
			db.Init ();
			log = new XLog (db);
		}

		public void Write ()
		{
			log.LogLevel = LogLevel.All;
			log.Write (LogLevel.Debug, "this is a debug message.");
			log.Write (LogLevel.Error, "this is an error");
			log.Write (LogLevel.General, "this is a general message");
		}
	}
}

