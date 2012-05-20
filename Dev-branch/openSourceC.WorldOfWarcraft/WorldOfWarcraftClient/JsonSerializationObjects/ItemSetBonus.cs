using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for ItemSetBonus.
	/// </summary>
	[DataContract(Name = "itemSetBonus")]
	[Serializable]
	public class ItemSetBonus
	{
		/// <summary></summary>
		[DataMember(Name = "description")]
		public string Description;

		/// <summary></summary>
		[DataMember(Name = "threshold")]
		public int Threshold;
	}
}
