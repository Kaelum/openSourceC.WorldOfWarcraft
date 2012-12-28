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
		public double Min;

		/// <summary></summary>
		[DataMember(Name = "max")]
		public double Max;
	}
}
