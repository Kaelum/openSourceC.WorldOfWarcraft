using System;
using System.Collections.Generic;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for DataAchievement.
	/// </summary>
	[Serializable]
	public class DataAchievement
	{
		/// <summary></summary>
		public int Id;

		/// <summary></summary>
		public string Name;


		/// <summary></summary>
		public List<Achievement> Achievements;

		/// <summary></summary>
		public List<DataAchievement> Categories;
	}
}
