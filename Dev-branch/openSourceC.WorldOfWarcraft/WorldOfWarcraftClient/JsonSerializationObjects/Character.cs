using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for Character.
	/// </summary>
	[DataContract(Name = "character")]
	[Serializable]
	public class Character
	{
		/// <summary></summary>
		[DataMember(Name = "achievementpoints")]
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
	}
}
