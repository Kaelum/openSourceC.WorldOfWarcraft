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
		[DataMember(Name = "points")]
		public string Points;

		/// <summary></summary>
		[DataMember(Name = "total")]
		public int Total;
	}
}
