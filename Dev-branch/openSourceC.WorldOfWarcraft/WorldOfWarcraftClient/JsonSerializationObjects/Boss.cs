using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for Boss.
	/// </summary>
	[DataContract(Name = "boss")]
	[Serializable]
	public class Boss
	{
		/// <summary></summary>
		[DataMember(Name = "heroicKills")]
		public int HeroicKills { get; set; }

		/// <summary></summary>
		[DataMember(Name = "id")]
		public int Id { get; set; }

		/// <summary></summary>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary></summary>
		[DataMember(Name = "normalKills")]
		public int NormalKills { get; set; }
	}
}
