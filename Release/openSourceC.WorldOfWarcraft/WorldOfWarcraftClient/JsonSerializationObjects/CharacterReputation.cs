using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for CharacterReputation.
	/// </summary>
	[DataContract(Name = "characterReputation")]
	[Serializable]
	public class CharacterReputation
	{
		/// <summary></summary>
		[DataMember(Name = "id")]
		public int Id;

		/// <summary></summary>
		[DataMember(Name = "max")]
		public int Max;

		/// <summary></summary>
		[DataMember(Name = "name")]
		public string Name;

		/// <summary></summary>
		[DataMember(Name = "standing")]
		public int Standing;

		/// <summary></summary>
		[DataMember(Name = "value")]
		public int Value;
	}
}
