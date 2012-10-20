using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for Challenge.
	/// </summary>
	[DataContract(Name = "challenge")]
	[Serializable]
	public class Challenge
	{
		/// <summary></summary>
		[DataMember(Name = "map")]
		public ChallengeMap Map;

		/// <summary></summary>
		[DataMember(Name = "realm")]
		public Realm Realm;


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
