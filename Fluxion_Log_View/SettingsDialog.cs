using System;
using Ca.Fluxion.LogView.IO;
using System.Collections.Generic;

namespace Ca.Fluxion.LogView
{
	public partial class SettingsDialog : Gtk.Dialog
	{
		/// <summary>
		/// Passed in instance of the settings manager.
		/// </summary>
		private SettingsManager settingsManager;
		/// <summary>
		/// The sections.
		/// </summary>
		private Dictionary<int, string> sections;

		/// <summary>
		/// Initializes a new instance of the <see cref="Ca.Fluxion.LogView.SettingsDialog"/> class.
		/// </summary>
		/// <param name="settingsManager">Settings manager.</param>
		public SettingsDialog (SettingsManager settingsManager)
		{
			this.Build ();
			this.settingsManager = settingsManager;
		}
	}
}

