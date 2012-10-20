using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for BattlePetSlot.
	/// </summary>
	[DataContract(Name = "petSlot")]
	[Serializable]
	public class BattlePetSlot
	{
		/// <summary></summary>
		[IgnoreDataMember]
		public List<int> Abilities;

		/// <summary></summary>
		[DataMember(Name = "abilities")]
		public int[] AbilitiesValue
		{
			get { return (Abilities == null ? null : Abilities.ToArray()); }
			set { Abilities = (value == null ? null : new List<int>(value)); }
		}

		/// <summary></summary>
		[DataMember(Name = "battlePetId")]
		public int BattlePetId;

		/// <summary></summary>
		[DataMember(Name = "isEmpty")]
		public bool IsEmpty;

		/// <summary></summary>
		[DataMember(Name = "isLocked")]
		public bool IsLocked;

		/// <summary></summary>
		[DataMember(Name = "slot")]
		public int Slot;
	}
}
