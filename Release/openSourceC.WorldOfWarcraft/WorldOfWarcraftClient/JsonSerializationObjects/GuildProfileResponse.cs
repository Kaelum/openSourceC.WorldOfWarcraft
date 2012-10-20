using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for GuildProfileResponse.
	/// </summary>
	[DataContract(Name = "response")]
	[Serializable]
	public class GuildProfileResponse : BaseResponse
	{
		/// <summary></summary>
		[DataMember(Name = "achievementPoints")]
		public int AchievementPoints;

		/// <summary></summary>
		[DataMember(Name = "battlegroup")]
		public string Battlegroup;

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
		[DataMember(Name = "realm")]
		public string Realm;

		/// <summary></summary>
		[DataMember(Name = "side")]
		public FactionEnum Side;


		/// <summary></summary>
		[DataMember(Name = "achievements")]
		public ProfileAchievements Achievements;

		/// <summary></summary>
		[IgnoreDataMember]
		public List<GuildChallenge> Challenges;

		/// <summary></summary>
		[DataMember(Name = "challenge")]
		public GuildChallenge[] ChallengesValue
		{
			get { return (Challenges == null ? null : Challenges.ToArray()); }
			set { Challenges = (value == null ? null : new List<GuildChallenge>(value)); }
		}

		/// <summary></summary>
		[DataMember(Name = "emblem")]
		public Emblem Emblem;

		/// <summary></summary>
		[IgnoreDataMember]
		public List<GuildMember> Members;

		/// <summary></summary>
		[DataMember(Name = "members")]
		public GuildMember[] MembersValue
		{
			get { return (Members == null ? null : Members.ToArray()); }
			set { Members = (value == null ? null : new List<GuildMember>(value)); }
		}

		/// <summary></summary>
		[IgnoreDataMember]
		public List<News> News;

		/// <summary></summary>
		[DataMember(Name = "news")]
		public News[] NewsValue
		{
			get { return (News == null ? null : News.ToArray()); }
			set { News = (value == null ? null : new List<News>(value)); }
		}
	}
}
