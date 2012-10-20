using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for CharacterFeed.
	/// </summary>
	[DataContract(Name = "characterFeed")]
	[Serializable]
	public class CharacterFeed
	{
		/// <summary></summary>
		[DataMember(Name = "featOfStrength")]
		public bool FeatOfStrength;

		/// <summary></summary>
		[DataMember(Name = "itemId")]
		public int? ItemId;

		/// <summary></summary>
		[DataMember(Name = "name")]
		public string Name;

		/// <summary></summary>
		[DataMember(Name = "quantity")]
		public int? Quantity;

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


		/// <summary></summary>
		[DataMember(Name = "achievement")]
		public CharacterFeedAchievement Achievement;

		/// <summary></summary>
		[DataMember(Name = "criteria")]
		public Criteria Criteria;
	}
}
