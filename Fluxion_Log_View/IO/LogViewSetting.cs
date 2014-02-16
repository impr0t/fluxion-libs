using System;
using Ca.Fluxion.Managers.Data.Models;

namespace Ca.Fluxion.LogView.IO
{
	/// <summary>
	/// Model representing a log view setting.
	/// </summary>
	public class LogViewSetting
	{

		#region Properties

		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>The identifier.</value>
		[PrimaryKey (true), IntegerField ("Identifier", low: 0)]
		public int Identifier {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		/// <value>The description.</value>
		[CharField ("Description", maxlength: 255)]
		public string Description {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the value.
		/// </summary>
		/// <value>The value.</value>
		[CharField ("Value")]
		public string Value {
			get;
			set;
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="Fluxion_Log_View.LogViewSetting"/> class.
		/// </summary>
		/// <param name="description">Description.</param>
		/// <param name="value">Value.</param>
		public LogViewSetting (string description, string value)
		{
			this.Description = description;
			this.Value = value;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Fluxion_Log_View.LogViewSetting"/> class.
		/// </summary>
		/// <param name="description">Description.</param>
		/// <param name="value">If set to <c>true</c> value.</param>
		public LogViewSetting (string description, bool value)
		{
			this.Description = description;

			if (value)
				this.Value = "1";
			else
				this.Value = "0";
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Fluxion_Log_View.LogViewSetting"/> class.
		/// </summary>
		/// <param name="description">Description.</param>
		/// <param name="value">Value.</param>
		public LogViewSetting (string description, int value)
		{
			this.Description = description;
			this.Value = value.ToString ();
		}

		#endregion

	}
}

