using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for WeaponInfo.
	/// </summary>
	[DataContract(Name = "weaponInfo")]
	[Serializable]
	public class WeaponInfo
	{
		/// <summary></summary>
		[DataMember(Name = "weaponSpeed")]
		public double WeaponSpeed;

		/// <summary></summary>
		[DataMember(Name = "dps")]
		public double Dps;


		/// <summary></summary>
		[IgnoreDataMember]
		public List<Damage> Damage;

		/// <summary></summary>
		[DataMember(Name = "damage")]
		public Damage[] DamageValue
		{
			get { return (Damage == null ? null : Damage.ToArray()); }
			set { Damage = (value == null ? null : new List<Damage>(value)); }
		}
	}
}
