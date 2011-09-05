using System;
using System.Collections.Generic;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for Character.
	/// </summary>
	[Serializable]
	public class Character
	{
		/// <summary></summary>
		public string Name;

		/// <summary></summary>
		public string Realm;

		/// <summary></summary>
		public int Class;

		/// <summary></summary>
		public int Race;

		/// <summary></summary>
		public int Gender;

		/// <summary></summary>
		public int Level;

		/// <summary></summary>
		public int AchievementPoints;

		/// <summary></summary>
		public string Thumbnail;
	}
}
