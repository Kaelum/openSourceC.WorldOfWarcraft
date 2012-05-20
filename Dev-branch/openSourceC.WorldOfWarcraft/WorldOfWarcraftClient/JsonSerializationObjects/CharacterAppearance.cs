using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for CharacterAppearance.
	/// </summary>
	[DataContract(Name = "characterAppearance")]
	[Serializable]
	public class CharacterAppearance
	{
		/// <summary></summary>
		[DataMember(Name = "faceVariation")]
		public int FaceVariation;

		/// <summary></summary>
		[DataMember(Name = "featureVariation")]
		public int FeatureVariation;

		/// <summary></summary>
		[DataMember(Name = "hairColor")]
		public int HairColor;

		/// <summary></summary>
		[DataMember(Name = "hairVariation")]
		public int HairVariation;

		/// <summary></summary>
		[DataMember(Name = "showCloak")]
		public bool ShowCloak;

		/// <summary></summary>
		[DataMember(Name = "showHelm")]
		public bool ShowHelm;

		/// <summary></summary>
		[DataMember(Name = "skinColor")]
		public int SkinColor;
	}
}
