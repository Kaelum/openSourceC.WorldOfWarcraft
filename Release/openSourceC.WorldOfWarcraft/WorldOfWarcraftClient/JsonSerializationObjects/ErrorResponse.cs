using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for ErrorResponse.
	/// </summary>
	[DataContract(Name = "response")]
	[Serializable]
	public class ErrorResponse
	{
		/// <summary>The error reason message.</summary>
		[DataMember(Name = "reason")]
		public string Reason;

		/// <summary>The error status</summary>
		[DataMember(Name = "status")]
		public string Status;
	}
}
