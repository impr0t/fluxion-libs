
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.UIManager UIManager;
	private global::Gtk.Action FileAction;
	private global::Gtk.Action OpenAction;
	private global::Gtk.Action ExitAction;
	private global::Gtk.Action SettingsAction;
	private global::Gtk.Action AboutAction;
	private global::Gtk.Action ViewAction;
	private global::Gtk.VBox vbox1;
	private global::Gtk.MenuBar menubar2;
	private global::Gtk.HBox hbox1;
	private global::Gtk.Entry txtSearch;
	private global::Gtk.Button btnSearch;
	private global::Gtk.ScrolledWindow GtkScrolledWindow;
	private global::Gtk.TextView txtLog;
	private global::Gtk.Statusbar statusbar2;
	private global::Gtk.Label lblEntriesCount;

	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget MainWindow
		this.UIManager = new global::Gtk.UIManager ();
		global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup ("Default");
		this.FileAction = new global::Gtk.Action ("FileAction", global::Mono.Unix.Catalog.GetString ("File"), null, null);
		this.FileAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("File");
		w1.Add (this.FileAction, null);
		this.OpenAction = new global::Gtk.Action ("OpenAction", global::Mono.Unix.Catalog.GetString ("Open"), global::Mono.Unix.Catalog.GetString ("Open a log file or database"), null);
		this.OpenAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Open");
		w1.Add (this.OpenAction, "<Primary><Mod2>o");
		this.ExitAction = new global::Gtk.Action ("ExitAction", global::Mono.Unix.Catalog.GetString ("Exit"), null, null);
		this.ExitAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Exit");
		w1.Add (this.ExitAction, "<Primary><Mod2>x");
		this.SettingsAction = new global::Gtk.Action ("SettingsAction", global::Mono.Unix.Catalog.GetString ("Settings"), null, null);
		this.SettingsAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Settings");
		w1.Add (this.SettingsAction, null);
		this.AboutAction = new global::Gtk.Action ("AboutAction", global::Mono.Unix.Catalog.GetString ("About"), null, null);
		this.AboutAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("About");
		w1.Add (this.AboutAction, null);
		this.ViewAction = new global::Gtk.Action ("ViewAction", global::Mono.Unix.Catalog.GetString ("View"), null, null);
		this.ViewAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("View");
		w1.Add (this.ViewAction, null);
		this.UIManager.InsertActionGroup (w1, 0);
		this.AddAccelGroup (this.UIManager.AccelGroup);
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString ("Log View");
		this.Icon = global::Stetic.IconLoader.LoadIcon (this, "gtk-file", global::Gtk.IconSize.Menu);
		this.WindowPosition = ((global::Gtk.WindowPosition)(3));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vbox1 = new global::Gtk.VBox ();
		this.vbox1.Name = "vbox1";
		this.vbox1.Spacing = 6;
		// Container child vbox1.Gtk.Box+BoxChild
		this.UIManager.AddUiFromString ("<ui><menubar name='menubar2'><menu name='FileAction' action='FileAction'><menuitem name='OpenAction' action='OpenAction'/><menuitem name='ExitAction' action='ExitAction'/></menu><menu name='SettingsAction' action='SettingsAction'><menuitem name='ViewAction' action='ViewAction'/></menu><menu name='AboutAction' action='AboutAction'/></menubar></ui>");
		this.menubar2 = ((global::Gtk.MenuBar)(this.UIManager.GetWidget ("/menubar2")));
		this.menubar2.Name = "menubar2";
		this.vbox1.Add (this.menubar2);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.menubar2]));
		w2.Position = 0;
		w2.Expand = false;
		w2.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.hbox1 = new global::Gtk.HBox ();
		this.hbox1.Name = "hbox1";
		this.hbox1.Spacing = 6;
		// Container child hbox1.Gtk.Box+BoxChild
		this.txtSearch = new global::Gtk.Entry ();
		this.txtSearch.CanFocus = true;
		this.txtSearch.Name = "txtSearch";
		this.txtSearch.IsEditable = true;
		this.txtSearch.InvisibleChar = '•';
		this.hbox1.Add (this.txtSearch);
		global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.txtSearch]));
		w3.Position = 0;
		// Container child hbox1.Gtk.Box+BoxChild
		this.btnSearch = new global::Gtk.Button ();
		this.btnSearch.CanFocus = true;
		this.btnSearch.Name = "btnSearch";
		this.btnSearch.UseStock = true;
		this.btnSearch.UseUnderline = true;
		this.btnSearch.Label = "gtk-find";
		this.hbox1.Add (this.btnSearch);
		global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.btnSearch]));
		w4.Position = 1;
		w4.Expand = false;
		w4.Fill = false;
		this.vbox1.Add (this.hbox1);
		global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox1]));
		w5.Position = 1;
		w5.Expand = false;
		w5.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
		this.GtkScrolledWindow.Name = "GtkScrolledWindow";
		this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
		this.txtLog = new global::Gtk.TextView ();
		this.txtLog.CanFocus = true;
		this.txtLog.Name = "txtLog";
		this.txtLog.Editable = false;
		this.GtkScrolledWindow.Add (this.txtLog);
		this.vbox1.Add (this.GtkScrolledWindow);
		global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.GtkScrolledWindow]));
		w7.Position = 2;
		// Container child vbox1.Gtk.Box+BoxChild
		this.statusbar2 = new global::Gtk.Statusbar ();
		this.statusbar2.Name = "statusbar2";
		this.statusbar2.Spacing = 6;
		// Container child statusbar2.Gtk.Box+BoxChild
		this.lblEntriesCount = new global::Gtk.Label ();
		this.lblEntriesCount.Name = "lblEntriesCount";
		this.lblEntriesCount.LabelProp = global::Mono.Unix.Catalog.GetString ("25 Entries");
		this.statusbar2.Add (this.lblEntriesCount);
		global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.statusbar2 [this.lblEntriesCount]));
		w8.Position = 1;
		w8.Expand = false;
		w8.Fill = false;
		this.vbox1.Add (this.statusbar2);
		global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.statusbar2]));
		w9.Position = 3;
		w9.Expand = false;
		w9.Fill = false;
		this.Add (this.vbox1);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.DefaultWidth = 987;
		this.DefaultHeight = 744;
		this.Show ();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
		this.OpenAction.Activated += new global::System.EventHandler (this.OnOpenActionActivated);
		this.ExitAction.Activated += new global::System.EventHandler (this.OnExitActionActivated);
		this.ViewAction.Activated += new global::System.EventHandler (this.OnViewActionActivated);
	}
}
