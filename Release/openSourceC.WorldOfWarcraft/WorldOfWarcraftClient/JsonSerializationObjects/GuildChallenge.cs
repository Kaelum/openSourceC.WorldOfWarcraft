using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for GuildChallenge.
	/// </summary>
	[DataContract(Name = "challenge")]
	[Serializable]
	public class GuildChallenge
	{
		/// <summary></summary>
		[DataMember(Name = "map")]
		public ChallengeMap Map;


		/// <summary></summary>
		[IgnoreDataMember]
		public List<ChallengeGroup> Groups;

		/// <summary></summary>
		[DataMember(Name = "groups")]
		public ChallengeGroup[] GroupsValue
		{
			get { return (Groups == null ? null : Groups.ToArray()); }
			set { Groups = (value == null ? null : new List<ChallengeGroup>(value)); }
		}
	}
}
