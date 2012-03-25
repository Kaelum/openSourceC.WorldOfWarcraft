using System;

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
	///		<para><b>WARNING:</b> Use at your own risk.  The enum elements are hardcoded and may
	///		not correctly reflect the values represented, if Blizzard changes the mappings. Use
	///		<see cref="M:GetCharacterClasses"/> to get the current mappings.</para>
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
		///		A summary of the guild that the character belongs to. If the character does not
		///		belong to a guild and this field is requested, this field will not be exposed.
		///	</summary>
		Guild = 0x0001,

		/// <summary>
		///		A map of character attributes and stats.
		///	</summary>
		Stats = 0x0002,

		/// <summary>
		///		A list of talent structures.
		///	</summary>
		Talents = 0x0004,

		/// <summary>
		///		A list of items equipted by the character. Use of this field will also include the
		///		average item level and average item level equipped for the character.
		///	</summary>
		Items = 0x0008,

		/// <summary>
		///		A list of the factions that the character has an associated reputation with.
		///	</summary>
		Reputation = 0x0010,

		/// <summary>
		///		A list of the titles obtained by the character including the currently selected
		///		title.
		///	</summary>
		Titles = 0x0020,

		/// <summary>
		///		A list of the character's professions. It is important to note that when this
		///		information is retrieved, it will also include the known recipes of each of the
		///		listed professions.
		///	</summary>
		Professions = 0x0040,

		/// <summary>
		///		A map of values that describes the face, features and helm/cloak display
		///		preferences and attributes.
		///	</summary>
		Appearance = 0x0080,

		/// <summary>
		///		A list of all of the non-combat pets obtained by the character.
		///	</summary>
		Companions = 0x0100,

		/// <summary>
		///		A list of all of the mounts obtained by the character.
		///	</summary>
		Mounts = 0x0200,

		/// <summary>
		///		A list of all of the combat pets obtained by the character.
		///	</summary>
		Pets = 0x0400,

		/// <summary>
		///		A map of achievement data including completion timestamps and criteria information.
		///	</summary>
		Achievements = 0x0800,

		/// <summary>
		///		A list of raids and bosses indicating raid progression and completedness.
		///	</summary>
		Progression = 0x1000,
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
		Undead = 5,

		/// <summary></summary>
		Worgen = 22,
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
		///		A list of characters that are a member of the guild.
		///	</summary>
		Members = 0x0001,

		/// <summary>
		///		A set of data structures that describe the achievements earned by the guild.
		///	</summary>
		Achievements = 0x0002,
	}
}
