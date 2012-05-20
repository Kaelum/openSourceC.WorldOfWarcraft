using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for RatedBattlegroundLadderResponse.
	/// </summary>
	[DataContract(Name = "response")]
	[Serializable]
	public class RatedBattlegroundLadderResponse : BaseResponse
	{
		/// <summary></summary>
		[IgnoreDataMember]
		public List<BattlegroundRecord> BattlegroundRecords;

		/// <summary></summary>
		[DataMember(Name = "bgRecord")]
		public BattlegroundRecord[] BattlegroupsValue
		{
			get { return (BattlegroundRecords == null ? null : BattlegroundRecords.ToArray()); }
			set { BattlegroundRecords = (value == null ? null : new List<BattlegroundRecord>(value)); }
		}
	}
}
