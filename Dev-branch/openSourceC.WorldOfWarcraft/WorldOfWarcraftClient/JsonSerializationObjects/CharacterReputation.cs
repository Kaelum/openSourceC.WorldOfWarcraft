using System;
using System.Collections.Generic;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for CharacterReputation.
	/// </summary>
	[Serializable]
	public class CharacterReputation
	{
		/// <summary></summary>
		public int Id;

		/// <summary></summary>
		public string Name;

		/// <summary></summary>
		public int Standing;

		/// <summary></summary>
		public int Value;

		/// <summary></summary>
		public int Max;
	}
}
