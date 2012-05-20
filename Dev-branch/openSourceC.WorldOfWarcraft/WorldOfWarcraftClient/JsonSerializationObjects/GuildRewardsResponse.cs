using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for GuildRewardsResponse.
	/// </summary>
	[DataContract(Name = "response")]
	[Serializable]
	public class GuildRewardsResponse : BaseResponse
	{
		/// <summary></summary>
		[IgnoreDataMember]
		public List<GuildReward> Rewards;

		/// <summary></summary>
		[DataMember(Name = "rewards")]
		public GuildReward[] RewardsValue
		{
			get { return (Rewards == null ? null : Rewards.ToArray()); }
			set { Rewards = (value == null ? null : new List<GuildReward>(value)); }
		}
	}
}
