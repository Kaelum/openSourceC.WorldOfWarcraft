using System;
using System.Collections.Generic;

namespace openSourceC.WorldOfWarcraft
{
	/// <summary>
	///		Summary description for ItemSpell.
	/// </summary>
	[Serializable]
	public class ItemSpell
	{
		/// <summary></summary>
		public int SpellId;

		/// <summary></summary>
		public Spell Spell;

		/// <summary></summary>
		public int NCharges;

		/// <summary></summary>
		public bool Consumable;

		/// <summary></summary>
		public int CategoryId;
	}
}
