using System;

namespace Ca.Fluxion.LogView
{
	public partial class SettingsWindow : Gtk.Dialog
	{
		public SettingsWindow () : 
			base (Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}
	}
}

