using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for ItemSource.
	/// </summary>
	[DataContract(Name = "itemSource")]
	[Serializable]
	public class ItemSource
	{
		/// <summary></summary>
		[DataMember(Name = "sourceId")]
		public int SourceId;

		/// <summary></summary>
		[DataMember(Name = "sourceType")]
		public string SourceType;
	}
}
