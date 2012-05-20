using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for AuctionDataFileResponse.
	/// </summary>
	[DataContract(Name = "response")]
	[Serializable]
	public class AuctionDataFileResponse : BaseResponse
	{
		/// <summary></summary>
		[DataMember(Name = "alliance")]
		public AuctionHouse Alliance;

		/// <summary></summary>
		[DataMember(Name = "horde")]
		public AuctionHouse Horde;

		/// <summary></summary>
		[DataMember(Name = "neutral")]
		public AuctionHouse Neutral;

		/// <summary></summary>
		[DataMember(Name = "realm")]
		public RealmStatus Realm;
	}
}
