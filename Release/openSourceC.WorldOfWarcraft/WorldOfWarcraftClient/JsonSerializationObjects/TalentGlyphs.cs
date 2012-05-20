using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for TalentGlyphs.
	/// </summary>
	[DataContract(Name = "talentGlyphs")]
	[Serializable]
	public class TalentGlyphs
	{
		/// <summary></summary>
		[IgnoreDataMember]
		public List<TalentGlyph> Major;

		/// <summary></summary>
		[DataMember(Name = "major")]
		public TalentGlyph[] MajorValue
		{
			get { return (Major == null ? null : Major.ToArray()); }
			set { Major = (value == null ? null : new List<TalentGlyph>(value)); }
		}

		/// <summary></summary>
		[IgnoreDataMember]
		public List<TalentGlyph> Minor;

		/// <summary></summary>
		[DataMember(Name = "minor")]
		public TalentGlyph[] MinorValue
		{
			get { return (Minor == null ? null : Minor.ToArray()); }
			set { Minor = (value == null ? null : new List<TalentGlyph>(value)); }
		}

		/// <summary></summary>
		[IgnoreDataMember]
		public List<TalentGlyph> Prime;

		/// <summary></summary>
		[DataMember(Name = "prime")]
		public TalentGlyph[] PrimeValue
		{
			get { return (Prime == null ? null : Prime.ToArray()); }
			set { Prime = (value == null ? null : new List<TalentGlyph>(value)); }
		}
	}
}
