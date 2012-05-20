using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for GuildReward.
	/// </summary>
	[DataContract(Name = "guildReward")]
	[Serializable]
	public class GuildReward
	{
		/// <summary></summary>
		[DataMember(Name = "minGuildLevel")]
		public int MinGuildLevel;

		/// <summary></summary>
		[DataMember(Name = "minGuildRepLevel")]
		public int MinGuildRepLevel;

		/// <summary></summary>
		[DataMember(Name = "name")]
		public string Name;


		/// <summary></summary>
		[DataMember(Name = "achievement")]
		public AchievementResponse Achievement;

		/// <summary></summary>
		[DataMember(Name = "item")]
		public Item Item;

		/// <summary></summary>
		[IgnoreDataMember]
		public List<CharacterRaceEnum> Races;

		/// <summary></summary>
		[DataMember(Name = "races")]
		public CharacterRaceEnum[] RacesValue
		{
			get { return (Races == null ? null : Races.ToArray()); }
			set { Races = (value == null ? null : new List<CharacterRaceEnum>(value)); }
		}
	}
}
