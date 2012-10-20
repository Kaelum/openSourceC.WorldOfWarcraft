using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for RealmChallengeResponse.
	/// </summary>
	[DataContract(Name = "response")]
	[Serializable]
	public class RealmChallengeResponse : BaseResponse
	{
		/// <summary></summary>
		[IgnoreDataMember]
		public List<Challenge> Challenges;

		/// <summary></summary>
		[DataMember(Name = "challenge")]
		public Challenge[] ChallengesValue
		{
			get { return (Challenges == null ? null : Challenges.ToArray()); }
			set { Challenges = (value == null ? null : new List<Challenge>(value)); }
		}
	}
}
