using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for CharacterRacesResponse.
	/// </summary>
	[DataContract(Name = "response")]
	[Serializable]
	public class CharacterRacesResponse : BaseResponse
	{
		/// <summary></summary>
		[IgnoreDataMember]
		public List<CharacterRace> Races;

		/// <summary></summary>
		[DataMember(Name = "races")]
		public CharacterRace[] RacesValue
		{
			get { return (Races == null ? null : Races.ToArray()); }
			set { Races = (value == null ? null : new List<CharacterRace>(value)); }
		}
	}
}
