using System.Data;
using Ca.Fluxion.Transports.Data;
using Ca.Fluxion.Logging.Models;

namespace Ca.Fluxion.Logging
{
	/// <summary>
	/// Responsible for the creation and usage of a logging database.
	/// </summary>
	public class XLogDB
	{

		#region Private Fields

		/// <summary>
		/// The data bus.
		/// </summary>
		private readonly SqliteDataBus dataBus;
		/// <summary>
		/// Indicates if XLog database has been initialized.
		/// </summary>
		private bool ready;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="Ca.Fluxion.Logging.XLogDB"/> class.
		/// </summary>
		/// <param name="path">Path.</param>
		/// <param name="createNew">If set to <c>true</c> create new.</param>
		public XLogDB (string path, bool createNew)
		{
			this.dataBus = new SqliteDataBus (path, createNew);
			this.ready = false;
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Initializes this instances database.
		/// </summary>
		public void Init ()
		{
			string[] initCommand = new [] {
				"CREATE TABLE IF NOT EXISTS [log] " +
				"(" +
				"ID INTEGER PRIMARY KEY," +
				"Timestamp DATETIME DEFAULT (datetime('now'))," +
				"Level INTEGER," +
				"Message TEXT" +
				");"
			};
			this.dataBus.ExecuteNonQuery (initCommand);
			this.ready = true;
		}

		/// <summary>
		/// Write the specified logLevel and message.
		/// </summary>
		/// <param name="logLevel">Log level.</param>
		/// <param name="message">Message.</param>
		public void Write (LogLevel logLevel, string message)
		{
			if (this.ready) {
				this.dataBus.ExecuteNonQuery (BuildDBMessage (logLevel, message));
			} else {
				throw new DataException ("Database not ready");
			}
		}

		#endregion

		#region Private Methods

		/// <summary>
		/// Builds the DB message.
		/// </summary>
		/// <returns>The DB message.</returns>
		/// <param name="logLevel">Log level.</param>
		/// <param name="message">Message.</param>
		private string[] BuildDBMessage (LogLevel logLevel, string message)
		{
			string[] commands = new [] {
				"INSERT INTO log (Level, Message) VALUES (" + (int)logLevel + ",'" + message + "');" 
			};
			return commands;
		}

		#endregion

	}
}

