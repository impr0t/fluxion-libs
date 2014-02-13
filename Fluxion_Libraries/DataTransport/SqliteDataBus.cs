using System;
using System.IO;
using Mono.Data.Sqlite;

namespace Ca.Fluxion.Transports.Data
{
	public class SqliteDataBus : IDataBus
	{
		/// <summary>
		/// The db path.
		/// </summary>
		readonly string dbPath;
		/// <summary>
		/// The connection.
		/// </summary>
		readonly SqliteConnection connection;

		/// <summary>
		/// Gets the connection.
		/// </summary>
		/// <value>The connection.</value>
		public SqliteConnection Connection {
			get {
				return connection;
			}
		}

		/// <summary>
		/// Gets the db path.
		/// </summary>
		/// <value>The db path.</value>
		public string DbPath {
			get {
				return dbPath;
			}
		}

		/// <summary>
		/// Gets a value indicating whether this <see cref="Ca.Fluxion.SqliteDataBus"/> is ready.
		/// </summary>
		/// <value><c>true</c> if ready; otherwise, <c>false</c>.</value>
		public bool Ready {
			get {
				return connection != null;
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Ca.Fluxion.SqliteDataBus"/> class.
		/// </summary>
		/// <param name="path">Path.</param>
		public SqliteDataBus (string path)
		{
			if (File.Exists (path)) {
				this.dbPath = path;
				this.connection = new SqliteConnection ("Data Source=" + path);
			} else {
				throw new FileNotFoundException ("Database file not found", "path");
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Ca.Fluxion.SqliteDataBus"/> class.
		/// </summary>
		/// <param name="path">Path.</param>
		/// <param name="createNew">If set to <c>true</c> create new.</param>
		public SqliteDataBus (string path, bool createNew)
		{
			if (!createNew) {
				if (File.Exists (path)) {
					this.dbPath = path;
					this.connection = new SqliteConnection ("Data Source=" + this.dbPath);
				}
			} else {
				if (File.Exists (path)) {
					File.Delete (path);
				}
				this.dbPath = path;
				SqliteConnection.CreateFile (this.dbPath);
				this.connection = new SqliteConnection ("Data Source=" + this.dbPath);
			}
		}

		/// <summary>
		/// Open this instance.
		/// </summary>
		public bool Open ()
		{
			if (connection != null && connection.State != System.Data.ConnectionState.Open) {
				connection.Open ();
				return true;
			} else if (connection != null && connection.State == System.Data.ConnectionState.Open) {
				return true;
			}
			return false;
		}

		/// <summary>
		/// Close this instance.
		/// </summary>
		public bool Close ()
		{
			if (connection != null && connection.State != System.Data.ConnectionState.Closed) {
				connection.Close ();
				return true;
			} else if (connection != null && connection.State == System.Data.ConnectionState.Closed) {
				return true;
			}
			return false;
		}

		/// <summary>
		/// Executes a NonQuery against the database.
		/// </summary>
		/// <returns>Integer value containing number of rows collected.</returns>
		/// <param name="commands">Commands.</param>
		public int ExecuteNonQuery (string[] commands)
		{
			if (Open ()) {
				foreach (var command in commands) {
					using (var c = connection.CreateCommand ()) {
						c.CommandText = command;
						return c.ExecuteNonQuery ();
					}
				}
				Close ();
			}
			throw new NullReferenceException ("Connection does not exist");
		}

		/// <summary>
		/// Executes a standard query against the database.
		/// callBack method is used for working with the response.
		/// </summary>
		/// <param name="query">Query.</param>
		/// <param name="callBack">Call back.</param>
		public void ExecuteQuery (string query, Action<SqliteDataReader> callBack)
		{
			if (Open ()) {
				using (var cmd = connection.CreateCommand ()) {
					cmd.CommandText = query;
					callBack (cmd.ExecuteReader ());
				}
				Close ();
			} else {
				throw new NullReferenceException ("Connection does not exist");
			}
		}
	}
}

