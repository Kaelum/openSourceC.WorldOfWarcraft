using System;
using System.Collections.Generic;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for RaidProgression.
	/// </summary>
	[Serializable]
	public class RaidProgression
	{
		/// <summary></summary>
		public string Name;

		/// <summary></summary>
		public int Normal;

		/// <summary></summary>
		public int Heroic;

		/// <summary></summary>
		public int Id;


		/// <summary></summary>
		public List<Boss> Bosses;
	}
}
