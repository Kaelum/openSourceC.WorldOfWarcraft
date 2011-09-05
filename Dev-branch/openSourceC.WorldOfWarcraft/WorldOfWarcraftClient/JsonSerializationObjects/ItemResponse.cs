using System;
using System.Collections.Generic;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for ItemResponse.
	/// </summary>
	[Serializable]
	public class ItemResponse
	{
		/// <summary></summary>
		public int Id;

		/// <summary></summary>
		public int DisenchantingSkillRank;

		/// <summary></summary>
		public string Description;

		/// <summary></summary>
		public string Name;

		/// <summary></summary>
		public string Icon;

		/// <summary></summary>
		public int Stackable;

		/// <summary></summary>
		public int ItemBind;

		/// <summary></summary>
		public List<BonusStats> BonusStats;

		/// <summary></summary>
		public List<ItemSpell> ItemSpells;

		/// <summary></summary>
		public long BuyPrice;

		/// <summary></summary>
		public int ItemClass;

		/// <summary></summary>
		public int ItemSubClass;

		/// <summary></summary>
		public int ContainerSlots;

		/// <summary></summary>
		public WeaponInfo WeaponInfo;

		/// <summary></summary>
		public int InventoryType;

		/// <summary></summary>
		public bool Equippable;

		/// <summary></summary>
		public int ItemLevel;

		/// <summary></summary>
		public int MaxCount;

		/// <summary></summary>
		public int MaxDurability;

		/// <summary></summary>
		public int MinFactionId;

		/// <summary></summary>
		public int MinReputation;

		/// <summary></summary>
		public int Quality;

		/// <summary></summary>
		public int SellPrice;

		/// <summary></summary>
		public int RequiredSkill;

		/// <summary></summary>
		public int RequiredLevel;

		/// <summary></summary>
		public int RequiredSkillRank;

		/// <summary></summary>
		public SocketInfo SocketInfo;

		/// <summary></summary>
		public ItemSource ItemSource;

		/// <summary></summary>
		public int BaseArmor;

		/// <summary></summary>
		public bool HasSockets;

		/// <summary></summary>
		public bool IsAuctionable;
	}
}
