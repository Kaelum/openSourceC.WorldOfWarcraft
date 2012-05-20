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
	}
}
