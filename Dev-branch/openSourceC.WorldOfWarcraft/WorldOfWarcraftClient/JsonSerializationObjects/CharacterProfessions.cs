using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for CharacterProfessions.
	/// </summary>
	[DataContract(Name = "characterProfessions")]
	[Serializable]
	public class CharacterProfessions
	{
		/// <summary></summary>
		[IgnoreDataMember]
		public List<Profession> Primary;

		/// <summary></summary>
		[DataMember(Name = "primary")]
		public Profession[] PrimaryValue
		{
			get { return (Primary == null ? null : Primary.ToArray()); }
			set { Primary = (value == null ? null : new List<Profession>(value)); }
		}

		/// <summary></summary>
		[IgnoreDataMember]
		public List<Profession> Secondary;

		/// <summary></summary>
		[DataMember(Name = "secondary")]
		public Profession[] SecondaryValue
		{
			get { return (Secondary == null ? null : Secondary.ToArray()); }
			set { Secondary = (value == null ? null : new List<Profession>(value)); }
		}
	}
}
