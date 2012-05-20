using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for Item.
	/// </summary>
	[DataContract(Name = "characterItem")]
	[Serializable]
	public class CharacterItem : Item
	{
		/// <summary></summary>
		[DataMember(Name = "transmogItem")]
		public int? TransmogItem;
	}
}
