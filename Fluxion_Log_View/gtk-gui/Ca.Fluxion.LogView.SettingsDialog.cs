
// This file has been generated by the GUI designer. Do not modify.
namespace Ca.Fluxion.LogView
{
	public partial class SettingsDialog
	{
		private global::Gtk.VBox vbox2;
		private global::Gtk.ComboBox cmbSections;
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		private global::Gtk.NodeView nodeSettings;
		private global::Gtk.Button btnCancel;
		private global::Gtk.Button btnApply;
		private global::Gtk.Button btnOK;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget Ca.Fluxion.LogView.SettingsDialog
			this.Name = "Ca.Fluxion.LogView.SettingsDialog";
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Internal child Ca.Fluxion.LogView.SettingsDialog.VBox
			global::Gtk.VBox w1 = this.VBox;
			w1.Name = "dialog1_VBox";
			w1.BorderWidth = ((uint)(2));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.cmbSections = global::Gtk.ComboBox.NewText ();
			this.cmbSections.Name = "cmbSections";
			this.vbox2.Add (this.cmbSections);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.cmbSections]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.nodeSettings = new global::Gtk.NodeView ();
			this.nodeSettings.CanFocus = true;
			this.nodeSettings.Name = "nodeSettings";
			this.GtkScrolledWindow.Add (this.nodeSettings);
			this.vbox2.Add (this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.GtkScrolledWindow]));
			w4.Position = 1;
			w1.Add (this.vbox2);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(w1 [this.vbox2]));
			w5.Position = 0;
			// Internal child Ca.Fluxion.LogView.SettingsDialog.ActionArea
			global::Gtk.HButtonBox w6 = this.ActionArea;
			w6.Name = "dialog1_ActionArea";
			w6.Spacing = 10;
			w6.BorderWidth = ((uint)(5));
			w6.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.btnCancel = new global::Gtk.Button ();
			this.btnCancel.CanDefault = true;
			this.btnCancel.CanFocus = true;
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.UseStock = true;
			this.btnCancel.UseUnderline = true;
			this.btnCancel.Label = "gtk-cancel";
			this.AddActionWidget (this.btnCancel, -6);
			global::Gtk.ButtonBox.ButtonBoxChild w7 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w6 [this.btnCancel]));
			w7.Expand = false;
			w7.Fill = false;
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.btnApply = new global::Gtk.Button ();
			this.btnApply.CanDefault = true;
			this.btnApply.CanFocus = true;
			this.btnApply.Name = "btnApply";
			this.btnApply.UseStock = true;
			this.btnApply.UseUnderline = true;
			this.btnApply.Label = "gtk-apply";
			w6.Add (this.btnApply);
			global::Gtk.ButtonBox.ButtonBoxChild w8 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w6 [this.btnApply]));
			w8.Position = 1;
			w8.Expand = false;
			w8.Fill = false;
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.btnOK = new global::Gtk.Button ();
			this.btnOK.CanDefault = true;
			this.btnOK.CanFocus = true;
			this.btnOK.Name = "btnOK";
			this.btnOK.UseStock = true;
			this.btnOK.UseUnderline = true;
			this.btnOK.Label = "gtk-ok";
			this.AddActionWidget (this.btnOK, -5);
			global::Gtk.ButtonBox.ButtonBoxChild w9 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w6 [this.btnOK]));
			w9.Position = 2;
			w9.Expand = false;
			w9.Fill = false;
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 622;
			this.DefaultHeight = 599;
			this.Show ();
		}
	}
}
