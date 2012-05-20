using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for PvPZone.
	/// </summary>
	[DataContract(Name = "pvpZone")]
	[Serializable]
	public class PvPZone
	{
		/// <summary></summary>
		[DataMember(Name = "area")]
		public int Area;

		/// <summary></summary>
		[DataMember(Name = "controlling-faction")]
		public FactionEnum ControllingFaction;

		/// <summary>This is the <see cref="T:DateTime"/> representation of <see cref="NextValue"/></summary>
		[IgnoreDataMember]
		public DateTime Next;

		/// <summary></summary>
		[DataMember(Name = "next")]
		public long NextValue
		{
			get { return Next.ToUnixTime(); }
			set { Next = value.ToDateTime(); }
		}

		/// <summary></summary>
		[DataMember(Name = "status")]
		public PvPStatusEnum Status;
	}
}
