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
		[DataMember(Name = "min")]
		public int Min;

		/// <summary></summary>
		[DataMember(Name = "max")]
		public int Max;
	}
}
