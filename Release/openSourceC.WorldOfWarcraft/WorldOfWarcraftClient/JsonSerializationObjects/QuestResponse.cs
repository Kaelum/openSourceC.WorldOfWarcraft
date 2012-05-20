using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for QuestResponse.
	/// </summary>
	[DataContract(Name = "response")]
	[Serializable]
	public class QuestResponse : BaseResponse
	{
		/// <summary></summary>
		[DataMember(Name = "category")]
		public string Category;

		/// <summary></summary>
		[DataMember(Name = "id")]
		public int Id;

		/// <summary></summary>
		[DataMember(Name = "level")]
		public int Level;

		/// <summary></summary>
		[DataMember(Name = "reqLevel")]
		public int ReqLevel;

		/// <summary></summary>
		[DataMember(Name = "suggestedPartyMembers")]
		public int SuggestedPartyMembers;

		/// <summary></summary>
		[DataMember(Name = "title")]
		public string Title;
	}
}
