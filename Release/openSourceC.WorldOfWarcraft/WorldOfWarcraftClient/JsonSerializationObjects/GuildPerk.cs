using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for GuildPerk.
	/// </summary>
	[DataContract(Name = "guildPerk")]
	[Serializable]
	public class GuildPerk
	{
		/// <summary></summary>
		[DataMember(Name = "guildLevel")]
		public int GuildLevel;

		/// <summary></summary>
		[DataMember(Name = "spell")]
		public Spell Spell;
	}
}
