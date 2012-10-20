using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for News.
	/// </summary>
	[DataContract(Name = "news")]
	[Serializable]
	public class News
	{
		/// <summary></summary>
		[DataMember(Name = "achievement")]
		public AchievementResponse achievement;

		/// <summary></summary>
		[DataMember(Name = "character")]
		public string Character;

		/// <summary></summary>
		[DataMember(Name = "itemId")]
		public int? ItemId;

		/// <summary>This is the <see cref="T:DateTime"/> representation of <see cref="TimestampValue"/></summary>
		[IgnoreDataMember]
		public DateTime Timestamp;

		/// <summary></summary>
		[DataMember(Name = "timestamp")]
		public long TimestampValue
		{
			get { return Timestamp.ToUnixTime(); }
			set { Timestamp = value.ToDateTime(); }
		}

		/// <summary></summary>
		[DataMember(Name = "type")]
		public string Type;
	}
}
