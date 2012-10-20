using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for Guild.
	/// </summary>
	[DataContract(Name = "guild")]
	[Serializable]
	public class Guild
	{
		/// <summary></summary>
		[DataMember(Name = "achievementPoints")]
		public int AchievementPoints;

		/// <summary></summary>
		[DataMember(Name = "battlegroup")]
		public string Battlegroup;

		/// <summary></summary>
		[DataMember(Name = "level")]
		public int Level;

		/// <summary></summary>
		[DataMember(Name = "members")]
		public int Members;

		/// <summary></summary>
		[DataMember(Name = "name")]
		public string Name;

		/// <summary></summary>
		[DataMember(Name = "realm")]
		public string Realm;


		/// <summary></summary>
		[DataMember(Name = "emblem")]
		public Emblem Emblem;
	}
}
