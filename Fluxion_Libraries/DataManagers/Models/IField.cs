using System;

namespace Ca.Fluxion
{
	/// <summary>
	/// Indicates that object partially or fully represents
	/// a database column.
	/// </summary>
	public interface IField
	{
		string ColumnName{ get; set; }
	}
}

