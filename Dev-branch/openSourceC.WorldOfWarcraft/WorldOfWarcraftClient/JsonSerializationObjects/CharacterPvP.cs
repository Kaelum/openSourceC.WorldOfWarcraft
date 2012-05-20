using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for CharacterPvP.
	/// </summary>
	[DataContract(Name = "characterPvP")]
	[Serializable]
	public class CharacterPvP
	{
		/// <summary></summary>
		[IgnoreDataMember]
		public List<RaidProgression> ArenaTeams;

		/// <summary></summary>
		[DataMember(Name = "arenaTeams")]
		public RaidProgression[] ArenaTeamsValue
		{
			get { return (ArenaTeams == null ? null : ArenaTeams.ToArray()); }
			set { ArenaTeams = (value == null ? null : new List<RaidProgression>(value)); }
		}

		/// <summary></summary>
		[DataMember(Name = "ratedBattlegrounds")]
		public RatedBattleground RatedBattlegrounds;

		/// <summary></summary>
		[DataMember(Name = "totalHonorableKills")]
		public int TotalHonorableKills;
	}
}
