using System;
using System.Collections.Generic;

namespace openSourceC.WorldOfWarcraft
{
	/// <summary>
	///		Summary description for Profession.
	/// </summary>
	[Serializable]
	public class Profession
	{
		/// <summary></summary>
		public int Id;

		/// <summary></summary>
		public string Name;

		/// <summary></summary>
		public string Icon;

		/// <summary></summary>
		public int Rank;

		/// <summary></summary>
		public int Max;

		/// <summary></summary>
		public List<int> Recipes;
	}
}
