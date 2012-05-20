using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for CharacterProgression.
	/// </summary>
	[DataContract(Name = "characterProgression")]
	[Serializable]
	public class CharacterProgression
	{
		/// <summary></summary>
		[IgnoreDataMember]
		public List<RaidProgression> Raids;

		/// <summary></summary>
		[DataMember(Name = "raids")]
		public RaidProgression[] RaidsValue
		{
			get { return (Raids == null ? null : Raids.ToArray()); }
			set { Raids = (value == null ? null : new List<RaidProgression>(value)); }
		}
	}
}
