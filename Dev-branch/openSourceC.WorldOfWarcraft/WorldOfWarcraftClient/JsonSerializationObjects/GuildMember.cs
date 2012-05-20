using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for GuildMember.
	/// </summary>
	[DataContract(Name = "guildMember")]
	[Serializable]
	public class GuildMember
	{
		/// <summary></summary>
		[DataMember(Name = "rank")]
		public int Rank;


		/// <summary></summary>
		[DataMember(Name = "character")]
		public Character Character;
	}
}
