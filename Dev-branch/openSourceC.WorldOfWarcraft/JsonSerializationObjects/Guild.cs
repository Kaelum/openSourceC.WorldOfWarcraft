using System;
using System.Collections.Generic;

namespace openSourceC.WorldOfWarcraft
{
	/// <summary>
	///		Summary description for Guild.
	/// </summary>
	[Serializable]
	public class Guild
	{
		/// <summary></summary>
		public string Name;

		/// <summary></summary>
		public string Realm;

		/// <summary></summary>
		public int Level;

		/// <summary></summary>
		public int Members;

		/// <summary></summary>
		public int AchievementPoints;

		/// <summary></summary>
		public Emblem Emblem;
	}
}
