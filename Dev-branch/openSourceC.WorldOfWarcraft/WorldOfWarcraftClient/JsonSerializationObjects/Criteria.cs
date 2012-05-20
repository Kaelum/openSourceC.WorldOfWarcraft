using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for Criteria.
	/// </summary>
	[DataContract(Name = "criteria")]
	[Serializable]
	public class Criteria
	{
		/// <summary></summary>
		[DataMember(Name = "description")]
		public string Description;

		/// <summary></summary>
		[DataMember(Name = "id")]
		public int Id;
	}
}
