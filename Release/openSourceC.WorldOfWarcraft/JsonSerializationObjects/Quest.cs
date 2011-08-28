using System;
using System.Collections.Generic;

namespace openSourceC.WorldOfWarcraft
{
	/// <summary>
	///		Summary description for Quest.
	/// </summary>
	[Serializable]
	public class Quest
	{
		/// <summary></summary>
		public int Id;

		/// <summary></summary>
		public string Title;

		/// <summary></summary>
		public int ReqLevel;

		/// <summary></summary>
		public int SuggestedPartyMembers;

		/// <summary></summary>
		public string Category;

		/// <summary></summary>
		public int Level;
	}
}
