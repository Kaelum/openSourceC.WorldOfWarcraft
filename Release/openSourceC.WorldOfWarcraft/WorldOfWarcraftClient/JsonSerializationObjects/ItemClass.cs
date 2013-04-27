using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for ItemClass.
	/// </summary>
	[DataContract(Name = "itemClass")]
	[Serializable]
	public class ItemClass
	{
		/// <summary></summary>
		[DataMember(Name = "class")]
		public int Class;

		/// <summary></summary>
		[DataMember(Name = "name")]
		public string Name;

		/// <summary></summary>
		[IgnoreDataMember]
		public List<ItemSubClass> SubClasses;

		/// <summary></summary>
		[DataMember(Name = "subclasses")]
		public ItemSubClass[] SubClassesValue
		{
			get { return (SubClasses == null ? null : SubClasses.ToArray()); }
			set { SubClasses = (value == null ? null : new List<ItemSubClass>(value)); }
		}
	}
}
