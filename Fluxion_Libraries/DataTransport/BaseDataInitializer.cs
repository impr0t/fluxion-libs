using System;
using System.Reflection;
using Ca.Fluxion.Managers.Data.Models;

namespace Ca.Fluxion.Transports.Data
{
	public class BaseDataInitializer : IInitializer
	{

		#region IInitializer implementation

		public bool Validate (Type objType, out string message)
		{
			PropertyInfo[] propCollection = objType.GetProperties ();
			bool primaryKeyFound = false;
			bool attributeFound = false;
			string propertyName = string.Empty;

			// iterate through all properties of the object type.
			foreach (PropertyInfo property in propCollection) {

				if (!primaryKeyFound) {
					primaryKeyFound = this.CheckPrimaryKey (property);
				}

				attributeFound = this.CheckValidAttributes (property);

				// all properties must be marked with field attributes
				// otherwise validation will fail.
				if (!attributeFound) {
					propertyName = property.Name;
					break;
				}
			}

			if (!primaryKeyFound) {
				message = "No Primary Key detected, validation failed.";
				return false;

			}

			if (!attributeFound) {
				message = "Field type could not be determined for " + propertyName + ".";
				return false;
			}

			// positive validation.
			message = string.Empty;
			return true;
		}

		/// <summary>
		/// Process the specified obj.
		/// </summary>
		/// <param name="obj">Object.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public virtual string[] Process (Type obj)
		{
			// intentionally blank.
			// used for concrete implementations only.
			return new string[0];
		}

		#endregion

		/// <summary>
		/// Checks the properties of the model to ensure that a primary key is located.
		/// </summary>
		/// <returns><c>true</c>, if primary key found was checked, <c>false</c> otherwise.</returns>
		/// <param name="property">Property.</param>
		private bool CheckPrimaryKey (PropertyInfo property)
		{
			foreach (var attribute in property.GetCustomAttributes(true)) {
				if (attribute is PrimaryKey) {
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Checks the valid attributes.
		/// </summary>
		/// <param name="property">Property.</param>
		/// <param name="attributeFound">Attribute found.</param>
		private bool CheckValidAttributes (PropertyInfo property)
		{
			foreach (var attribute in property.GetCustomAttributes (true)) {
				if (attribute is CharField) {
					return true;
				} else if (attribute is IntegerField) {
					return true;
				} else if (attribute is BooleanField) {
					return true;
				}
			}
			return false;
		}
	}
}

