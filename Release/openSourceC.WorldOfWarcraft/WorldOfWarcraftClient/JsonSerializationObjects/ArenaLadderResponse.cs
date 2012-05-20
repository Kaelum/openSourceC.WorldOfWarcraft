using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for ArenaLadderResponse.
	/// </summary>
	[DataContract(Name = "response")]
	[Serializable]
	public class ArenaLadderResponse : BaseResponse
	{
		/// <summary></summary>
		[IgnoreDataMember]
		public List<ArenaTeamResponse> ArenaTeams;

		/// <summary></summary>
		[DataMember(Name = "arenateam")]
		public ArenaTeamResponse[] ArenaTeamsValue
		{
			get { return (ArenaTeams == null ? null : ArenaTeams.ToArray()); }
			set { ArenaTeams = (value == null ? null : new List<ArenaTeamResponse>(value)); }
		}
	}
}
