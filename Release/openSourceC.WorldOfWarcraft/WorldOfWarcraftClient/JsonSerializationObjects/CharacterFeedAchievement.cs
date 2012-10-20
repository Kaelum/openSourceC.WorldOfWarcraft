using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for CharacterFeedAchievement.
	/// </summary>
	[DataContract(Name = "characterFeedAchievement")]
	[Serializable]
	public class CharacterFeedAchievement
	{
		/// <summary></summary>
		[DataMember(Name = "accountWide")]
		public bool AccountWide;

		/// <summary></summary>
		[DataMember(Name = "description")]
		public string Description;

		/// <summary></summary>
		[DataMember(Name = "icon")]
		public string Icon;

		/// <summary></summary>
		[DataMember(Name = "id")]
		public int Id;

		/// <summary></summary>
		[DataMember(Name = "points")]
		public int Points;

		/// <summary></summary>
		[DataMember(Name = "reward")]
		public string Reward;

		/// <summary></summary>
		[DataMember(Name = "title")]
		public string Title;


		/// <summary></summary>
		[IgnoreDataMember]
		public List<Criteria> Criteria;

		/// <summary></summary>
		[DataMember(Name = "criteria")]
		public Criteria[] CriteriaValue
		{
			get { return (Criteria == null ? null : Criteria.ToArray()); }
			set { Criteria = (value == null ? null : new List<Criteria>(value)); }
		}

		/// <summary></summary>
		[IgnoreDataMember]
		public List<Item> RewardItems;

		/// <summary></summary>
		[DataMember(Name = "rewardItems")]
		public Item[] RewardItemsValue
		{
			get { return (RewardItems == null ? null : RewardItems.ToArray()); }
			set { RewardItems = (value == null ? null : new List<Item>(value)); }
		}
	}
}
