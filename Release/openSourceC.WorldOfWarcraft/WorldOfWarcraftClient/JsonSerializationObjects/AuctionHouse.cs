using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for AuctionHouse.
	/// </summary>
	[DataContract(Name = "auctionHouse")]
	[Serializable]
	public class AuctionHouse
	{
		/// <summary></summary>
		[IgnoreDataMember]
		public List<Auction> Auctions;

		/// <summary></summary>
		[DataMember(Name = "auctions")]
		public Auction[] AuctionsValue
		{
			get { return (Auctions == null ? null : Auctions.ToArray()); }
			set { Auctions = (value == null ? null : new List<Auction>(value)); }
		}
	}
}
