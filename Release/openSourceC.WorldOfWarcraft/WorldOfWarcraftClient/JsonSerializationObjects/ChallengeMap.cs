using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for ChallengeMap.
	/// </summary>
	[DataContract(Name = "map")]
	[Serializable]
	public class ChallengeMap
	{
		/// <summary></summary>
		[DataMember(Name = "hasChallengeMode")]
		public bool HasChallengeMode;

		/// <summary></summary>
		[DataMember(Name = "id")]
		public int Id;

		/// <summary></summary>
		[DataMember(Name = "name")]
		public string Name;

		/// <summary></summary>
		[DataMember(Name = "slug")]
		public string Slug;


		/// <summary></summary>
		[DataMember(Name = "bronzeCriteria")]
		public Time BronzeCriteria;

		/// <summary></summary>
		[DataMember(Name = "goldCriteria")]
		public Time GoldCriteria;

		/// <summary></summary>
		[DataMember(Name = "silverCriteria")]
		public Time SilverCriteria;
	}
}
