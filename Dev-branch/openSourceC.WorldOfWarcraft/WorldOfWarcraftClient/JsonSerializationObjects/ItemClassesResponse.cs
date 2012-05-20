using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for ItemClassesResponse.
	/// </summary>
	[DataContract(Name = "response")]
	[Serializable]
	public class ItemClassesResponse : BaseResponse
	{
		/// <summary></summary>
		[IgnoreDataMember]
		public List<ItemClass> Classes;

		/// <summary></summary>
		[DataMember(Name = "classes")]
		public ItemClass[] ClassesValue
		{
			get { return (Classes == null ? null : Classes.ToArray()); }
			set { Classes = (value == null ? null : new List<ItemClass>(value)); }
		}
	}
}
