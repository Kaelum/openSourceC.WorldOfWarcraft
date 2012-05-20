using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for AuctionDataHeaderResponse.
	/// </summary>
	[DataContract(Name = "response")]
	[Serializable]
	public class AuctionDataHeaderResponse : BaseResponse
	{
		/// <summary></summary>
		[IgnoreDataMember]
		public List<AuctionDataHeader> Files;

		/// <summary></summary>
		[DataMember(Name = "files")]
		public AuctionDataHeader[] FilesValue
		{
			get { return (Files == null ? null : Files.ToArray()); }
			set { Files = (value == null ? null : new List<AuctionDataHeader>(value)); }
		}
	}
}
