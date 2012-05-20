using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for CharacterRace.
	/// </summary>
	[DataContract(Name = "characterRace")]
	[Serializable]
	public class CharacterRace
	{
		/// <summary></summary>
		[DataMember(Name = "id")]
		public int Id;

		/// <summary></summary>
		[DataMember(Name = "mask")]
		public int Mask;

		/// <summary></summary>
		[DataMember(Name = "name")]
		public string Name;

		/// <summary></summary>
		[IgnoreDataMember]
		public FactionEnum Side;

		/// <summary></summary>
		[DataMember(Name = "side")]
		public string SideValue
		{
			get { return Side.ToString().ToLowerInvariant(); }
			set { Side = (FactionEnum)Enum.Parse(typeof(FactionEnum), value, true); }
		}
	}
}
