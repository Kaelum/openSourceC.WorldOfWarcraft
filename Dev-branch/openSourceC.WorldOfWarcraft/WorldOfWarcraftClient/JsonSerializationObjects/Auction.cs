using System;
using System.Collections.Generic;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for Auction.
	/// </summary>
	[Serializable]
	public class Auction
	{
		/// <summary></summary>
		public long Auc;

		/// <summary></summary>
		public int Item;

		/// <summary></summary>
		public string Owner;

		/// <summary></summary>
		public long Bid;

		/// <summary></summary>
		public long Buyout;

		/// <summary></summary>
		public int Quantity;
	}
}
