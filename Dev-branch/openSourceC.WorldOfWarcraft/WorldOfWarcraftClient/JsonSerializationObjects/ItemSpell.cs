using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for ItemSpell.
	/// </summary>
	[DataContract(Name = "itemSpell")]
	[Serializable]
	public class ItemSpell
	{
		/// <summary></summary>
		[DataMember(Name = "categoryId")]
		public int CategoryId;

		/// <summary></summary>
		[DataMember(Name = "consumable")]
		public bool Consumable;

		/// <summary></summary>
		[DataMember(Name = "nCharges")]
		public int NCharges;

		/// <summary></summary>
		[DataMember(Name = "spellId")]
		public int SpellId;

		/// <summary></summary>
		[DataMember(Name = "trigger")]
		public string Trigger;


		/// <summary></summary>
		[DataMember(Name = "spell")]
		public Spell Spell;
	}
}
