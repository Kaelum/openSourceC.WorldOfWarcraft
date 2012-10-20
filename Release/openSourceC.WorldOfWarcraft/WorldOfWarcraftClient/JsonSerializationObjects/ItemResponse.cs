using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for ItemResponse.
	/// </summary>
	[DataContract(Name = "response")]
	[Serializable]
	public class ItemResponse : BaseResponse
	{
		/// <summary></summary>
		[DataMember(Name = "armor")]
		public int Armor;

		/// <summary></summary>
		[DataMember(Name = "baseArmor")]
		public int BaseArmor;

		/// <summary></summary>
		[DataMember(Name = "buyPrice")]
		public long BuyPrice;

		/// <summary></summary>
		[DataMember(Name = "containerSlots")]
		public int ContainerSlots;

		/// <summary></summary>
		[DataMember(Name = "description")]
		public string Description;

		/// <summary></summary>
		[DataMember(Name = "disenchantingSkillRank")]
		public int DisenchantingSkillRank;

		/// <summary></summary>
		[DataMember(Name = "displayInfoId")]
		public int DisplayInfoId;

		/// <summary></summary>
		[DataMember(Name = "equippable")]
		public bool Equippable;

		/// <summary></summary>
		[DataMember(Name = "hasSockets")]
		public bool HasSockets;

		/// <summary></summary>
		[DataMember(Name = "icon")]
		public string Icon;

		/// <summary></summary>
		[DataMember(Name = "id")]
		public int Id;

		/// <summary></summary>
		[DataMember(Name = "inventoryType")]
		public int InventoryType;

		/// <summary></summary>
		[DataMember(Name = "isAuctionable")]
		public bool IsAuctionable;

		/// <summary></summary>
		[DataMember(Name = "itemBind")]
		public int ItemBind;

		/// <summary></summary>
		[DataMember(Name = "itemClass")]
		public ItemClassEnum ItemClass;

		/// <summary></summary>
		[DataMember(Name = "itemLevel")]
		public int ItemLevel;

		/// <summary></summary>
		[DataMember(Name = "itemSubClass")]
		public int ItemSubClass;

		/// <summary></summary>
		[DataMember(Name = "maxCount")]
		public int MaxCount;

		/// <summary></summary>
		[DataMember(Name = "maxDurability")]
		public int MaxDurability;

		/// <summary></summary>
		[DataMember(Name = "minFactionId")]
		public int MinFactionId;

		/// <summary></summary>
		[DataMember(Name = "minReputation")]
		public int MinReputation;

		/// <summary></summary>
		[DataMember(Name = "name")]
		public string Name;

		/// <summary></summary>
		[DataMember(Name = "nameDescription")]
		public string NameDescription;

		/// <summary></summary>
		[DataMember(Name = "nameDescriptionColor")]
		public string NameDescriptionColor;

		/// <summary></summary>
		[DataMember(Name = "quality")]
		public int Quality;

		/// <summary></summary>
		[DataMember(Name = "requiredLevel")]
		public int RequiredLevel;

		/// <summary></summary>
		[DataMember(Name = "requiredSkill")]
		public int RequiredSkill;

		/// <summary></summary>
		[DataMember(Name = "requiredSkillRank")]
		public int RequiredSkillRank;

		/// <summary></summary>
		[DataMember(Name = "sellPrice")]
		public int SellPrice;

		/// <summary></summary>
		[DataMember(Name = "stackable")]
		public int Stackable;




		/// <summary></summary>
		[IgnoreDataMember]
		public List<CharacterClassEnum> AllowableClasses;

		/// <summary></summary>
		[DataMember(Name = "allowableClasses")]
		public CharacterClassEnum[] AllowableClassesValue
		{
			get { return (AllowableClasses == null ? null : AllowableClasses.ToArray()); }
			set { AllowableClasses = (value == null ? null : new List<CharacterClassEnum>(value)); }
		}

		/// <summary></summary>
		[IgnoreDataMember]
		public List<BonusStats> BonusStats;

		/// <summary></summary>
		[DataMember(Name = "bonusStats")]
		public BonusStats[] BonusStatsValue
		{
			get { return (BonusStats == null ? null : BonusStats.ToArray()); }
			set { BonusStats = (value == null ? null : new List<BonusStats>(value)); }
		}

		/// <summary></summary>
		[DataMember(Name = "itemSet")]
		public ItemSetResponse ItemSet;

		/// <summary></summary>
		[DataMember(Name = "itemSource")]
		public ItemSource ItemSource;

		/// <summary></summary>
		[IgnoreDataMember]
		public List<ItemSpell> ItemSpells;

		/// <summary></summary>
		[DataMember(Name = "itemSpells")]
		public ItemSpell[] ItemSpellsValue
		{
			get { return (ItemSpells == null ? null : ItemSpells.ToArray()); }
			set { ItemSpells = (value == null ? null : new List<ItemSpell>(value)); }
		}

		/// <summary></summary>
		[DataMember(Name = "socketInfo")]
		public SocketInfo SocketInfo;

		/// <summary></summary>
		[DataMember(Name = "weaponInfo")]
		public WeaponInfo WeaponInfo;
	}
}
