using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for RealmStatusResponse.
	/// </summary>
	[DataContract(Name = "response")]
	[Serializable]
	public class RealmStatusResponse : BaseResponse
	{
		/// <summary></summary>
		[IgnoreDataMember]
		public List<RealmStatus> Realms;

		/// <summary></summary>
		[DataMember(Name = "realms")]
		public RealmStatus[] RealmsValue
		{
			get { return (Realms == null ? null : Realms.ToArray()); }
			set { Realms = (value == null ? null : new List<RealmStatus>(value)); }
		}
	}
}
