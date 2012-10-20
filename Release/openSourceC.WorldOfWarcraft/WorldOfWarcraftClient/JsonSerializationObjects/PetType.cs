using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for PetType.
	/// </summary>
	[DataContract(Name = "petType")]
	[Serializable]
	public class PetType
	{
		/// <summary></summary>
		[DataMember(Name = "id")]
		public int Id;

		/// <summary></summary>
		[DataMember(Name = "key")]
		public string Key;

		/// <summary></summary>
		[DataMember(Name = "name")]
		public string Name;

		/// <summary></summary>
		[DataMember(Name = "strongAgainstId")]
		public int StrongAgainstId;

		/// <summary></summary>
		[DataMember(Name = "typeAbilityId")]
		public int TypeAbilityId;

		/// <summary></summary>
		[DataMember(Name = "weakAgainstId")]
		public int WeakAgainstId;
	}
}
