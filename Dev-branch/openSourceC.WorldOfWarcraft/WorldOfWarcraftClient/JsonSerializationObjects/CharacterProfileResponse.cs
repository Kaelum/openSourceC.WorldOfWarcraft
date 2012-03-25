using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for CharacterProfileResponse.
	/// </summary>
	[Serializable]
	public class CharacterProfileResponse
	{
		/// <summary></summary>
		public long LastModified
		{
			get { return LastModifiedValue.ToUnixTime(); }
			set { LastModifiedValue = value.ToDateTime(); }
		}

		/// <summary>This is the <see cref="T:DateTime"/> representation of <see cref="LastModified"/></summary>
		[ScriptIgnore]
		public DateTime LastModifiedValue { get; set; }

		/// <summary></summary>
		public string Name;

		/// <summary></summary>
		public string Realm;

		/// <summary></summary>
		public int Class
		{
			get { return (int)ClassValue; }
			set { ClassValue = (CharacterClassEnum)value; }
		}

		/// <summary>
		///		This is the <see cref="T:CharacterClassEnum"/> representation of <see cref="Class"/>.
		///		<para><b>WARNING:</b> Use at your own risk.  The enum elements are hardcoded and
		///		may not correctly reflect the values represented, if Blizzard changes the mappings.</para>
		///	</summary>
		[ScriptIgnore]
		public CharacterClassEnum ClassValue { get; set; }

		/// <summary></summary>
		public int Race
		{
			get { return (int)RaceValue; }
			set { RaceValue = (CharacterRaceEnum)value; }
		}

		/// <summary>
		///		This is the <see cref="T:CharacterRaceEnum"/> representation of <see cref="Race"/>.
		///		<para><b>WARNING:</b> Use at your own risk.  The enum elements are hardcoded and
		///		may not correctly reflect the values represented, if Blizzard changes the mappings.</para>
		///	</summary>
		[ScriptIgnore]
		public CharacterRaceEnum RaceValue { get; set; }

		/// <summary></summary>
		public int Gender;

		/// <summary></summary>
		public int Level;

		/// <summary></summary>
		public int AchievementPoints;

		/// <summary></summary>
		public string Thumbnail;


		/// <summary></summary>
		public Guild Guild;

		/// <summary></summary>
		public CharacterItems Items;

		/// <summary></summary>
		public CharacterStats Stats;

		/// <summary></summary>
		public CharacterProfessions Professions;

		/// <summary></summary>
		public List<CharacterReputation> Reputation;

		/// <summary></summary>
		public List<CharacterTitle> Titles;

		/// <summary></summary>
		public Achievements Achievements;

		/// <summary></summary>
		public List<Talent> Talents;

		/// <summary></summary>
		public CharacterAppearance Appearance;

		/// <summary></summary>
		public List<int> Mounts;

		/// <summary></summary>
		public List<int> Companions;

		/// <summary></summary>
		public CharacterProgression Progression;
	}
}
