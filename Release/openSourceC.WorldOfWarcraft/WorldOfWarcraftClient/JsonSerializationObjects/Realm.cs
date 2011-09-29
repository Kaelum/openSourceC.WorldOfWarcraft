using System;
using System.Collections.Generic;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for Realm.
	/// </summary>
	[Serializable]
	public class Realm
	{
		/// <summary></summary>
		public string Name;

		/// <summary></summary>
		public string Slug;

		/// <summary></summary>
		public RealmTypeEnum Type;

		/// <summary></summary>
		public bool Queue;

		/// <summary></summary>
		public bool Status;

		/// <summary></summary>
		public RealmPopulationEnum Population;
	}
}
