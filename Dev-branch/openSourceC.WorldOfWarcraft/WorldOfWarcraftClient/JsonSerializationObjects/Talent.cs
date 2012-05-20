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
	public class Talent
	{
		/// <summary></summary>
		[DataMember(Name = "build")]
		public string Build;

		/// <summary></summary>
		[DataMember(Name = "icon")]
		public string Icon;

		/// <summary></summary>
		[DataMember(Name = "name")]
		public string Name;

		/// <summary></summary>
		[DataMember(Name = "selected")]
		public bool Selected;


		/// <summary></summary>
		[DataMember(Name = "glyphs")]
		public TalentGlyphs Glyphs;

		/// <summary></summary>
		[IgnoreDataMember]
		public List<TalentTree> Trees;

		/// <summary></summary>
		[DataMember(Name = "trees")]
		public TalentTree[] TreesValue
		{
			get { return (Trees == null ? null : Trees.ToArray()); }
			set { Trees = (value == null ? null : new List<TalentTree>(value)); }
		}
	}
}
