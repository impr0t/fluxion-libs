using System;

namespace Ca.Fluxion.Managers.Data.Models
{
	/// <summary>
	/// Base column attribute class, inherits from System.Attribute
	/// and implements IField.
	/// </summary>
	public class ColumnAttribute : Attribute, IField
	{

		#region IField implementation

		/// <summary>
		/// Gets or sets the name of the column.
		/// </summary>
		/// <value>The name of the column.</value>
		public string ColumnName {
			get;
			set;
		}

		#endregion

	}

	/// <summary>
	/// Marks a field as being a primary key.
	/// </summary>
	[AttributeUsage (AttributeTargets.Property, AllowMultiple = false)]
	public class PrimaryKey : Attribute
	{
		/// <summary>
		/// Gets a value indicating whether this <see cref="Ca.Fluxion.Managers.Data.Models.PrimaryKey"/> auto increments.
		/// </summary>
		/// <value><c>true</c> if auto increment; otherwise, <c>false</c>.</value>
		public bool AutoIncrement {
			get;
			private set;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Ca.Fluxion.Managers.Data.Models.PrimaryKey"/> class.
		/// </summary>
		/// <param name="autoIncrement">If set to <c>true</c> auto increment.</param>
		public PrimaryKey (bool autoIncrement = false)
		{
			this.AutoIncrement = autoIncrement;
		}
	}

	/// <summary>
	/// Marked a field as being of character nature.
	/// </summary>
	[AttributeUsage (AttributeTargets.Property, AllowMultiple = false)]
	public class CharField : ColumnAttribute
	{
		/// <summary>
		/// Gets the maximum length of the field.
		/// </summary>
		/// <value>The length of the max.</value>
		public int MaxLength {
			get;
			private set;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Ca.Fluxion.Managers.Data.Models.CharField"/> class.
		/// </summary>
		/// <param name="columnName">Column name.</param>
		/// <param name="maxlength">Maxlength.</param>
		public CharField (string columnName, int maxlength = 50)
		{
			this.MaxLength = maxlength;
			this.ColumnName = columnName;
		}
	}

	/// <summary>
	/// Marks a field as being integer in nature.
	/// </summary>
	[AttributeUsage (AttributeTargets.Property, AllowMultiple = false)]
	public class IntegerField : ColumnAttribute
	{
		/// <summary>
		/// Gets the lowest value this field can hold.
		/// </summary>
		/// <value>The low.</value>
		public int Low {
			get;
			private set;
		}

		/// <summary>
		/// Gets the highest value this field can hold.
		/// </summary>
		/// <value>The high.</value>
		public int High {
			get;
			private set;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Ca.Fluxion.Managers.Data.Models.IntegerField"/> class.
		/// </summary>
		/// <param name="columnName">Column name.</param>
		/// <param name="low">Low.</param>
		/// <param name="high">High.</param>
		public IntegerField (string columnName, int low = int.MinValue, int high = int.MaxValue)
		{
			this.ColumnName = columnName;
			this.Low = low;
			this.High = high;
		}
	}

	/// <summary>
	/// Marks a field as being boolean in nature.
	/// </summary>
	[AttributeUsage (AttributeTargets.Property, AllowMultiple = false)]
	public class BooleanField : ColumnAttribute
	{
	}
}

