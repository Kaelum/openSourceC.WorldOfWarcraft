using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for Talent.
	/// </summary>
	[DataContract(Name = "talent")]
	[Serializable]
	public class TalentBuild
	{
		/// <summary></summary>
		[DataMember(Name = "calcGlyph")]
		public string CalcGlyph;

		/// <summary></summary>
		[DataMember(Name = "calcSpec")]
		public string CalcSpec;

		/// <summary></summary>
		[DataMember(Name = "calcTalent")]
		public string CalcTalent;

		/// <summary></summary>
		[DataMember(Name = "selected")]
		public bool Selected;


		/// <summary></summary>
		[DataMember(Name = "glyphs")]
		public TalentGlyphs Glyphs;

		/// <summary></summary>
		[DataMember(Name = "spec")]
		public Spec Spec;

		/// <summary></summary>
		[IgnoreDataMember]
		public List<TalentTree> Talents;

		/// <summary></summary>
		[DataMember(Name = "trees")]
		public TalentTree[] TalentsValue
		{
			get { return (Talents == null ? null : Talents.ToArray()); }
			set { Talents = (value == null ? null : new List<TalentTree>(value)); }
		}
	}
}
