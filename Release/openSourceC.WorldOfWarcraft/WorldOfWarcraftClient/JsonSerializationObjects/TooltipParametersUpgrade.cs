using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for TooltipParameters.
	/// </summary>
	[DataContract(Name = "upgrade")]
	[Serializable]
	public class TooltipParametersUpgrade
	{
		/// <summary></summary>
		[DataMember(Name = "current")]
		public int? Current;

		/// <summary></summary>
		[DataMember(Name = "itemLevelIncrement")]
		public int? ItemLevelIncrement;

		/// <summary></summary>
		[DataMember(Name = "total")]
		public int? Total;
	}
}
