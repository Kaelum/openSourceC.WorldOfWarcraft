using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for CharacterClassesResponse.
	/// </summary>
	[DataContract(Name = "response")]
	[Serializable]
	public class CharacterClassesResponse : BaseResponse
	{
		/// <summary></summary>
		[IgnoreDataMember]
		public List<CharacterClass> Classes;

		/// <summary></summary>
		[DataMember(Name = "classes")]
		public CharacterClass[] ClassesValue
		{
			get { return (Classes == null ? null : Classes.ToArray()); }
			set { Classes = (value == null ? null : new List<CharacterClass>(value)); }
		}
	}
}
