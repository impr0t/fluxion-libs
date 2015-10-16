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
		/// Gets or sets the secton identifier.
		/// </summary>
		/// <value>The section identifier.</value>
		[PrimaryKey (false), IntegerField ("sectionid")]
		public int SectionID {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>The identifier.</value>
		[PrimaryKey (true), IntegerField ("paramid", low: 0)]
		public int Identifier {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		/// <value>The description.</value>
		[CharField ("desc", maxlength: 255)]
		public string Description {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the value.
		/// </summary>
		/// <value>The value.</value>
		[CharField ("value")]
		public string Value {
			get;
			set;
		}

		#endregion

		#region Constructors

		public LogViewSetting (int sectionid, int id)
		{
			this.SectionID = sectionid;
			this.Identifier = id;	
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Fluxion_Log_View.LogViewSetting"/> class.
		/// </summary>
		/// <param name="description">Description.</param>
		/// <param name="value">Value.</param>
		public LogViewSetting (int sectionid, int id, string description, string value) : this (sectionid, id)
		{
			this.Description = description;
			this.Value = value;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Fluxion_Log_View.LogViewSetting"/> class.
		/// </summary>
		/// <param name="description">Description.</param>
		/// <param name="value">If set to <c>true</c> value.</param>
		public LogViewSetting (int sectionid, int id, string description, bool value) : this (sectionid, id)
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
		public LogViewSetting (int sectionid, int id, string description, int value) : this (sectionid, id)
		{
			this.Description = description;
			this.Value = value.ToString ();
		}

		#endregion

	}
}

