using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for BattlegroupsResponse.
	/// </summary>
	[DataContract(Name = "response")]
	[Serializable]
	public class BattlegroupsResponse : BaseResponse
	{
		/// <summary></summary>
		[IgnoreDataMember]
		public List<Battlegroup> Battlegroups;

		/// <summary></summary>
		[DataMember(Name = "battlegroups")]
		public Battlegroup[] BattlegroupsValue
		{
			get { return (Battlegroups == null ? null : Battlegroups.ToArray()); }
			set { Battlegroups = (value == null ? null : new List<Battlegroup>(value)); }
		}
	}
}
