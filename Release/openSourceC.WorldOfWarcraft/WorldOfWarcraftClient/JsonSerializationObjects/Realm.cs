using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for Realm.
	/// </summary>
	[DataContract(Name = "realm")]
	[Serializable]
	public class Realm
	{
		/// <summary></summary>
		[DataMember(Name = "battlegroup")]
		public string Battlegroup;

		/// <summary></summary>
		[DataMember(Name = "name")]
		public string Name;

		/// <summary></summary>
		[DataMember(Name = "slug")]
		public string Slug;
	}
}
