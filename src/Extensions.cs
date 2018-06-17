using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLite 
{

	[AttributeUsage (AttributeTargets.Property)]
	public class VirtualColumnAttribute : IgnoreAttribute {
		/// <summary>
		/// Virtual column can be used in queries to map results to it
		/// </summary>
		public VirtualColumnAttribute () {

		}
	}


	[AttributeUsage (AttributeTargets.Property)]
	public class DefaultAttrribute : Attribute {
		/// <summary>
		/// SQL default string for the given column
		/// </summary>
		public string Default { get; set; }
		/// <summary>
		/// Set default value for column, must be valid sqlite string
		/// </summary>
		/// <param name="DefaultValue"></param>
		public DefaultAttrribute (string DefaultValue) {
			Default = DefaultValue;
		}
	}

}
