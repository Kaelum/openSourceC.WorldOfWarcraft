using System;
using System.Collections.Generic;

namespace openSourceC.WorldOfWarcraft
{
	/// <summary>
	///		Summary description for Talent.
	/// </summary>
	[Serializable]
	public class Talent
	{
		/// <summary></summary>
		public bool Selected;

		/// <summary></summary>
		public string Name;

		/// <summary></summary>
		public string Icon;

		/// <summary></summary>
		public string Build;


		/// <summary></summary>
		public List<TalentTree> Trees;

		/// <summary></summary>
		public TalentGlyphs Glyphs;
	}
}
