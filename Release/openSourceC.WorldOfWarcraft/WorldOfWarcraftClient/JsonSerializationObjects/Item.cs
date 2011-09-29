using System;
using System.Collections.Generic;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for Item.
	/// </summary>
	[Serializable]
	public class Item
	{
		/// <summary></summary>
		public int Id;

		/// <summary></summary>
		public string Name;

		/// <summary></summary>
		public string Icon;

		/// <summary></summary>
		public int Quality;


		/// <summary></summary>
		public TooltipParameters TooltipParams;
	}
}
