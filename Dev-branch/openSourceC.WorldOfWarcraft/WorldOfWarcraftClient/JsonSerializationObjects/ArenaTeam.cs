using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient.JsonSerializationObjects
{
	/// <summary>
	///		Summary description for ArenaTeam.
	/// </summary>
	[DataContract(Name = "arenaTeam")]
	[Serializable]
	public class ArenaTeam
	{
		/// <summary></summary>
		[DataMember(Name = "name")]
		public string Name;

		/// <summary></summary>
		[DataMember(Name = "personalRating")]
		public int PersonalRating;

		/// <summary></summary>
		[DataMember(Name = "size")]
		public string Size;

		/// <summary></summary>
		[DataMember(Name = "teamRating")]
		public int TeamRating;
	}
}
