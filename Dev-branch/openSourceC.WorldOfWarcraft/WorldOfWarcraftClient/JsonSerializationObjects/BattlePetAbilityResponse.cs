using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for BattlePetAbilityResponse.
	/// </summary>
	[DataContract(Name = "response")]
	[Serializable]
	public class BattlePetAbilityResponse : BaseResponse
	{
		/// <summary></summary>
		[DataMember(Name = "cooldown")]
		public int Cooldown;

		/// <summary></summary>
		[DataMember(Name = "icon")]
		public string Icon;

		/// <summary></summary>
		[DataMember(Name = "id")]
		public int Id;

		/// <summary></summary>
		[DataMember(Name = "isPassive")]
		public bool IsPassive;

		/// <summary></summary>
		[DataMember(Name = "name")]
		public string Name;

		/// <summary></summary>
		[DataMember(Name = "petTypeId")]
		public int PetTypeId;

		/// <summary></summary>
		[DataMember(Name = "rounds")]
		public int Rounds;

		/// <summary></summary>
		[DataMember(Name = "showHints")]
		public bool ShowHints;
	}
}
