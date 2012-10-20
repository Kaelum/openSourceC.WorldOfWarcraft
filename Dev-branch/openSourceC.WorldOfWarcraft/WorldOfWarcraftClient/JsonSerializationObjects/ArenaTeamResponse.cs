using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Globalization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for ArenaTeamResponse.
	/// </summary>
	[DataContract(Name = "response")]
	[Serializable]
	public class ArenaTeamResponse : BaseResponse
	{
		/// <summary>This is the <see cref="T:DateTime"/> representation of <see cref="CreatedValue"/></summary>
		[IgnoreDataMember]
		public DateTime Created;

		/// <summary></summary>
		[DataMember(Name = "created")]
		public string CreatedValue
		{
			get { return Created.ToString("yyyy-MM-dd"); }
			set { Created = DateTime.ParseExact(value, "yyyy-MM-dd", CultureInfo.InvariantCulture); }
		}

		/// <summary></summary>
		[DataMember(Name = "currentWeekRanking")]
		public int CurrentWeekRanking;

		/// <summary></summary>
		[DataMember(Name = "gamesPlayed")]
		public int GamesPlayed;

		/// <summary></summary>
		[DataMember(Name = "gamesLost")]
		public int GamesLost;

		/// <summary></summary>
		[DataMember(Name = "gamesWon")]
		public int GamesWon;

		/// <summary></summary>
		[DataMember(Name = "lastSessionRanking")]
		public int LastSessionRanking;

		/// <summary></summary>
		[DataMember(Name = "name")]
		public string Name;

		/// <summary></summary>
		[DataMember(Name = "ranking")]
		public int Ranking;

		/// <summary></summary>
		[DataMember(Name = "rating")]
		public int Rating;

		/// <summary></summary>
		[DataMember(Name = "realm")]
		public string Realm;

		/// <summary></summary>
		[DataMember(Name = "sessionGamesPlayed")]
		public int SessionGamesPlayed;

		/// <summary></summary>
		[DataMember(Name = "sessionGamesLost")]
		public int SessionGamesLost;

		/// <summary></summary>
		[DataMember(Name = "sessionGamesWon")]
		public int SessionGamesWon;

		/// <summary></summary>
		[IgnoreDataMember]
		public FactionEnum Side;

		/// <summary></summary>
		[DataMember(Name = "side")]
		public string SideValue
		{
			get { return Side.ToString().ToLowerInvariant(); }
			set { Side = (FactionEnum)Enum.Parse(typeof(FactionEnum), value, true); }
		}

		/// <summary></summary>
		[DataMember(Name = "teamSize")]
		public int TeamSize;


		/// <summary></summary>
		[IgnoreDataMember]
		public List<ArenaMember> Members;

		/// <summary></summary>
		[DataMember(Name = "members")]
		public ArenaMember[] MembersValue
		{
			get { return (Members == null ? null : Members.ToArray()); }
			set { Members = (value == null ? null : new List<ArenaMember>(value)); }
		}
	}
}
