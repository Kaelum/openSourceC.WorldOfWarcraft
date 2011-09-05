using System;
using System.Collections.Generic;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for WeaponInfo.
	/// </summary>
	[Serializable]
	public class WeaponInfo
	{
		/// <summary></summary>
		public List<Damage> Damage;

		/// <summary></summary>
		public double WeaponSpeed;

		/// <summary></summary>
		public double Dps;
	}
}
