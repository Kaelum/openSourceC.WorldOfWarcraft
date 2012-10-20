using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for TalentTree.
	/// </summary>
	[DataContract(Name = "talentTree")]
	[Serializable]
	public class TalentTree
	{
		/// <summary></summary>
		[DataMember(Name = "column")]
		public int Column;

		/// <summary></summary>
		[DataMember(Name = "tier")]
		public int Tier;


		/// <summary></summary>
		[DataMember(Name = "spell")]
		public Spell Spell;
	}
}
