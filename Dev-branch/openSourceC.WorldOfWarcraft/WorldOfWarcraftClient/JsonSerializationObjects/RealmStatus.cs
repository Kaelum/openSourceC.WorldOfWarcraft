using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for RealmStatus.
	/// </summary>
	[DataContract(Name = "realmStatus")]
	[Serializable]
	public class RealmStatus
	{
		/// <summary></summary>
		[DataMember(Name = "battlegroup")]
		public string BattleGroup;

		/// <summary></summary>
		[DataMember(Name = "locale")]
		public string Locale;

		/// <summary></summary>
		[DataMember(Name = "name")]
		public string Name;

		/// <summary></summary>
		[IgnoreDataMember]
		public RealmPopulationEnum Population;

		/// <summary></summary>
		[DataMember(Name = "population")]
		public string PopulationValue
		{
			get { return Population.ToString().ToLowerInvariant(); }
			set { Population = (RealmPopulationEnum)Enum.Parse(typeof(RealmPopulationEnum), value, true); }
		}

		/// <summary></summary>
		[DataMember(Name = "queue")]
		public bool Queue;

		/// <summary></summary>
		[DataMember(Name = "slug")]
		public string Slug;

		/// <summary></summary>
		[DataMember(Name = "status")]
		public bool Status;

		/// <summary></summary>
		[DataMember(Name = "timezone")]
		public string Timezone;

		/// <summary></summary>
		[IgnoreDataMember]
		public RealmTypeEnum Type;

		/// <summary></summary>
		[DataMember(Name = "type")]
		public string TypeValue
		{
			get { return Type.ToString().ToLowerInvariant(); }
			set { Type = (RealmTypeEnum)Enum.Parse(typeof(RealmTypeEnum), value, true); }
		}


		/// <summary></summary>
		[DataMember(Name = "tol-barad")]
		public PvPZone TolBarad;

		/// <summary></summary>
		[DataMember(Name = "wintergrasp")]
		public PvPZone Wintergrasp;
	}
}
