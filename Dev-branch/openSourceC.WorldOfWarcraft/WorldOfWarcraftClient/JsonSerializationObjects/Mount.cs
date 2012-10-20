using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for Mount.
	/// </summary>
	[DataContract(Name = "mount")]
	[Serializable]
	public class Mount
	{
		/// <summary></summary>
		[DataMember(Name = "creatureId")]
		public int CreatureId;

		/// <summary></summary>
		[DataMember(Name = "icon")]
		public string Icon;

		/// <summary></summary>
		[DataMember(Name = "isAquatic")]
		public bool IsAquatic;

		/// <summary></summary>
		[DataMember(Name = "isFlying")]
		public bool IsFlying;

		/// <summary></summary>
		[DataMember(Name = "isGround")]
		public bool IsGround;

		/// <summary></summary>
		[DataMember(Name = "isJumping")]
		public bool IsJumping;

		/// <summary></summary>
		[DataMember(Name = "itemId")]
		public int ItemId;

		/// <summary></summary>
		[DataMember(Name = "name")]
		public string Name;

		/// <summary></summary>
		[DataMember(Name = "qualityId")]
		public int QualityId;

		/// <summary></summary>
		[DataMember(Name = "spellId")]
		public int SpellId;
	}
}
