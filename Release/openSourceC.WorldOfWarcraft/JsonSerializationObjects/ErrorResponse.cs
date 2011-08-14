using System;
using System.Collections.Generic;

namespace openSourceC.WorldOfWarcraft
{
	/// <summary>
	///		Summary description for ErrorResponse.
	/// </summary>
	[Serializable]
	public class ErrorResponse
	{
		/// <summary>The error status</summary>
		public string Status;

		/// <summary>The error reason message.</summary>
		public string Reason;
	}
}
