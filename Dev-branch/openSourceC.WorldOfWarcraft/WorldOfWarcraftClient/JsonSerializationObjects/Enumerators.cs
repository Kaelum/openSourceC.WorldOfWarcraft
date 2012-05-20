using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Xml.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for ArenaTeamSizeEnum.
	/// </summary>
	public enum ArenaTeamSizeEnum
	{
		/// <summary>2v2</summary>
		Arena2v2 = 1,

		/// <summary>3v3</summary>
		Arena3v3 = 2,

		/// <summary>5v5</summary>
		Arena5v5 = 3,
	}

	/// <summary>
	///		Summary description for CharacterClassEnum.
	/// </summary>
	public enum CharacterClassEnum
	{
		/// <summary></summary>
		DeathKnight = 6,

		/// <summary></summary>
		Druid = 11,

		/// <summary></summary>
		Hunter = 3,

		/// <summary></summary>
		Mage = 8,

		/// <summary></summary>
		Paladin = 2,

		/// <summary></summary>
		Priest = 5,

		/// <summary></summary>
		Rogue = 4,

		/// <summary></summary>
		Shaman = 7,

		/// <summary></summary>
		Warlock = 9,

		/// <summary></summary>
		Warrior = 1,
	}

	/// <summary>
	///		Summary description for CharacterProfileOptionalFieldsEnum.
	/// </summary>
	[Flags]
	public enum CharacterProfileOptionalFieldsEnum
	{
		/// <summary>
		///		None
		///	</summary>
		None = 0x0000,

		/// <summary>
		///		A map of achievement data including completion timestamps and criteria information.
		///	</summary>
		Achievements = 0x0001,

		/// <summary>
		///		A map of values that describes the face, features and helm/cloak display
		///		preferences and attributes.
		///	</summary>
		Appearance = 0x0002,

		/// <summary>
		///		A list of all of the non-combat pets obtained by the character.
		///	</summary>
		Companions = 0x0004,

		/// <summary>
		///		The activity feed of the character.
		///	</summary>
		Feed = 0x0008,

		/// <summary>
		///		A summary of the guild that the character belongs to. If the character does not
		///		belong to a guild and this field is requested, this field will not be exposed.
		///	</summary>
		Guild = 0x0010,

		/// <summary>
		///		A list of items equipted by the character. Use of this field will also include the
		///		average item level and average item level equipped for the character.
		///	</summary>
		Items = 0x0020,

		/// <summary>
		///		A list of all of the mounts obtained by the character.
		///	</summary>
		Mounts = 0x0040,

		/// <summary>
		///		A list of all of the combat pets obtained by the character.
		///	</summary>
		Pets = 0x0080,

		/// <summary>
		///		A list of the character's professions. It is important to note that when this
		///		information is retrieved, it will also include the known recipes of each of the
		///		listed professions.
		///	</summary>
		Professions = 0x0100,

		/// <summary>
		///		A list of raids and bosses indicating raid progression and completedness.
		///	</summary>
		Progression = 0x0200,

		/// <summary>
		///		A map of pvp information including arena team membership and rated battlegrounds information.
		///	</summary>
		PvP = 0x0400,

		/// <summary>
		///		A list of quests completed by the character.
		///	</summary>
		Quests = 0x0800,

		/// <summary>
		///		A list of the factions that the character has an associated reputation with.
		///	</summary>
		Reputation = 0x1000,

		/// <summary>
		///		A map of character attributes and stats.
		///	</summary>
		Stats = 0x2000,

		/// <summary>
		///		A list of talent structures.
		///	</summary>
		Talents = 0x4000,

		/// <summary>
		///		A list of the titles obtained by the character including the currently selected
		///		title.
		///	</summary>
		Titles = 0x8000,
	}

	/// <summary>
	///		Summary description for CharacterRaceEnum.
	///		<para><b>WARNING:</b> Use at your own risk.  The enum elements are hardcoded and may
	///		not correctly reflect the values represented, if Blizzard changes the mappings. Use
	///		<see cref="M:GetCharacterRaces"/> to get the current mappings.</para>
	/// </summary>
	public enum CharacterRaceEnum
	{
		/// <summary></summary>
		AlliancePandaren = 25,

		/// <summary></summary>
		BloodElf = 10,

		/// <summary></summary>
		Draenei = 11,

		/// <summary></summary>
		Dwarf = 3,

		/// <summary></summary>
		Gnome = 7,

		/// <summary></summary>
		Goblin = 9,

		/// <summary></summary>
		HordePandaren = 26,

		/// <summary></summary>
		Human = 1,

		/// <summary></summary>
		NightElf = 4,

		/// <summary></summary>
		Orc = 2,

		/// <summary></summary>
		Tauren = 6,

		/// <summary></summary>
		Troll = 8,

		/// <summary></summary>
		UnalignedPandaren = 24,

		/// <summary></summary>
		Undead = 5,

		/// <summary></summary>
		Worgen = 22,
	}

	/// <summary>
	///		Summary description for FactionEnum.
	/// </summary>
	public enum FactionEnum
	{
		/// <summary></summary>
		Alliance = 0,

		/// <summary></summary>
		Horde = 1,
	}

	/// <summary>
	///		Summary description for GenderEnum.
	/// </summary>
	public enum GenderEnum
	{
		/// <summary></summary>
		Male = 0,

		/// <summary></summary>
		Female = 1,
	}

	/// <summary>
	///		Summary description for GuildProfileOptionalFieldsEnum.
	/// </summary>
	[Flags]
	public enum GuildProfileOptionalFieldsEnum
	{
		/// <summary>
		///		None
		///	</summary>
		None = 0x0000,

		/// <summary>
		///		A set of data structures that describe the achievements earned by the guild.
		///	</summary>
		Achievements = 0x0001,

		/// <summary>
		///		A list of characters that are a member of the guild.
		///	</summary>
		Members = 0x0002,

		/// <summary>
		///		A set of data structures that describe the news feed of the guild.
		///	</summary>
		News = 0x0004,
	}

	/// <summary>
	///		Summary description for ItemClassEnum.
	/// </summary>
	public enum ItemClassEnum
	{
		/// <summary></summary>
		Consumable = 0,

		/// <summary></summary>
		Container = 1,

		/// <summary></summary>
		Weapon = 2,

		/// <summary></summary>
		Gem = 3,

		/// <summary></summary>
		Armor = 4,

		/// <summary></summary>
		Reagent = 5,

		/// <summary></summary>
		Projectile = 6,

		/// <summary></summary>
		TradeGoods = 7,

		/// <summary></summary>
		Recipe = 9,

		/// <summary></summary>
		Quiver = 11,

		/// <summary></summary>
		Quest = 12,

		/// <summary></summary>
		Key = 13,

		/// <summary></summary>
		Miscellaneous = 15,

		/// <summary></summary>
		Glyph = 16,
	}

	/// <summary>
	///		Summary description for PowerTypeEnum.
	/// </summary>
	public enum PowerTypeEnum
	{
		/// <summary>Energy</summary>
		Energy = 1,

		/// <summary>Focus</summary>
		Focus = 2,

		/// <summary>Mana</summary>
		Mana = 3,

		/// <summary>Rage</summary>
		Rage = 4,

		/// <summary>Runic Power</summary>
		RunicPower = 5,
	}

	/// <summary>
	///		Summary description for PvPStatusEnum.
	/// </summary>
	public enum PvPStatusEnum
	{
		/// <summary></summary>
		Unknown = -1,

		/// <summary></summary>
		Idle = 0,

		/// <summary></summary>
		Populating = 1,

		/// <summary></summary>
		Active = 2,

		/// <summary></summary>
		Concluded = 3,
	}

	/// <summary>
	///		Summary description for TimeLeftEnum.
	/// </summary>
	public enum TimeLeftEnum
	{
		/// <summary>Long</summary>
		[DataMember(Name = "LONG")]
		Long = 3,

		/// <summary>Medium</summary>
		[DataMember(Name = "MEDIUM")]
		Medium = 2,

		/// <summary>Short</summary>
		[DataMember(Name = "SHORT")]
		Short = 1,

		/// <summary>Very Long</summary>
		[DataMember(Name = "VERY_LONG")]
		VeryLong = 4,
	}
}
