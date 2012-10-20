using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for ChallengeGroup.
	/// </summary>
	[DataContract(Name = "group")]
	[Serializable]
	public class ChallengeGroup
	{
		/// <summary>This is the <see cref="T:DateTime"/> representation of <see cref="DateValue"/></summary>
		[IgnoreDataMember]
		public DateTime Date;

		/// <summary></summary>
		[DataMember(Name = "date")]
		public string DateValue
		{
			get { return Date.ToString("yyyy-MM-dd'T'HH:mm:ss.fff'Z'"); }
			set { Date = DateTime.ParseExact(value, "yyyy-MM-dd'T'HH:mm:ss.fff'Z'", CultureInfo.InvariantCulture); }
		}

		/// <summary></summary>
		[IgnoreDataMember]
		public FactionEnum Faction;

		/// <summary></summary>
		[DataMember(Name = "faction")]
		public string FactionValue
		{
			get { return Faction.ToString().ToLowerInvariant(); }
			set { Faction = (FactionEnum)Enum.Parse(typeof(FactionEnum), value, true); }
		}

		/// <summary></summary>
		[DataMember(Name = "isRecurring")]
		public bool IsRecurring;

		/// <summary></summary>
		[DataMember(Name = "medal")]
		public string Medal;

		/// <summary></summary>
		[DataMember(Name = "ranking")]
		public int Ranking;

		/// <summary></summary>
		[DataMember(Name = "time")]
		public Time Time;


		/// <summary></summary>
		[IgnoreDataMember]
		public List<Member> Members;

		/// <summary></summary>
		[DataMember(Name = "members")]
		public Member[] MembersValue
		{
			get { return (Members == null ? null : Members.ToArray()); }
			set { Members = (value == null ? null : new List<Member>(value)); }
		}
	}
}
