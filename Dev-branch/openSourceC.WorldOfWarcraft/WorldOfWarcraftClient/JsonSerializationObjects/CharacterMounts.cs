using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for CharacterMounts.
	/// </summary>
	[DataContract(Name = "mounts")]
	[Serializable]
	public class CharacterMounts
	{
		/// <summary></summary>
		[DataMember(Name = "numCollected")]
		public int NumCollected;

		/// <summary></summary>
		[DataMember(Name = "numNotCollected")]
		public int NumNotCollected;


		/// <summary></summary>
		[IgnoreDataMember]
		public List<Mount> Collected;

		/// <summary></summary>
		[DataMember(Name = "collected")]
		public Mount[] CollectedValue
		{
			get { return (Collected == null ? null : Collected.ToArray()); }
			set { Collected = (value == null ? null : new List<Mount>(value)); }
		}
	}
}
