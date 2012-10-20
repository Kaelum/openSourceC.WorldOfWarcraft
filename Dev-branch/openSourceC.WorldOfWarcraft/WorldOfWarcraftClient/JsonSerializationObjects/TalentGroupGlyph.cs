using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for TalentGroupGlyph.
	/// </summary>
	[DataContract(Name = "glyph")]
	[Serializable]
	public class TalentGroupGlyph
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

		/// <summary></summary>
		[DataMember(Name = "typeId")]
		public int TypeId;
	}
}
