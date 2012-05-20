using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for TalentGlyph.
	/// </summary>
	[DataContract(Name = "talentGlyph")]
	[Serializable]
	public class TalentGlyph
	{
		/// <summary></summary>
		[DataMember(Name = "glyph")]
		public int Glyph;

		/// <summary></summary>
		[DataMember(Name = "icon")]
		public string Icon;

		/// <summary></summary>
		[DataMember(Name = "item")]
		public int Item;

		/// <summary></summary>
		[DataMember(Name = "name")]
		public string Name;
	}
}
