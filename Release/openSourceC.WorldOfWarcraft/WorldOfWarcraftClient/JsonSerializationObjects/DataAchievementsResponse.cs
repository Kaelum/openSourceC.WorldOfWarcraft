using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for DataAchievementsResponse.
	/// </summary>
	[DataContract(Name = "response")]
	[Serializable]
	public class DataAchievementsResponse : BaseResponse
	{
		/// <summary></summary>
		[IgnoreDataMember]
		public List<DataAchievement> Achievements;

		/// <summary></summary>
		[DataMember(Name = "achievements")]
		public DataAchievement[] AchievementsValue
		{
			get { return (Achievements == null ? null : Achievements.ToArray()); }
			set { Achievements = (value == null ? null : new List<DataAchievement>(value)); }
		}
	}
}
