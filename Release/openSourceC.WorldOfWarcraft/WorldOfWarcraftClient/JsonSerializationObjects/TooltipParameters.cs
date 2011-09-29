using System;
using System.Collections.Generic;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for TooltipParameters.
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
