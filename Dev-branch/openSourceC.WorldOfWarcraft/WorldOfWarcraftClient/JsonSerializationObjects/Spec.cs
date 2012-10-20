using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for Spec.
	/// </summary>
	[DataContract(Name = "spec")]
	[Serializable]
	public class Spec
	{
		/// <summary></summary>
		[DataMember(Name = "backgroundImage")]
		public string BackgroundImage;

		/// <summary></summary>
		[DataMember(Name = "description")]
		public string Description;

		/// <summary></summary>
		[DataMember(Name = "icon")]
		public string Icon;

		/// <summary></summary>
		[DataMember(Name = "name")]
		public string Name;

		/// <summary></summary>
		[DataMember(Name = "order")]
		public int Order;

		/// <summary></summary>
		[DataMember(Name = "role")]
		public string Role;
	}
}
