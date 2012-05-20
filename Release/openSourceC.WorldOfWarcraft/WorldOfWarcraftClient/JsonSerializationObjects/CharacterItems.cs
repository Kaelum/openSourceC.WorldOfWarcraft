using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for CharacterItems.
	/// </summary>
	[DataContract(Name = "characterItem")]
	[Serializable]
	public class CharacterItems
	{
		/// <summary></summary>
		[DataMember(Name = "averageItemLevel")]
		public int AverageItemLevel;

		/// <summary></summary>
		[DataMember(Name = "averageItemLevelEquipped")]
		public int AverageItemLevelEquipped;


		/// <summary></summary>
		[DataMember(Name = "back")]
		public CharacterItem Back;

		/// <summary></summary>
		[DataMember(Name = "chest")]
		public CharacterItem Chest;

		/// <summary></summary>
		[DataMember(Name = "hands")]
		public CharacterItem Hands;

		/// <summary></summary>
		[DataMember(Name = "feet")]
		public CharacterItem Feet;

		/// <summary></summary>
		[DataMember(Name = "finger1")]
		public CharacterItem Finger1;

		/// <summary></summary>
		[DataMember(Name = "finger2")]
		public CharacterItem Finger2;

		/// <summary></summary>
		[DataMember(Name = "head")]
		public CharacterItem Head;

		/// <summary></summary>
		[DataMember(Name = "legs")]
		public CharacterItem Legs;

		/// <summary></summary>
		[DataMember(Name = "mainHand")]
		public CharacterItem MainHand;

		/// <summary></summary>
		[DataMember(Name = "neck")]
		public CharacterItem Neck;

		/// <summary></summary>
		[DataMember(Name = "ranged")]
		public CharacterItem Ranged;

		/// <summary></summary>
		[DataMember(Name = "shirt")]
		public CharacterItem Shirt;

		/// <summary></summary>
		[DataMember(Name = "shoulder")]
		public CharacterItem Shoulder;

		/// <summary></summary>
		[DataMember(Name = "tabard")]
		public CharacterItem Tabard;

		/// <summary></summary>
		[DataMember(Name = "trinket1")]
		public CharacterItem Trinket1;

		/// <summary></summary>
		[DataMember(Name = "trinket2")]
		public CharacterItem Trinket2;

		/// <summary></summary>
		[DataMember(Name = "waist")]
		public CharacterItem Waist;

		/// <summary></summary>
		[DataMember(Name = "wrist")]
		public CharacterItem Wrist;
	}
}
