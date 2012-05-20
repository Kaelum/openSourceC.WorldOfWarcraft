using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for DataAchievement.
	/// </summary>
	[DataContract(Name = "achievement")]
	[Serializable]
	public class DataAchievement
	{
		/// <summary></summary>
		[DataMember(Name = "id")]
		public int Id;

		/// <summary></summary>
		[DataMember(Name = "name")]
		public string Name;


		/// <summary></summary>
		[IgnoreDataMember]
		public List<AchievementResponse> Achievements;

		/// <summary></summary>
		[DataMember(Name = "achievements")]
		public AchievementResponse[] AchievementsValue
		{
			get { return (Achievements == null ? null : Achievements.ToArray()); }
			set { Achievements = (value == null ? null : new List<AchievementResponse>(value)); }
		}

		/// <summary></summary>
		[IgnoreDataMember]
		public List<DataAchievement> Categories;

		/// <summary></summary>
		[DataMember(Name = "categories")]
		public DataAchievement[] CategoriesValue
		{
			get { return (Categories == null ? null : Categories.ToArray()); }
			set { Categories = (value == null ? null : new List<DataAchievement>(value)); }
		}
	}
}
