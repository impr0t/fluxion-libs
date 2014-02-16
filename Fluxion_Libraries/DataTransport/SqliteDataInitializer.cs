using System;
using Mono.Data.Sqlite;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using Ca.Fluxion.Managers.Data.Models;

namespace Ca.Fluxion.Transports.Data
{
	public class SqliteDataInitializer : BaseDataInitializer
	{
		/// <summary>
		/// We're going to process our object based on it's type.
		/// This object should have already been validated before this
		/// step occurs.  BaseDataInitializer.Validate should have been
		/// executed already, if it hasn't this might fail.
		/// </summary>
		/// <param name="obj">Object.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public override string[] Process (Type obj)
		{
			string tableName = obj.Name;

			StringBuilder sb = new StringBuilder ();
			sb.Append ("CREATE TABLE IF NOT EXISTS" + " \"" + tableName + "\"");
			sb.Append (" (");

			// extract the property info from this type.
			PropertyInfo[] propertyInfo = obj.GetProperties ();
			foreach (var pInfo in propertyInfo) {

				bool applyPrimaryKey = false;
				foreach (var attribute in pInfo.GetCustomAttributes(true)) {

					// isolate the column name.
					if (attribute is IField) {
						sb.Append ("\"");
						sb.Append (((IField)attribute).ColumnName);
						sb.Append ("\"");
						sb.Append (" ");
					}

					if (attribute is CharField) {
						var cField = attribute as CharField;

						sb.Append ("varchar(");
						sb.Append (cField.MaxLength.ToString ());
						sb.Append (")");
					}

					if (attribute is IntegerField) {
						sb.Append ("int");
						sb.Append (" ");
					}

					if (attribute is BooleanField) {
						sb.Append ("BOOLEAN");
						sb.Append (" ");
					}

					if (attribute is PrimaryKey) {
						applyPrimaryKey = true;
					}
				}

				if (applyPrimaryKey) {
					sb.Append ("primary key");
				}

				sb.Append (",");
			}

			//remove the last comma.
			sb.Remove (sb.Length - 1, 1);

			// finish the statement.
			sb.Append (");");

			return new string[]{ sb.ToString () };
		}
	}
}
