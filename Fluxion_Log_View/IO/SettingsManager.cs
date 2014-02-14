using System;
using Ca.Fluxion.Managers.Data.Models;
using Ca.Fluxion.Managers.Data;
using Ca.Fluxion.Transports.Data;

namespace Ca.Fluxion.LogView.IO
{
	/// <summary>
	/// Settings manager.
	/// </summary>
	public class SettingsManager : BaseManager<LogViewSetting>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Ca.Fluxion.LogView.IO.SettingsManager"/> class.
		/// </summary>
		/// <param name="connectionType">Connection type.</param>
		/// <param name="path">Path.</param>
		public SettingsManager (ConnectionType connectionType, string path) : base (connectionType, path)
		{
			if (dataBus.Ready) {
				if (dataBus is SqliteDataBus) {
				}
			}
		}
	}
}

