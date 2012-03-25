using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for Character.
	/// </summary>
	[Serializable]
	public class Character
	{
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
	}
}
