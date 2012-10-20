using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for BattlePetStatsResponse.
	/// </summary>
	[DataContract(Name = "response")]
	[Serializable]
	public class BattlePetStatsResponse : BaseResponse
	{
		/// <summary></summary>
		[DataMember(Name = "breedId")]
		public int BreedId;

		/// <summary></summary>
		[DataMember(Name = "health")]
		public int Health;

		/// <summary></summary>
		[DataMember(Name = "level")]
		public int Level;

		/// <summary></summary>
		[DataMember(Name = "petQualityId")]
		public int PetQualityId;

		/// <summary></summary>
		[DataMember(Name = "power")]
		public int Power;

		/// <summary></summary>
		[DataMember(Name = "speciesId")]
		public int SpeciesId;

		/// <summary></summary>
		[DataMember(Name = "speed")]
		public int Speed;
	}
}
