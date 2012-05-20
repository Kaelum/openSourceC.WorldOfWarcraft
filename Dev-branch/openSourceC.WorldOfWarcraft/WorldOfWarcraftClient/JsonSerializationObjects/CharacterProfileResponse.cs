﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for CharacterProfileResponse.
	/// </summary>
	[DataContract(Name = "response")]
	[Serializable]
	public class CharacterProfileResponse : BaseResponse
	{
		/// <summary></summary>
		[DataMember(Name = "achievementPoints")]
		public int AchievementPoints;

		/// <summary></summary>
		[DataMember(Name = "battlegroup")]
		public string Battlegroup;

		/// <summary></summary>
		[DataMember(Name = "class")]
		public CharacterClassEnum Class;

		/// <summary></summary>
		[DataMember(Name = "gender")]
		public GenderEnum Gender;

		/// <summary>This is the <see cref="T:DateTime"/> representation of <see cref="LastModifiedValue"/></summary>
		[IgnoreDataMember]
		public DateTime LastModified;

		/// <summary></summary>
		[DataMember(Name = "lastModified")]
		public long LastModifiedValue
		{
			get { return LastModified.ToUnixTime(); }
			set { LastModified = value.ToDateTime(); }
		}

		/// <summary></summary>
		[DataMember(Name = "level")]
		public int Level;

		/// <summary></summary>
		[DataMember(Name = "name")]
		public string Name;

		/// <summary></summary>
		[DataMember(Name = "race")]
		public CharacterRaceEnum Race;

		/// <summary></summary>
		[DataMember(Name = "realm")]
		public string Realm;

		/// <summary></summary>
		[DataMember(Name = "thumbnail")]
		public string Thumbnail;


		/// <summary></summary>
		[DataMember(Name = "achievements")]
		public ProfileAchievements Achievements;

		/// <summary></summary>
		[DataMember(Name = "appearance")]
		public CharacterAppearance Appearance;

		/// <summary></summary>
		[IgnoreDataMember]
		public List<int> Companions;

		/// <summary></summary>
		[DataMember(Name = "companions")]
		public int[] CompanionsValue
		{
			get { return (Companions == null ? null : Companions.ToArray()); }
			set { Companions = (value == null ? null : new List<int>(value)); }
		}

		/// <summary></summary>
		[IgnoreDataMember]
		public List<CharacterFeed> Feed;

		/// <summary></summary>
		[DataMember(Name = "feed")]
		public CharacterFeed[] FeedValue
		{
			get { return (Feed == null ? null : Feed.ToArray()); }
			set { Feed = (value == null ? null : new List<CharacterFeed>(value)); }
		}

		/// <summary></summary>
		[DataMember(Name = "guild")]
		public Guild Guild;

		/// <summary></summary>
		[DataMember(Name = "items")]
		public CharacterItems Items;

		/// <summary></summary>
		[IgnoreDataMember]
		public List<int> Mounts;

		/// <summary></summary>
		[DataMember(Name = "mounts")]
		public int[] MountsValue
		{
			get { return (Mounts == null ? null : Mounts.ToArray()); }
			set { Mounts = (value == null ? null : new List<int>(value)); }
		}

		/// <summary></summary>
		[IgnoreDataMember]
		public List<Pet> Pets;

		/// <summary></summary>
		[DataMember(Name = "pets")]
		public Pet[] PetsValue
		{
			get { return (Pets == null ? null : Pets.ToArray()); }
			set { Pets = (value == null ? null : new List<Pet>(value)); }
		}

		/// <summary></summary>
		[DataMember(Name = "professions")]
		public CharacterProfessions Professions;

		/// <summary></summary>
		[DataMember(Name = "progression")]
		public CharacterProgression Progression;

		/// <summary></summary>
		[DataMember(Name = "pvp")]
		public CharacterPvP PvP;

		/// <summary></summary>
		[IgnoreDataMember]
		public List<int> Quests;

		/// <summary></summary>
		[DataMember(Name = "quests")]
		public int[] QuestsValue
		{
			get { return (Quests == null ? null : Quests.ToArray()); }
			set { Quests = (value == null ? null : new List<int>(value)); }
		}

		/// <summary></summary>
		[DataMember(Name = "reputation")]
		public List<CharacterReputation> Reputation;

		/// <summary></summary>
		[DataMember(Name = "stats")]
		public CharacterStats Stats;

		/// <summary></summary>
		[IgnoreDataMember]
		public List<Talent> Talents;

		/// <summary></summary>
		[DataMember(Name = "talents")]
		public Talent[] TalentsValue
		{
			get { return (Talents == null ? null : Talents.ToArray()); }
			set { Talents = (value == null ? null : new List<Talent>(value)); }
		}

		/// <summary></summary>
		[IgnoreDataMember]
		public List<CharacterTitle> Titles;

		/// <summary></summary>
		[DataMember(Name = "titles")]
		public CharacterTitle[] TitlesValue
		{
			get { return (Titles == null ? null : Titles.ToArray()); }
			set { Titles = (value == null ? null : new List<CharacterTitle>(value)); }
		}
	}
}
