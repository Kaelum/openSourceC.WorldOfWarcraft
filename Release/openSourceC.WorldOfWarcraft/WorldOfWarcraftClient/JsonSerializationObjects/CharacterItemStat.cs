using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for Item.
	/// </summary>
	[DataContract(Name = "characterItemStat")]
	[Serializable]
	public class CharacterItemStat
	{
		/// <summary></summary>
		[DataMember(Name = "amount")]
		public int? Amount;

		/// <summary></summary>
		[DataMember(Name = "reforged")]
		public bool? Reforged;

		/// <summary></summary>
		[DataMember(Name = "stat")]
		public int? Stat;
	}
}
