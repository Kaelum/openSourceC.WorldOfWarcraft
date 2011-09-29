﻿using System;
using System.Collections.Generic;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for CharacterProfessions.
	/// </summary>
	[Serializable]
	public class CharacterProfessions
	{
		/// <summary></summary>
		public List<Profession> Primary;

		/// <summary></summary>
		public List<Profession> Secondary;
	}
}