using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for BattlePetAbility.
	/// </summary>
	[DataContract(Name = "ability")]
	[Serializable]
	public class BattlePetAbility
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
		[DataMember(Name = "order")]
		public int Order;

		/// <summary></summary>
		[DataMember(Name = "petTypeId")]
		public int PetTypeId;

		/// <summary></summary>
		[DataMember(Name = "requiredLevel")]
		public int RequiredLevel;

		/// <summary></summary>
		[DataMember(Name = "rounds")]
		public int Rounds;

		/// <summary></summary>
		[DataMember(Name = "showHints")]
		public bool ShowHints;

		/// <summary></summary>
		[DataMember(Name = "slot")]
		public int Slot;
	}
}
