using System;
using System.Collections.Generic;

namespace openSourceC.WorldOfWarcraft
{
	/// <summary>
	///		Summary description for Achievements.
	/// </summary>
	[Serializable]
	public class Achievements
	{
		/// <summary></summary>
		public List<int> AchievementsCompleted;

		/// <summary></summary>
		public List<long> AchievementsCompletedTimestamp;

		/// <summary></summary>
		public List<int> Criteria;

		/// <summary></summary>
		public List<long> CriteriaQuantity;

		/// <summary></summary>
		public List<long> CriteriaTimestamp;

		/// <summary></summary>
		public List<long> CriteriaCreated;
	}
}
