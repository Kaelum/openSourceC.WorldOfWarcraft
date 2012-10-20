using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for BattlePetSpeciesResponse.
	/// </summary>
	[DataContract(Name = "response")]
	[Serializable]
	public class BattlePetSpeciesResponse : BaseResponse
	{
		/// <summary></summary>
		[DataMember(Name = "canBattle")]
		public bool CanBattle;

		/// <summary></summary>
		[DataMember(Name = "creatureId")]
		public int CreatureId;

		/// <summary></summary>
		[DataMember(Name = "description")]
		public string Description;

		/// <summary></summary>
		[DataMember(Name = "icon")]
		public string Icon;

		/// <summary></summary>
		[DataMember(Name = "petTypeId")]
		public int PetTypeId;

		/// <summary></summary>
		[DataMember(Name = "source")]
		public string Source;

		/// <summary></summary>
		[DataMember(Name = "speciesId")]
		public int SpeciesId;


		/// <summary></summary>
		[IgnoreDataMember]
		public List<BattlePetAbility> Abilities;

		/// <summary></summary>
		[DataMember(Name = "abilities")]
		public BattlePetAbility[] AbilitiesValue
		{
			get { return (Abilities == null ? null : Abilities.ToArray()); }
			set { Abilities = (value == null ? null : new List<BattlePetAbility>(value)); }
		}
	}
}
