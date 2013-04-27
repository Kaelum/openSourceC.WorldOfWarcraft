using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for ItemSubClass.
	/// </summary>
	[DataContract(Name = "itemSubClass")]
	[Serializable]
	public class ItemSubClass
	{
		/// <summary></summary>
		[DataMember(Name = "name")]
		public string Name;

		/// <summary></summary>
		[DataMember(Name = "subclass")]
		public int SubClass;
	}
}
