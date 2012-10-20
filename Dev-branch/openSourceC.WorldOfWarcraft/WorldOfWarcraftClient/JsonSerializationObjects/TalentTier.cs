using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for TalentTier.
	/// </summary>
	[DataContract(Name = "talentTier")]
	[Serializable]
	public class TalentTier
	{
		/// <summary></summary>
		[IgnoreDataMember]
		public List<TalentTree> TalentColumns;

		/// <summary></summary>
		[DataMember(Name = "")]
		public TalentTree[] TalentColumnsValue
		{
			get { return (TalentColumns == null ? null : TalentColumns.ToArray()); }
			set { TalentColumns = (value == null ? null : new List<TalentTree>(value)); }
		}
	}
}
