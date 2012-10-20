using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Xml.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for ArenaTeamSizeEnum.
	/// </summary>
	[DataContract]
	public enum ArenaTeamSizeEnum
	{
		/// <summary>2v2</summary>
		[EnumMember(Value = "2v2")]
		Arena2v2 = 1,

		/// <summary>3v3</summary>
		[EnumMember(Value = "3v3")]
		Arena3v3 = 2,

		/// <summary>5v5</summary>
		[EnumMember(Value = "5v5")]
		Arena5v5 = 3,
	}

	/// <summary>
	///		Summary description for CharacterClassEnum.
	/// </summary>
	[DataContract]
	public enum CharacterClassEnum
	{
		/// <summary>Death Knight</summary>
		DeathKnight = 6,

		/// <summary>Druid</summary>
		Druid = 11,

		/// <summary>Hunter</summary>
		Hunter = 3,

		/// <summary>Mage</summary>
		Mage = 8,

		/// <summary>Monk</summary>
		Monk = 10,

		/// <summary>Paladin</summary>
		Paladin = 2,

		/// <summary>Priest</summary>
		Priest = 5,

		/// <summary>Rogue</summary>
		Rogue = 4,

		/// <summary>Shaman</summary>
		Shaman = 7,

		/// <summary>Warlock</summary>
		Warlock = 9,

		/// <summary>Warrior</summary>
		Warrior = 1,
	}

	/// <summary>
	///		Summary description for CharacterFactionEnum.
	/// </summary>
	[DataContract]
	public enum CharacterFactionEnum
	{
		/// <summary>Alliance</summary>
		Alliance = 0,

		/// <summary>Horde</summary>
		Horde = 1,

		/// <summary>Neutral</summary>
		Neutral = -1,
	}

	/// <summary>
	///		Summary description for CharacterProfileOptionalFieldsEnum.
	/// </summary>
	[DataContract]
	[Flags]
	public enum CharacterProfileOptionalFieldsEnum : long
	{
		/// <summary>All</summary>
		All = -1L,

		/// <summary>None</summary>
		None = 0L,

		/// <summary>
		///		A map of achievement data including completion timestamps and criteria information.
		///	</summary>
		[EnumMember(Value = "achievements")]
		Achievements = 0x00000001L,

		/// <summary>
		///		A map of values that describes the face, features and helm/cloak display
		///		preferences and attributes.
		///	</summary>
		[EnumMember(Value = "appearance")]
		Appearance = 0x00000002L,

		/// <summary>
		///		The activity feed of the character.
		///	</summary>
		[EnumMember(Value = "feed")]
		Feed = 0x00000004L,

		/// <summary>
		///		A summary of the guild that the character belongs to. If the character does not
		///		belong to a guild and this field is requested, this field will not be exposed.
		///	</summary>
		[EnumMember(Value = "guild")]
		Guild = 0x00000008L,

		/// <summary>
		///		A list of all of the combat pets obtained by the character.
		///	</summary>
		[EnumMember(Value = "hunterPets")]
		HunterPets = 0x00000010L,

		/// <summary>
		///		A list of items equipted by the character. Use of this field will also include the
		///		average item level and average item level equipped for the character.
		///	</summary>
		[EnumMember(Value = "items")]
		Items = 0x00000020L,

		/// <summary>
		///		A list of all of the mounts obtained by the character.
		///	</summary>
		[EnumMember(Value = "mounts")]
		Mounts = 0x00000040L,

		/// <summary>
		///		A list of the battle pets obtained by the character.
		///	</summary>
		[EnumMember(Value = "pets")]
		Pets = 0x00000080L,

		/// <summary>
		///		Data about the current battle pet slots on this characters account.
		///	</summary>
		[EnumMember(Value = "petSlots")]
		PetSlots = 0x00000100L,

		/// <summary>
		///		A list of the character's professions. It is important to note that when this
		///		information is retrieved, it will also include the known recipes of each of the
		///		listed professions.
		///	</summary>
		[EnumMember(Value = "professions")]
		Professions = 0x00000200L,

		/// <summary>
		///		A list of raids and bosses indicating raid progression and completedness.
		///	</summary>
		[EnumMember(Value = "progression")]
		Progression = 0x00000400L,

		/// <summary>
		///		A map of pvp information including arena team membership and rated battlegrounds information.
		///	</summary>
		[EnumMember(Value = "pvp")]
		PvP = 0x00000800L,

		/// <summary>
		///		A list of quests completed by the character.
		///	</summary>
		[EnumMember(Value = "quests")]
		Quests = 0x00001000L,

		/// <summary>
		///		A list of the factions that the character has an associated reputation with.
		///	</summary>
		[EnumMember(Value = "reputation")]
		Reputation = 0x00002000L,

		/// <summary>
		///		A map of character attributes and stats.
		///	</summary>
		[EnumMember(Value = "stats")]
		Stats = 0x00004000L,

		/// <summary>
		///		A list of talent structures.
		///	</summary>
		[EnumMember(Value = "talents")]
		Talents = 0x00008000L,

		/// <summary>
		///		A list of the titles obtained by the character including the currently selected
		///		title.
		///	</summary>
		[EnumMember(Value = "titles")]
		Titles = 0x00010000L,
	}

	/// <summary>
	///		Summary description for CharacterRaceEnum.
	///		<para><b>WARNING:</b> Use at your own risk.  The enum elements are hardcoded and may
	///		not correctly reflect the values represented, if Blizzard changes the mappings. Use
	///		<see cref="M:GetCharacterRaces"/> to get the current mappings.</para>
	/// </summary>
	[DataContract]
	public enum CharacterRaceEnum
	{
		/// <summary>Blood Elf</summary>
		[EnumMember]
		BloodElf = 10,

		/// <summary>Draenei</summary>
		[EnumMember]
		Draenei = 11,

		/// <summary>Dwarf</summary>
		[EnumMember]
		Dwarf = 3,

		/// <summary>Gnome</summary>
		[EnumMember]
		Gnome = 7,

		/// <summary>Goblin</summary>
		[EnumMember]
		Goblin = 9,

		/// <summary>Human</summary>
		[EnumMember]
		Human = 1,

		/// <summary>Night Elf</summary>
		[EnumMember]
		NightElf = 4,

		/// <summary>Orc</summary>
		[EnumMember]
		Orc = 2,

		/// <summary>Pandaren (Alliance)</summary>
		[EnumMember]
		PandarenAlliance = 25,

		/// <summary>Pandaren (Horde)</summary>
		[EnumMember]
		PandarenHorde = 26,

		/// <summary>Pandaren (Nuetral)</summary>
		[EnumMember]
		PandarenNuetral = 24,

		/// <summary></summary>
		[EnumMember]
		Tauren = 6,

		/// <summary>Troll</summary>
		[EnumMember]
		Troll = 8,

		/// <summary>Undead</summary>
		[EnumMember]
		Undead = 5,

		/// <summary>Worgen</summary>
		[EnumMember]
		Worgen = 22,
	}

	/// <summary>
	///		Summary description for FactionEnum.
	/// </summary>
	[DataContract]
	public enum FactionEnum
	{
		/// <summary>Alliance</summary>
		[EnumMember]
		Alliance = 0,

		/// <summary>Horde</summary>
		[EnumMember]
		Horde = 1,
	}

	/// <summary>
	///		Summary description for GenderEnum.
	/// </summary>
	[DataContract]
	public enum GenderEnum
	{
		/// <summary>Female</summary>
		[EnumMember]
		Female = 1,

		/// <summary>Male</summary>
		[EnumMember]
		Male = 0,
	}

	/// <summary>
	///		Summary description for GuildProfileOptionalFieldsEnum.
	/// </summary>
	[DataContract]
	[Flags]
	public enum GuildProfileOptionalFieldsEnum
	{
		/// <summary>All</summary>
		All = -1,

		/// <summary>None</summary>
		None = 0,

		/// <summary>
		///		A set of data structures that describe the achievements earned by the guild.
		///	</summary>
		[EnumMember(Value = "achievements")]
		Achievements = 0x0001,

		/// <summary>
		///		The top 3 challenge mode guild run times for each challenge mode map.
		///	</summary>
		[EnumMember(Value = "challenge")]
		Challenge = 0x0002,

		/// <summary>
		///		A list of characters that are a member of the guild.
		///	</summary>
		[EnumMember(Value = "members")]
		Members = 0x0004,

		/// <summary>
		///		A set of data structures that describe the news feed of the guild.
		///	</summary>
		[EnumMember(Value = "news")]
		News = 0x0008,
	}

	/// <summary>
	///		Summary description for ItemClassEnum.
	/// </summary>
	[DataContract]
	public enum ItemClassEnum
	{
		/// <summary>Armor</summary>
		[EnumMember]
		Armor = 4,

		/// <summary>Consumable</summary>
		[EnumMember]
		Consumable = 0,

		/// <summary>Container</summary>
		[EnumMember]
		Container = 1,

		/// <summary>Gem</summary>
		[EnumMember]
		Gem = 3,

		/// <summary>Glyph</summary>
		[EnumMember]
		Glyph = 16,

		/// <summary>Key</summary>
		[EnumMember]
		Key = 13,

		/// <summary>Miscellaneous</summary>
		[EnumMember]
		Miscellaneous = 15,

		/// <summary>Projectile</summary>
		[EnumMember]
		Projectile = 6,

		/// <summary>Quest</summary>
		[EnumMember]
		Quest = 12,

		/// <summary>Quiver</summary>
		[EnumMember]
		Quiver = 11,

		/// <summary>Reagent</summary>
		[EnumMember]
		Reagent = 5,

		/// <summary>Recipe</summary>
		[EnumMember]
		Recipe = 9,

		/// <summary>Trade Goods</summary>
		[EnumMember]
		TradeGoods = 7,

		/// <summary>Weapon</summary>
		[EnumMember]
		Weapon = 2,
	}

	/// <summary>
	///		Summary description for PowerTypeEnum.
	/// </summary>
	[DataContract]
	public enum PowerTypeEnum
	{
		/// <summary>Energy</summary>
		[EnumMember(Value = "energy")]
		Energy = 1,

		/// <summary>Focus</summary>
		[EnumMember(Value = "focus")]
		Focus = 2,

		/// <summary>Mana</summary>
		[EnumMember(Value = "mana")]
		Mana = 3,

		/// <summary>Rage</summary>
		[EnumMember(Value = "rage")]
		Rage = 4,

		/// <summary>Runic Power</summary>
		[EnumMember(Value = "runic-power")]
		RunicPower = 5,
	}

	/// <summary>
	///		Summary description for PvPStatusEnum.
	/// </summary>
	[DataContract]
	public enum PvPStatusEnum
	{
		/// <summary>Active</summary>
		[EnumMember]
		Active = 2,

		/// <summary>Concluded</summary>
		[EnumMember]
		Concluded = 3,

		/// <summary>Idle</summary>
		[EnumMember]
		Idle = 0,

		/// <summary>Populating</summary>
		[EnumMember]
		Populating = 1,

		/// <summary>Unknown</summary>
		[EnumMember]
		Unknown = -1,
	}

	/// <summary>
	///		Summary description for TimeLeftEnum.
	/// </summary>
	[DataContract]
	public enum TimeLeftEnum
	{
		/// <summary>Long</summary>
		[EnumMember(Value = "LONG")]
		Long = 3,

		/// <summary>Medium</summary>
		[EnumMember(Value = "MEDIUM")]
		Medium = 2,

		/// <summary>Short</summary>
		[EnumMember(Value = "SHORT")]
		Short = 1,

		/// <summary>Very Long</summary>
		[EnumMember(Value = "VERY_LONG")]
		VeryLong = 4,
	}
}
