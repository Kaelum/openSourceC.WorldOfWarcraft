using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for CharacterPets.
	/// </summary>
	[DataContract(Name = "pets")]
	[Serializable]
	public class CharacterPets
	{
		/// <summary></summary>
		[DataMember(Name = "numCollected")]
		public int NumCollected;

		/// <summary></summary>
		[DataMember(Name = "numNotCollected")]
		public int NumNotCollected;


		/// <summary></summary>
		[IgnoreDataMember]
		public List<BattlePet> Collected;

		/// <summary></summary>
		[DataMember(Name = "collected")]
		public BattlePet[] CollectedValue
		{
			get { return (Collected == null ? null : Collected.ToArray()); }
			set { Collected = (value == null ? null : new List<BattlePet>(value)); }
		}
	}
}
