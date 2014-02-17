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
		private Dictionary<int, List<LogViewSetting>> settingSnapshot;

		/// <summary>
		/// Initializes a new instance of the <see cref="Ca.Fluxion.LogView.IO.SettingsManager"/> class.
		/// </summary>
		/// <param name="connectionType">Connection type.</param>
		/// <param name="path">Path.</param>
		public SettingsManager (ConnectionType connectionType, string path) : base (connectionType, path)
		{
			settingSnapshot = new Dictionary<int, List<LogViewSetting>> ();
		}

		/// <summary>
		/// Queries the database and populates the current setting snapshot.
		/// </summary>
		/// <returns>The updated settings snapshot.</returns>
		public Dictionary<int, List<LogViewSetting>> GetSettings ()
		{
			if (dataBus is SqliteDataBus) {
				((SqliteDataBus)dataBus).ExecuteQuery ("SELECT * FROM logviewsetting;", CreateSnapshot);
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
		/// Creates the snapshot.
		/// </summary>
		/// <param name="reader">Reader.</param>
		private void CreateSnapshot (SqliteDataReader reader)
		{
			if (settingSnapshot == null) {
				settingSnapshot = new Dictionary<int, List<LogViewSetting>> ();
			}

			while (reader.Read ()) {
				var setting = new LogViewSetting (reader.GetInt32 (0), reader.GetInt32 (1), reader.GetString (2), reader.GetString (3));
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
			var pull = settingSnapshot [setting.SectionID].Find (a => a.SectionID == setting.SectionID && a.Identifier == setting.Identifier);
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
			return settingSnapshot [setting.SectionID].Find (a => a.SectionID == setting.SectionID && a.Identifier == setting.Identifier) == null;
		}
	}
}
