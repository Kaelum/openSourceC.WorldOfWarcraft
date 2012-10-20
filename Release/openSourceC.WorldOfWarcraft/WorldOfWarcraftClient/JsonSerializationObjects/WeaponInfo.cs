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
		[DataMember(Name = "damage")]
		public Damage DamageValue;

		/// <summary></summary>
		[DataMember(Name = "dps")]
		public double Dps;

		/// <summary></summary>
		[DataMember(Name = "weaponSpeed")]
		public double WeaponSpeed;
	}
}
