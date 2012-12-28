using System;
using System.Collections.Generic;
using System.Globalization;
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
		[IgnoreDataMember]
		public long? BattlePetGuid;

		/// <summary></summary>
		[DataMember(Name = "battlePetGuid")]
		public string BattlePetGuidValue
		{
			get { return (BattlePetGuid == null ? null : BattlePetGuid.Value.ToString("X16")); }
			set { BattlePetGuid = (string.IsNullOrWhiteSpace(value) ? (long?)null : long.Parse(value, NumberStyles.AllowHexSpecifier)); }
		}

		///// <summary></summary>
		//[IgnoreDataMember]
		//public Guid BattlePetGuid;

		///// <summary></summary>
		//[DataMember(Name = "battlePetGuid")]
		//public string BattlePetGuidValue
		//{
		//	get { return (BattlePetGuid == null ? null : BattlePetGuid.ToString("N")); }
		//	set { BattlePetGuid = (string.IsNullOrWhiteSpace(value) ? Guid.Empty : new Guid(value)); }
		//}

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
