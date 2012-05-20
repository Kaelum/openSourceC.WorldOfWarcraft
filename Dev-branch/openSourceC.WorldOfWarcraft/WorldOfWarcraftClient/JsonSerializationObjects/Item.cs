using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for Item.
	/// </summary>
	[DataContract(Name = "item")]
	[Serializable]
	public class Item
	{
		/// <summary></summary>
		[DataMember(Name = "icon")]
		public string Icon;

		/// <summary></summary>
		[DataMember(Name = "id")]
		public int Id;

		/// <summary></summary>
		[DataMember(Name = "name")]
		public string Name;

		/// <summary></summary>
		[DataMember(Name = "quality")]
		public int Quality;


		/// <summary></summary>
		[DataMember(Name = "tooltipParams")]
		public TooltipParameters TooltipParams;
	}
}
