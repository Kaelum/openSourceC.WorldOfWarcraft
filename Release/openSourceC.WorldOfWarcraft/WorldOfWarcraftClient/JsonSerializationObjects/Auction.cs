using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for Auction.
	/// </summary>
	[DataContract(Name = "auction")]
	[Serializable]
	public class Auction
	{
		/// <summary></summary>
		[DataMember(Name = "auc")]
		public long AuctionId;

		/// <summary></summary>
		[DataMember(Name = "bid")]
		public long Bid;

		/// <summary></summary>
		[DataMember(Name = "buyout")]
		public long Buyout;

		/// <summary></summary>
		[DataMember(Name = "item")]
		public int Item;

		/// <summary></summary>
		[DataMember(Name = "owner")]
		public string Owner;

		/// <summary></summary>
		[DataMember(Name = "quantity")]
		public int Quantity;

		/// <summary></summary>
		[IgnoreDataMember]
		public TimeLeftEnum TimeLeft;

		/// <summary></summary>
		[DataMember(Name = "timeLeft")]
		public string TimeLeftValue
		{
			get
			{
				switch (TimeLeft)
				{
					case TimeLeftEnum.VeryLong:
					{
						return "VERY_LONG";
					}

					default:
					{
						return TimeLeft.ToString().ToUpperInvariant();
					}
				}
			}

			set
			{
				if (Enum.TryParse<TimeLeftEnum>(value, true, out TimeLeft)) { return; }

				switch (value.ToUpperInvariant())
				{
					case "VERY_LONG":
					{
						TimeLeft = TimeLeftEnum.VeryLong;
						break;
					}
				}
			}
		}
	}
}
