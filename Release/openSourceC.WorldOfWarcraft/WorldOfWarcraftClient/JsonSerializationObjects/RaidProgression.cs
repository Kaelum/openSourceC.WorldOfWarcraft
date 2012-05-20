using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for RaidProgression.
	/// </summary>
	[DataContract(Name = "raidProgression")]
	[Serializable]
	public class RaidProgression
	{
		/// <summary></summary>
		[DataMember(Name = "heroic")]
		public int Heroic;

		/// <summary></summary>
		[DataMember(Name = "id")]
		public int Id;

		/// <summary></summary>
		[DataMember(Name = "name")]
		public string Name;

		/// <summary></summary>
		[DataMember(Name = "normal")]
		public int Normal;


		/// <summary></summary>
		[IgnoreDataMember]
		public List<Boss> Bosses;

		/// <summary></summary>
		[DataMember(Name = "bosses")]
		public Boss[] BossesValue
		{
			get { return (Bosses == null ? null : Bosses.ToArray()); }
			set { Bosses = (value == null ? null : new List<Boss>(value)); }
		}
	}
}
