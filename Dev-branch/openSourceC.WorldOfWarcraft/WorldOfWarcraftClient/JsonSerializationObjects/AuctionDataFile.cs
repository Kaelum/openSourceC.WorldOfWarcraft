using System;
using System.Collections.Generic;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for AuctionDataFile.
	/// </summary>
	[Serializable]
	public class AuctionDataFile
	{
		/// <summary></summary>
		public Realm Realm;

		/// <summary></summary>
		public AuctionHouse Alliance;

		/// <summary></summary>
		public AuctionHouse Horde;

		/// <summary></summary>
		public AuctionHouse Neutral;
	}
}
