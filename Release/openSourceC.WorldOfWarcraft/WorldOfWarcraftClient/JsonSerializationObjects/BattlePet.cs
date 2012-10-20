using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for BattlePet.
	/// </summary>
	[DataContract(Name = "pet")]
	[Serializable]
	public class BattlePet
	{
		/// <summary></summary>
		[DataMember(Name = "battlePetId")]
		public int BattlePetId;

		/// <summary></summary>
		[DataMember(Name = "canBattle")]
		public bool CanBattle;

		/// <summary></summary>
		[DataMember(Name = "creatureId")]
		public int CreatureId;

		/// <summary></summary>
		[DataMember(Name = "creatureName")]
		public string CreatureName;

		/// <summary></summary>
		[DataMember(Name = "icon")]
		public string Icon;

		/// <summary></summary>
		[DataMember(Name = "isFavorite")]
		public bool IsFavorite;

		/// <summary></summary>
		[DataMember(Name = "itemId")]
		public int ItemId;

		/// <summary></summary>
		[DataMember(Name = "name")]
		public string Name;

		/// <summary></summary>
		[DataMember(Name = "qualityId")]
		public int QualityId;

		/// <summary></summary>
		[DataMember(Name = "spellId")]
		public int SpellId;


		/// <summary></summary>
		[DataMember(Name = "stats")]
		public BattlePetStatsResponse Stats;
	}
}
