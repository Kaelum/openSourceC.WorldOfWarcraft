using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for Battlegroup.
	/// </summary>
	[DataContract(Name = "battlegroup")]
	[Serializable]
	public class Battlegroup
	{
		/// <summary></summary>
		[DataMember(Name = "name")]
		public string Name;

		/// <summary></summary>
		[DataMember(Name = "slug")]
		public string Slug;
	}
}
