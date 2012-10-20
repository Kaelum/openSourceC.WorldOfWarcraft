using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for HunterPet.
	/// </summary>
	[DataContract(Name = "hunterPet")]
	[Serializable]
	public class HunterPet
	{
		/// <summary></summary>
		[DataMember(Name = "creature")]
		public int Creature;

		/// <summary></summary>
		[DataMember(Name = "name")]
		public string Name;

		/// <summary></summary>
		[DataMember(Name = "selected")]
		public bool Selected;

		/// <summary></summary>
		[DataMember(Name = "slot")]
		public int Slot;


		/// <summary></summary>
		[DataMember(Name = "talents")]
		public TalentBuild Talents;
	}
}
