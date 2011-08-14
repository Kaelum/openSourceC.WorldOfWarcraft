using System;
using System.Collections.Generic;

namespace openSourceC.WorldOfWarcraft
{
	/// <summary>
	///		Summary description for Achievement.
	/// </summary>
	[Serializable]
	public class Achievement
	{
		/// <summary></summary>
		public int Id;

		/// <summary></summary>
		public string Title;

		/// <summary></summary>
		public int Points;

		/// <summary></summary>
		public string Description;

		/// <summary></summary>
		public string Reward;

		/// <summary></summary>
		public Item RewardItem;
	}
}
