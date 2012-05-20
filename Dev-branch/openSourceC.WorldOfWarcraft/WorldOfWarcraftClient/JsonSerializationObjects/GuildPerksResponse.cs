using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for GuildPerksResponse.
	/// </summary>
	[DataContract(Name = "response")]
	[Serializable]
	public class GuildPerksResponse : BaseResponse
	{
		/// <summary></summary>
		[IgnoreDataMember]
		public List<GuildPerk> Perks;

		/// <summary></summary>
		[DataMember(Name = "perks")]
		public GuildPerk[] PerksValue
		{
			get { return (Perks == null ? null : Perks.ToArray()); }
			set { Perks = (value == null ? null : new List<GuildPerk>(value)); }
		}
	}
}
