using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for PetTypesResponse.
	/// </summary>
	[DataContract(Name = "response")]
	[Serializable]
	public class PetTypesResponse : BaseResponse
	{
		/// <summary></summary>
		[IgnoreDataMember]
		public List<PetType> PetTypes;

		/// <summary></summary>
		[DataMember(Name = "petTypes")]
		public PetType[] PetTypesValue
		{
			get { return (PetTypes == null ? null : PetTypes.ToArray()); }
			set { PetTypes = (value == null ? null : new List<PetType>(value)); }
		}
	}
}
