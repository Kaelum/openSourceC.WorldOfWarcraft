using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for Socket.
	/// </summary>
	[DataContract(Name = "socket")]
	[Serializable]
	public class Socket
	{
		/// <summary></summary>
		[DataMember(Name = "type")]
		public string Type;
	}
}
