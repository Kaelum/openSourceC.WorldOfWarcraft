using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for AuctionDataStatusResponse.
	/// </summary>
	[DataContract(Name = "response")]
	[Serializable]
	public class AuctionDataStatusResponse : BaseResponse
	{
		/// <summary></summary>
		[IgnoreDataMember]
		public List<AuctionDataStatus> Files;

		/// <summary></summary>
		[DataMember(Name = "files")]
		public AuctionDataStatus[] FilesValue
		{
			get { return (Files == null ? null : Files.ToArray()); }
			set { Files = (value == null ? null : new List<AuctionDataStatus>(value)); }
		}
	}
}
