using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Mono.Data.Sqlite;
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
			// get the tablename for the object.
			string tableName = obj.Name.ToLower ();

			// start create table statement creation.
			StringBuilder sb = new StringBuilder ();
			sb.Append ("CREATE TABLE IF NOT EXISTS" + " \"" + tableName + "\"");
			sb.Append (" (");

			// extract the property info from this type.
			string primaryKey = string.Empty;

			PropertyInfo[] propertyInfo = obj.GetProperties ();
			foreach (var pInfo in propertyInfo) {

				// will be populated with the field name of the property.
				string fieldName = string.Empty;

				// go through all attributes packed on the object.
				foreach (var attribute in pInfo.GetCustomAttributes(true)) {

					// isolate the column name.
					if (attribute is IField) {
						fieldName = ((IField)attribute).ColumnName;
						sb.Append ("\"");
						sb.Append (fieldName);
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
						primaryKey += fieldName + ",";
					}
				}
			
				sb.Append (",");
			}
		
			// sanitize the primary key call.
			primaryKey = primaryKey.TrimEnd (',');

			// apply the primary key field to the query.
			sb.Append ("PRIMARY KEY (" + primaryKey + ")");

			// finish the statement.
			sb.Append (");");

			return new string[]{ sb.ToString () };
		}
	}
}
