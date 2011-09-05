using System;
using System.Collections.Generic;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for GuildReward.
	/// </summary>
	[Serializable]
	public class GuildReward
	{
		/// <summary></summary>
		public int MinGuildLevel;

		/// <summary></summary>
		public int MinGuildRepLevel;

		/// <summary></summary>
		public List<int> Races;

		/// <summary></summary>
		public string Name;


		/// <summary></summary>
		public Achievement Achievement;

		/// <summary></summary>
		public Item Item;
	}
}
