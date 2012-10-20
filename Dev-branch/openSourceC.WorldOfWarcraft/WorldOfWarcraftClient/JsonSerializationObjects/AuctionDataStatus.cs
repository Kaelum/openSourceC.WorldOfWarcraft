using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for AuctionDataStatus.
	/// </summary>
	[DataContract(Name = "auctionDataStatus")]
	[Serializable]
	public class AuctionDataStatus
	{
		/// <summary></summary>
		[DataMember(Name = "url")]
		public string Url;

		/// <summary>This is the <see cref="T:DateTime"/> representation of <see cref="LastModifiedValue"/></summary>
		[IgnoreDataMember]
		public DateTime LastModified;

		/// <summary></summary>
		[DataMember(Name = "lastmodified")]
		public long LastModifiedValue
		{
			get { return LastModified.ToUnixTime(); }
			set { LastModified = value.ToDateTime(); }
		}


		/// <summary>This is a placeholder for that actual deserialized data file.</summary>
		[IgnoreDataMember]
		public AuctionDataFileResponse Data { get; set; }
	}
}
