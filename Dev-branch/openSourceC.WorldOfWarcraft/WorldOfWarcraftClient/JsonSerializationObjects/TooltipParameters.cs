using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for TooltipParameters.
	/// </summary>
	[DataContract(Name = "tooltipParameters")]
	[Serializable]
	public class TooltipParameters
	{
		/// <summary></summary>
		[DataMember(Name = "enchant")]
		public int Enchant;

		/// <summary></summary>
		[DataMember(Name = "extraSocket")]
		public bool ExtraSocket;

		/// <summary></summary>
		[DataMember(Name = "gem0")]
		public int Gem0;

		/// <summary></summary>
		[DataMember(Name = "gem1")]
		public int Gem1;


		/// <summary></summary>
		[DataMember(Name = "set")]
		public int[] Set
		{
			get { return (SetValue == null ? null : SetValue.ToArray()); }
			set { SetValue = (value == null ? null : new List<int>(value)); }
		}

		/// <summary></summary>
		[IgnoreDataMember]
		public List<int> SetValue;
	}
}
