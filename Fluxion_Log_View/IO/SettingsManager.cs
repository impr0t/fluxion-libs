using System;
using Ca.Fluxion.Managers.Data.Models;
using Ca.Fluxion.Managers.Data;
using Ca.Fluxion.Transports.Data;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace Ca.Fluxion.LogView.IO
{
	/// <summary>
	/// Settings manager.
	/// </summary>
	public class SettingsManager : BaseManager<LogViewSetting>
	{
		/// <summary>
		/// The insert format.
		/// </summary>
		private const string InsertFormat = "INSERT INTO logviewsetting VALUES (\"{0}\", \"{1}\", \"{2}\", \"{3}\");";
		/// <summary>
		/// The default settings.
		/// </summary>
		private string[] initialSettingsStatements;
		/// <summary>
		/// Private store for our settings snapshot, where key is section, and value is 
		/// settings under that section.
		/// </summary>
		private Dictionary<int, List<LogViewSetting>> settingSnapshot;

		/// <summary>
		/// Initializes a new instance of the <see cref="Ca.Fluxion.LogView.IO.SettingsManager"/> class.
		/// </summary>
		/// <param name="connectionType">Connection type.</param>
		/// <param name="path">Path.</param>
		public SettingsManager (ConnectionType connectionType, string path) : base (connectionType, path)
		{
			settingSnapshot = new Dictionary<int, List<LogViewSetting>> ();

			initialSettingsStatements = new string[] { 
				string.Format (InsertFormat, 0, 0, "Error Foreground Color", "Black"),
				string.Format (InsertFormat, 0, 1, "Debug Foreground Color", "Orange"),
				string.Format (InsertFormat, 0, 2, "General Foreground Color", "Black"),
				string.Format (InsertFormat, 0, 3, "Error Background Color", "Red"),
				string.Format (InsertFormat, 0, 4, "Debug Background Color", "White"),
				string.Format (InsertFormat, 0, 5, "General Background Color", "White"),
			};
		}

		/// <summary>
		/// Gets the settings.
		/// </summary>
		/// <returns>The settings.</returns>
		/// <param name="refresh">If set to <c>true</c> refresh.</param>
		public Dictionary<int, List<LogViewSetting>> GetSettings (bool refresh)
		{
			if (refresh) {
				if (dataBus is SqliteDataBus) {
					((SqliteDataBus)dataBus).ExecuteQuery ("SELECT * FROM logviewsetting;", CreateSnapshot);
				}
			}

			// populate our table if no settings exist.
			if (settingSnapshot.Count == 0) {
				InitializeSettings ();
			}

			return settingSnapshot;
		}

		/// <summary>
		/// Gets a specified setting based on it's section id and secondary unique identifier.
		/// The current setting snapshot is then updated.
		/// </summary>
		/// <returns>Setting found during query.</returns>
		/// <param name="section">Section idenfitier.</param>
		/// <param name="id">Secondary unique identifier.</param>
		public KeyValuePair<int, LogViewSetting> GetSetting (int section, int id)
		{
			return new KeyValuePair<int, LogViewSetting> (0, null);
		}

		/// <summary>
		/// Intializes the settings.
		/// </summary>
		public void InitializeSettings ()
		{
			if (dataBus is SqliteDataBus) {
				((SqliteDataBus)dataBus).ExecuteNonQuery (initialSettingsStatements);
			}
		}

		/// <summary>
		/// Creates the snapshot.
		/// </summary>
		/// <param name="reader">Reader.</param>
		private void CreateSnapshot (SqliteDataReader reader)
		{
			if (settingSnapshot == null) {
				settingSnapshot = new Dictionary<int, List<LogViewSetting>> ();
			}

			while (reader.Read ()) {

				// create a new settings object.
				var setting = new LogViewSetting (reader.GetInt32 (0), 
					              reader.GetInt32 (1), 
					              reader.GetString (2), 
					              reader.GetString (3));

				this.AddSetting (setting);
			}
		}

		/// <summary>
		/// Adds the setting.
		/// </summary>
		/// <param name="setting">Setting.</param>
		private void AddSetting (LogViewSetting setting)
		{
			if (settingSnapshot.ContainsKey (setting.SectionID)) {
				if (this.CanAddSetting (setting)) {
					settingSnapshot [setting.SectionID].Add (setting);
				} else {
					this.ModifySetting (setting);
				}
			} else {
				settingSnapshot.Add (setting.SectionID, new List<LogViewSetting> ());
				settingSnapshot [setting.SectionID].Add (setting);
			}
		}

		/// <summary>
		/// Modifies the setting.
		/// </summary>
		/// <param name="setting">Setting.</param>
		private void ModifySetting (LogViewSetting setting)
		{
			var pull = FindSetting (setting.SectionID, setting.Identifier);
			if (pull != null) {
				pull.Description = setting.Description;
				pull.Value = setting.Value;
			}
		}

		/// <summary>
		/// Determines whether this instance can add setting the specified setting.
		/// </summary>
		/// <returns><c>true</c> if this instance can add setting the specified setting; otherwise, <c>false</c>.</returns>
		/// <param name="setting">Setting.</param>
		private bool CanAddSetting (LogViewSetting setting)
		{
			return FindSetting (setting.SectionID, setting.Identifier) == null;
		}

		/// <summary>
		/// Finds a specific setting inside of the setting snapshot.
		/// </summary>
		/// <returns>The setting.</returns>
		/// <param name="sectionID">Section identifier.</param>
		/// <param name="id">Secondary Identifier.</param>
		private LogViewSetting FindSetting (int sectionID, int id)
		{
			return settingSnapshot [sectionID].Find (a => a.SectionID == sectionID && a.Identifier == id);
		}
	}
}
