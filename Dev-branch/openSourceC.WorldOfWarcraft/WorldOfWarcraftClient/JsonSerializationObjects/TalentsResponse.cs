using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for TalentsResponse.
	/// </summary>
	[DataContract(Name = "response")]
	[Serializable]
	public class TalentsResponse : BaseResponse
	{
		/// <summary></summary>
		[DataMember(Name = "6")]
		public TalentGroup DeathKnight;

		/// <summary></summary>
		[DataMember(Name = "11")]
		public TalentGroup Druid;

		/// <summary></summary>
		[DataMember(Name = "3")]
		public TalentGroup Hunter;

		/// <summary></summary>
		[DataMember(Name = "8")]
		public TalentGroup Mage;

		/// <summary></summary>
		[DataMember(Name = "10")]
		public TalentGroup Monk;

		/// <summary></summary>
		[DataMember(Name = "2")]
		public TalentGroup Paladin;

		/// <summary></summary>
		[DataMember(Name = "5")]
		public TalentGroup Priest;

		/// <summary></summary>
		[DataMember(Name = "4")]
		public TalentGroup Rogue;

		/// <summary></summary>
		[DataMember(Name = "7")]
		public TalentGroup Shaman;

		/// <summary></summary>
		[DataMember(Name = "9")]
		public TalentGroup Warlock;

		/// <summary></summary>
		[DataMember(Name = "1")]
		public TalentGroup Warrior;
	}
}
