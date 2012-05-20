using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for BaseResponse.
	/// </summary>
	[DataContract(Name = "response")]
	[Serializable]
	public abstract class BaseResponse
	{
		/// <summary></summary>
		[IgnoreDataMember]
		public string JsonResponse;
	}
}
