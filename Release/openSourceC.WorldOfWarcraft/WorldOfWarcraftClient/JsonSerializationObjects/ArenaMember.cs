using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for ArenaMember.
	/// </summary>
	[DataContract(Name = "arenaMember")]
	[Serializable]
	public class ArenaMember
	{
		/// <summary></summary>
		[DataMember(Name = "gamesLost")]
		public int GamesLost;

		/// <summary></summary>
		[DataMember(Name = "gamesPlayed")]
		public int GamesPlayed;

		/// <summary></summary>
		[DataMember(Name = "gamesWon")]
		public int GamesWon;

		/// <summary></summary>
		[DataMember(Name = "personalRating")]
		public int PersonalRating;

		/// <summary></summary>
		[DataMember(Name = "rank")]
		public int Rank;

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
		[DataMember(Name = "character")]
		public Character Character;
	}
}
