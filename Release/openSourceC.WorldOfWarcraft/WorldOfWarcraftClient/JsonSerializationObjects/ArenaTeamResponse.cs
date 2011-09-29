using System;
using System.Collections.Generic;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for ArenaTeamResponse.
	/// </summary>
	[Serializable]
	public class ArenaTeamResponse
	{
		/// <summary></summary>
		public string Realm;

		/// <summary></summary>
		public int Ranking;

		/// <summary></summary>
		public int Rating;

		/// <summary></summary>
		public int TeamSize;

		/// <summary></summary>
		public string Created;

		/// <summary></summary>
		public string Name;

		/// <summary></summary>
		public int GamesPlayed;

		/// <summary></summary>
		public int GamesWon;

		/// <summary></summary>
		public int GamesLost;

		/// <summary></summary>
		public int SessionGamesPlayed;

		/// <summary></summary>
		public int SessionGamesWon;

		/// <summary></summary>
		public int SessionGamesLost;

		/// <summary></summary>
		public int LastSessionRanking;

		/// <summary></summary>
		public string Side;

		/// <summary></summary>
		public int CurrentWeekRanking;

		/// <summary></summary>
		public List<ArenaMember> Members;

	}
}
