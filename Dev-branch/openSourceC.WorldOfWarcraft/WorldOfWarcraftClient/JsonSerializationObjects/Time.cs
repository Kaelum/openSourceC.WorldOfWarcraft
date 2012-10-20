using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for Time.
	/// </summary>
	[DataContract(Name = "time")]
	[Serializable]
	public class Time
	{
		/// <summary></summary>
		[DataMember(Name = "hours")]
		public int Hours;

		/// <summary></summary>
		[DataMember(Name = "milliseconds")]
		public int Milliseconds;

		/// <summary></summary>
		[DataMember(Name = "minutes")]
		public int Minutes;

		/// <summary></summary>
		[DataMember(Name = "seconds")]
		public int Seconds;

		/// <summary>Time in milliseconds.</summary>
		[DataMember(Name = "time")]
		public long TimeSpan;
	}
}
