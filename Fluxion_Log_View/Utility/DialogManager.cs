using System;
using Gtk;

namespace Ca.Fluxion.LogView.Utility
{
	/// <summary>
	/// Dialog manager class that acts as a wrapper 
	/// for existing GTK message dialog methods.
	/// Used to cut down on code needed in the UI.
	/// </summary>
	public static class DialogManager
	{
		/// <summary>
		/// Shows a message, message type determines button layout of message dialog.
		/// </summary>
		/// <param name="parent">Parent.</param>
		/// <param name="messageType">Message type.</param>
		/// <param name="message">Message.</param>
		public static ResponseType Show (Window parent, MessageType messageType, string message)
		{
			MessageDialog md;

			switch (messageType) {
			case MessageType.Info:
				md = new MessageDialog (parent, DialogFlags.Modal, messageType, ButtonsType.Ok, message);
				break;
			case MessageType.Warning:
			case MessageType.Question:
				md = new MessageDialog (parent, DialogFlags.Modal, messageType, ButtonsType.YesNo, message);
				break;
			case MessageType.Error:
				md = new MessageDialog (parent, DialogFlags.Modal, messageType, ButtonsType.Close, message);
				break;
			default:
				throw new ArgumentOutOfRangeException ();
			}

			var response = (ResponseType)md.Run ();
			md.Destroy ();

			return response;
		}
	}
}

