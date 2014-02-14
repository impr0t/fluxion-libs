using System;
using System.IO;
using Ca.Fluxion.Shared;
using Ca.Fluxion.Managers;
using Gtk;

namespace Ca.Fluxion.LogView.IO
{
	public static class IOHandlers
	{
		/// <summary>
		/// Read a selected file.
		/// </summary>
		/// <param name="file">File.</param>
		public static void ReadFile (string file, TextView textView)
		{
			const string db = @".db";
			const string xlog = @".xlog";

			string extension = Path.GetExtension (file);

			if (string.CompareOrdinal (extension, db) == 0) {
				ReadDb (file, textView);
			} else if (string.CompareOrdinal (extension, xlog) == 0) {
				ReadXlog (file, textView);
			} else {
				throw new IOException ("File format not supported, cannot open file.");
			}
		}

		/// <summary>
		/// Reads the db.
		/// </summary>
		/// <param name="file">File.</param>
		private static void ReadDb (string file, TextView textView)
		{

		}

		/// <summary>
		/// Reads the xlog.
		/// </summary>
		/// <param name="file">File.</param>
		private static void ReadXlog (string file, TextView textView)
		{
			using (var fs = new FileStream (file, FileMode.Open)) {
				using (StreamReader sr = new StreamReader (fs)) {
					while (sr.Peek () > -1) {
						ProcessLine (sr.ReadLine (), textView);
					}
				}
			}
		}

		/// <summary>
		/// Processes the line.
		/// </summary>
		/// <param name="text">Text.</param>
		/// <param name="textView">Text view.</param>
		private static void ProcessLine (string text, TextView textView)
		{
			// extract line parts.
			string metaData = string.Empty;
			string data = string.Empty;
			GetLineParts (text, out metaData, out data);

			// extract meta data.
			string lineType = string.Empty;
			string timeStamp = string.Empty;
			GetMetaData (metaData, out lineType, out timeStamp);

			string restructuredLine = RestructureLine (timeStamp, data);

			// extract our buffer.
			var textbuffer = textView.Buffer;

			// push text to buffer, last line, with tags.
			TextIter iter = textbuffer.EndIter;
			textbuffer.InsertWithTagsByName (ref iter, restructuredLine, lineType);
		}

		/// <summary>
		/// Gets the individual pieces of the metadata.
		/// </summary>
		/// <param name="metaData">Meta data.</param>
		/// <param name="lineType">Line type.</param>
		/// <param name="timeStamp">Time stamp.</param>
		private static void GetMetaData (string metaData, out string lineType, out string timeStamp)
		{
			string[] metaDataParts = metaData.Split (',');
			if (metaDataParts.Length > 1) {

				int lt = 0;
				int.TryParse (metaDataParts [0], out lt);
				lineType = ResolveTag (lt);

				timeStamp = metaDataParts [1].ToDateTime ("o").ToString ("yy-MMM-dd ddd HH:mm:ss:ffff").PadRight (40);
			} else {
				lineType = ResolveTag (0);
				timeStamp = string.Empty;
			}
		}

		/// <summary>
		/// Resolves the tag.
		/// </summary>
		/// <returns>The tag.</returns>
		/// <param name="lineType">Line type.</param>
		private static string ResolveTag (int lineType)
		{
			switch (lineType) {
			case -1:
				return "error";
			case 0:
				return "general";
			case 1:
				return "debug";
			default:
				return "general";
			}
		}

		/// <summary>
		/// Gets the line parts.
		/// </summary>
		/// <param name="text">Text.</param>
		/// <param name="metaData">Meta data.</param>
		/// <param name="data">Data.</param>
		private static void GetLineParts (string text, out string metaData, out string data)
		{
			// Get the primary sections of the line. 0th element is the metadata for the entry.
			// 1st element is the actual data of the entry.
			string[] lineParts = text.Split (AsciiConstants.UNITSEPARATOR);
			if (lineParts.Length > 1) {
				metaData = lineParts [0];
				data = lineParts [1];
			} else {
				metaData = string.Empty;
				data = string.Empty;
			}
		}

		/// <summary>
		/// Restructures the line so it's more readable to humans.
		/// </summary>
		/// <returns>The line.</returns>
		/// <param name="timeStamp">Time stamp.</param>
		/// <param name="message">Message.</param>
		private static string RestructureLine (string timeStamp, string message)
		{
			string result = timeStamp + " " + message;
			if (!result.EndsWith (Environment.NewLine)) {
				result += Environment.NewLine;
			}
			return result;
		}
	}
}

