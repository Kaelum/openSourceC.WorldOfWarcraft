using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for RatedBattleground.
	/// </summary>
	[DataContract(Name = "ratedBattleground")]
	[Serializable]
	public class RatedBattleground
	{
		/// <summary></summary>
		[DataMember(Name = "personalRating")]
		public int PersonalRating;


		/// <summary></summary>
		[IgnoreDataMember]
		public List<Battleground> Battlegrounds;

		/// <summary></summary>
		[DataMember(Name = "battlegrounds")]
		public Battleground[] BattlegroundsValue
		{
			get { return (Battlegrounds == null ? null : Battlegrounds.ToArray()); }
			set { Battlegrounds = (value == null ? null : new List<Battleground>(value)); }
		}
	}
}
