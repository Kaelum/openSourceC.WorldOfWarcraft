using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for Member.
	/// </summary>
	[DataContract(Name = "member")]
	[Serializable]
	public class Member
	{
		/// <summary></summary>
		[DataMember(Name = "character")]
		public Character Character;

		/// <summary></summary>
		[DataMember(Name = "spec")]
		public Spec Spec;
	}
}
