using System;
using System.Collections.Generic;

namespace openSourceC.WorldOfWarcraft
{
	/// <summary>
	///		Summary description for Item.
	/// </summary>
	[Serializable]
	public class TooltipParameters
	{
		/// <summary></summary>
		public int Gem0;

		/// <summary></summary>
		public int Gem1;

		/// <summary></summary>
		public bool ExtraSocket;

		/// <summary></summary>
		public int Enchant;

		/// <summary></summary>
		public List<int> Set;
	}
}
