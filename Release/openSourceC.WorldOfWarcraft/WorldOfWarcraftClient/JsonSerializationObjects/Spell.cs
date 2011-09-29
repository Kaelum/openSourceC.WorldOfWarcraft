﻿using System;
using System.Collections.Generic;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for Spell.
	/// </summary>
	[Serializable]
	public class Spell
	{
		/// <summary></summary>
		public int Id;

		/// <summary></summary>
		public string Name;

		/// <summary></summary>
		public string Subtext;

		/// <summary></summary>
		public string Icon;

		/// <summary></summary>
		public string Description;

		/// <summary></summary>
		public string Range;

		/// <summary></summary>
		public string CastTime;

		/// <summary></summary>
		public string Cooldown;
	}
}