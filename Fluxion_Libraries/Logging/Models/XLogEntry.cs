using System;
using Ca.Fluxion.Logging.Models;
using Ca.Fluxion.Shared;

namespace Ca.Fluxion
{
	/// <summary>
	/// Model representing an entry for the xlog component.
	/// </summary>
	public class XLogEntry
	{
		/// <summary>
		/// Gets or sets the log level.
		/// </summary>
		/// <value>The log level.</value>
		public LogLevel LogLevel {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the time stamp.
		/// </summary>
		/// <value>The time stamp.</value>
		public DateTime TimeStamp {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the message.
		/// </summary>
		/// <value>The message.</value>
		public string Message {
			get;
			set;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Ca.Fluxion.XLogEntry"/> class.
		/// </summary>
		public XLogEntry (LogLevel logLevel, DateTime timeStamp, string message)
		{
			this.LogLevel = logLevel;
			this.TimeStamp = timeStamp;
			this.Message = message;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Ca.Fluxion.XLogEntry"/> class.
		/// </summary>
		/// <param name="logLevel">Log level.</param>
		/// <param name="timeStamp">Time stamp.</param>
		/// <param name="message">Message.</param>
		public XLogEntry (LogLevel logLevel, string timeStamp, string message)
		{
			this.LogLevel = logLevel;
			this.TimeStamp = timeStamp.ToDateTime ("o");
			this.Message = message;
		}
	}
}

