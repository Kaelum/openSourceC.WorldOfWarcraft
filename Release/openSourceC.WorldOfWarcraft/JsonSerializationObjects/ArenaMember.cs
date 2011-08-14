using System;
using System.Collections.Generic;

namespace openSourceC.WorldOfWarcraft
{
	/// <summary>
	///		Summary description for Member.
	/// </summary>
	[Serializable]
	public class ArenaMember
	{
		/// <summary></summary>
		public Character Character;

		/// <summary></summary>
		public int Rank;

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
		public int PersonalRating;
	}
}
