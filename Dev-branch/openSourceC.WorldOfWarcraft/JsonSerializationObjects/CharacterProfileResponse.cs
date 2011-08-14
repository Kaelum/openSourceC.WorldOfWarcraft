using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace openSourceC.WorldOfWarcraft
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
			get { return WowJavaScriptConverter.ConvertDateTimeToLong(LastModifiedValue); }
			set { LastModifiedValue = WowJavaScriptConverter.ConvertLongToDateTime(value); }
		}

		/// <summary></summary>
		[ScriptIgnore]
		public DateTime LastModifiedValue { get; set; }

		/// <summary></summary>
		public string Name;

		/// <summary></summary>
		public string Realm;

		/// <summary></summary>
		public int Class;

		/// <summary></summary>
		public int Race;

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
