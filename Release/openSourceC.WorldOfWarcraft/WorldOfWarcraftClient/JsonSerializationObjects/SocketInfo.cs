using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for SocketInfo.
	/// </summary>
	[DataContract(Name = "socketInfo")]
	[Serializable]
	public class SocketInfo
	{
		/// <summary></summary>
		[DataMember(Name = "socketBonus")]
		public string SocketBonus;


		/// <summary></summary>
		[IgnoreDataMember]
		public List<Socket> Sockets;

		/// <summary></summary>
		[DataMember(Name = "sockets")]
		public Socket[] SocketsValue
		{
			get { return (Sockets == null ? null : Sockets.ToArray()); }
			set { Sockets = (value == null ? null : new List<Socket>(value)); }
		}
	}
}
