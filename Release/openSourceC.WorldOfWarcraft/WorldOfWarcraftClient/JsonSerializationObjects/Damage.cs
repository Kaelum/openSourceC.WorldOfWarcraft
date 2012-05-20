using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for Damage.
	/// </summary>
	[DataContract(Name = "damage")]
	[Serializable]
	public class Damage
	{
		/// <summary></summary>
		[DataMember(Name = "minDamage")]
		public int MinDamage;

		/// <summary></summary>
		[DataMember(Name = "maxDamage")]
		public int MaxDamage;
	}
}
