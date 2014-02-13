using System;
using System.IO;
using System.Text;
using Ca.Fluxion.Logging.Models;
using Ca.Fluxion.Shared;

namespace Ca.Fluxion.Logging
{
	/// <summary>
	/// Logging component.
	/// </summary>
	public class XLog : IDisposable
	{
		/// <summary>
		/// FileStream of current file.
		/// </summary>
		private FileStream currentFile;
		/// <summary>
		/// The database.
		/// </summary>
		private XLogDB database;

		/// <summary>
		/// Gets the current directory.
		/// </summary>
		/// <value>The current directory.</value>
		public string CurrentDirectory {
			get;
			private set;
		}

		/// <summary>
		/// Gets the name of the file.
		/// </summary>
		/// <value>The name of the file.</value>
		public string FileName {
			get;
			private set;
		}

		/// <summary>
		/// Gets or sets the log level.
		/// </summary>
		/// <value>The log level.</value>
		public LogLevel LogLevel {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the log destination.
		/// </summary>
		/// <value>The log destination.</value>
		public LogDestination LogDestination {
			get;
			set;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Ca.Fluxion.Xlog"/> class.
		/// </summary>
		public XLog ()
		{
			this.LogDestination = LogDestination.File;
			this.CurrentDirectory = Directory.GetCurrentDirectory ();
			this.FileName = "log.xlog";

			this.currentFile = new FileStream (
				Path.Combine (
					this.CurrentDirectory, this.FileName), 
				FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Ca.Fluxion.Xlog"/> class.
		/// Directory is the base directory to use for logging.
		/// Filename is the name of the file without the extension.
		/// If the Filename has an extension, it will be overwritten with '.xlog'.
		/// </summary>
		/// <param name="directory">Directory.</param>
		/// <param name="fileName">File name.</param>
		public XLog (string directory, string fileName)
		{
			this.LogDestination = LogDestination.File;
			if (!Directory.Exists (directory)) {
				Directory.CreateDirectory (directory);
			}

			string logFile = Path.Combine (directory, fileName);

			if (Path.GetExtension (logFile) != ".xlog") {
				logFile = Path.ChangeExtension (logFile, ".xlog");
			}

			this.CurrentDirectory = directory;
			this.FileName = fileName;

			this.currentFile = new FileStream (logFile, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Ca.Fluxion.Xlog"/> class.
		/// </summary>
		/// <param name="database">Database.</param>
		public XLog (XLogDB database)
		{
			this.LogDestination = LogDestination.DataBase;
			this.database = database;
		}

		/// <summary>
		/// Write the specified logLevel and message.
		/// </summary>
		/// <param name="logLevel">Log level.</param>
		/// <param name="message">Message.</param>
		public void Write (LogLevel logLevel, string message)
		{
			if (logLevel <= this.LogLevel) {
				if (this.LogDestination == LogDestination.File) {
					if (this.currentFile.CanWrite) {
						var length = 0;
						this.currentFile.Write (Encoding.ASCII.GetBytes (BuildMessage (logLevel, message, out length)), 0, length);
					}
				} else {
					if (this.database != null)
						this.database.Write (logLevel, message);
				}
			}
		}

		#region IDisposable implementation

		public void Dispose ()
		{
			this.currentFile.Close ();
			this.currentFile.Dispose ();
			this.currentFile = null;
		}

		#endregion

		/// <summary>
		/// Builds the message.
		/// </summary>
		/// <returns>The message.</returns>
		/// <param name="logLevel">Log level.</param>
		/// <param name="message">Message.</param>
		/// <param name="length">Length of message to be output.</param> 
		private string BuildMessage (LogLevel logLevel, string message, out int length)
		{
			StringBuilder sb = new StringBuilder ();
			sb.Append (((int)logLevel).ToString () + ",");
			sb.Append (DateTime.Now.ToLogDate ());
			sb.Append (AsciiConstants.UNITSEPARATOR);
			sb.Append (message);
			sb.Append (Environment.NewLine);

			length = sb.Length;

			return sb.ToString ();
		}
	}
}

