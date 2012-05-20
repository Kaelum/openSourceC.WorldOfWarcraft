using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for Battleground.
	/// </summary>
	[DataContract(Name = "battleground")]
	[Serializable]
	public class Battleground
	{
		/// <summary></summary>
		[DataMember(Name = "name")]
		public string Name;

		/// <summary></summary>
		[DataMember(Name = "played")]
		public int Played;

		/// <summary></summary>
		[DataMember(Name = "won")]
		public int Won;
	}
}
