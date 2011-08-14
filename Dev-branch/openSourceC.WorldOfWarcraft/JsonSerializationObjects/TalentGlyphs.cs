using System;
using System.Collections.Generic;

namespace openSourceC.WorldOfWarcraft
{
	/// <summary>
	///		Summary description for TalentGlyphs.
	/// </summary>
	[Serializable]
	public class TalentGlyphs
	{
		/// <summary></summary>
		public List<TalentGlyph> Prime;

		/// <summary></summary>
		public List<TalentGlyph> Major;

		/// <summary></summary>
		public List<TalentGlyph> Minor;
	}
}
