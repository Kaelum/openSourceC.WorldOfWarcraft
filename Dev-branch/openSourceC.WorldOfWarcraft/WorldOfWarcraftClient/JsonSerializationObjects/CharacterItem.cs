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
		[DataMember(Name = "armor")]
		public int? Armor;

		/// <summary></summary>
		[DataMember(Name = "itemLevel")]
		public int? ItemLevel;

		/// <summary></summary>
		[DataMember(Name = "transmogItem")]
		public int? TransmogItem;


		/// <summary></summary>
		[IgnoreDataMember]
		public List<CharacterItemStat> Stats;

		/// <summary></summary>
		[DataMember(Name = "stats")]
		public CharacterItemStat[] StatsValue
		{
			get { return (Stats == null ? null : Stats.ToArray()); }
			set { Stats = (value == null ? null : new List<CharacterItemStat>(value)); }
		}

		/// <summary></summary>
		[DataMember(Name = "weaponInfo")]
		public WeaponInfo WeaponInfo;
	}
}
