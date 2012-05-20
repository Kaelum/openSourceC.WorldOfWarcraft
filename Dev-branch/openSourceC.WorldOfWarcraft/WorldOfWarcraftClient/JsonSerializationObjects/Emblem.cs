using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for Emblem.
	/// </summary>
	[DataContract(Name = "emblem")]
	[Serializable]
	public class Emblem
	{
		/// <summary></summary>
		[DataMember(Name = "backgroundColor")]
		public string BackgroundColor;

		/// <summary></summary>
		[DataMember(Name = "border")]
		public int Border;

		/// <summary></summary>
		[DataMember(Name = "borderColor")]
		public string BorderColor;

		/// <summary></summary>
		[DataMember(Name = "icon")]
		public int Icon;

		/// <summary></summary>
		[DataMember(Name = "iconColor")]
		public string IconColor;
	}
}
