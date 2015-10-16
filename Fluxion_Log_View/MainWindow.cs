using System;
using System.IO;
using Gtk;
using Ca.Fluxion.LogView;
using Ca.Fluxion.LogView.IO;
using Ca.Fluxion.LogView.Utility;
using Ca.Fluxion.Managers.Data.Models;

public partial class MainWindow: Gtk.Window
{
	private SettingsManager settingsManager;

	/// <summary>
	/// Initializes a new instance of the <see cref="MainWindow"/> class.
	/// </summary>
	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();
		settingsManager = new SettingsManager (ConnectionType.Sqlite, "settings");
	}

	/// <summary>
	/// Raises the delete event event.
	/// </summary>
	/// <param name="sender">Sender.</param>
	/// <param name="a">The alpha component.</param>
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	/// <summary>
	/// Raises the open action activated event.
	/// </summary>
	/// <param name="sender">Sender.</param>
	/// <param name="e">E.</param>
	protected void OnOpenActionActivated (object sender, EventArgs e)
	{
		SetupTagTable ();

		FileChooserDialog fc = new FileChooserDialog ("Open a log file", this, 
			                       FileChooserAction.Open, "Cancel", ResponseType.Cancel, "Open", ResponseType.Accept);

		if (fc.Run () == (int)ResponseType.Accept) {
			try {
				txtLog.Buffer.Clear ();
				IOHandlers.ReadFile (fc.Filename, txtLog);	
				txtLog.ScrollToIter (txtLog.Buffer.EndIter, 0, false, 0, 0);
			} catch (IOException ex) {
				fc.Destroy ();
				DialogManager.Show (this, MessageType.Error, ex.Message);
			}
		}
		fc.Destroy ();

		RefreshStatistics ();
	}

	/// <summary>
	/// Raises the exit action activated event.
	/// </summary>
	/// <param name="sender">Sender.</param>
	/// <param name="e">E.</param>
	protected void OnExitActionActivated (object sender, EventArgs e)
	{
		if (DialogManager.Show (this, MessageType.Question, "Would you like to exit?") == ResponseType.Yes) {
			this.Destroy ();
		}
	}

	/// <summary>
	/// Setup the tag table used in the text view.
	/// This tag table will allow us to colorize
	/// and setup differentiation between the log lines.
	/// </summary>
	private void SetupTagTable ()
	{
		var tagTable = txtLog.Buffer.TagTable;

		TextTag bold = new TextTag ("bold");
		bold.Weight = Pango.Weight.Bold;
		tagTable.Add (bold);

		TextTag error = new TextTag ("error");
		error.Background = "Red";
		error.Foreground = "Black";
		tagTable.Add (error);

		TextTag general = new TextTag ("general");
		general.Foreground = "Black";
		tagTable.Add (general);

		TextTag debug = new TextTag ("debug");
		debug.Foreground = "Orange";
		tagTable.Add (debug);
	}

	/// <summary>
	/// Refreshes any document statistics.
	/// </summary>
	private void RefreshStatistics ()
	{
		lblEntriesCount.Text = "Entries: " + (txtLog.Buffer.LineCount - 1);
	}

	/// <summary>
	/// Raises the view action activated event.
	/// </summary>
	/// <param name="sender">Sender.</param>
	/// <param name="e">E.</param>
	protected void OnViewActionActivated (object sender, EventArgs e)
	{
		SettingsDialog sd = new SettingsDialog (settingsManager);
		if (sd.Run () == (int)Gtk.ResponseType.Ok) {
			//todo: reload settings.
		}
		sd.Destroy ();
	}
}