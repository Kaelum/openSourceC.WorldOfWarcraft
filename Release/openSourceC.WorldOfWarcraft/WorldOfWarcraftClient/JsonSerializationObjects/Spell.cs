using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for Spell.
	/// </summary>
	[DataContract(Name = "spell")]
	[Serializable]
	public class Spell
	{
		/// <summary></summary>
		[DataMember(Name = "castTime")]
		public string CastTime;

		/// <summary></summary>
		[DataMember(Name = "cooldown")]
		public string Cooldown;

		/// <summary></summary>
		[DataMember(Name = "description")]
		public string Description;

		/// <summary></summary>
		[DataMember(Name = "icon")]
		public string Icon;

		/// <summary></summary>
		[DataMember(Name = "id")]
		public int Id;

		/// <summary></summary>
		[DataMember(Name = "name")]
		public string Name;

		/// <summary></summary>
		[DataMember(Name = "range")]
		public string Range;

		/// <summary></summary>
		[DataMember(Name = "subtext")]
		public string Subtext;
	}
}
