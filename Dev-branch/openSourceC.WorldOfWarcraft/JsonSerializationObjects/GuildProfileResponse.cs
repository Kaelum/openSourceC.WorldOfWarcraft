using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace openSourceC.WorldOfWarcraft
{
	/// <summary>
	///		Summary description for GuildProfileResponse.
	/// </summary>
	[Serializable]
	public class GuildProfileResponse
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
		public int Level;

		/// <summary></summary>
		public int Side;

		/// <summary></summary>
		public int AchievementPoints;


		/// <summary></summary>
		public Achievements Achievements;

		/// <summary></summary>
		public List<Member> Members;

		/// <summary></summary>
		public Emblem Emblem;
	}
}
