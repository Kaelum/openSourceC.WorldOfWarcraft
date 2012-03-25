using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for AuctionData.
	/// </summary>
	[Serializable]
	public class AuctionData
	{
		/// <summary></summary>
		public string Url;

		/// <summary></summary>
		public long LastModified
		{
			get { return LastModifiedValue.ToUnixTime(); }
			set { LastModifiedValue = value.ToDateTime(); }
		}

		/// <summary>This is the <see cref="T:DateTime"/> representation of <see cref="LastModified"/></summary>
		[ScriptIgnore]
		public DateTime LastModifiedValue { get; set; }

		/// <summary>This is a placeholder for that actual deserialized data file.</summary>
		[ScriptIgnore]
		public AuctionDataFile Data { get; set; }
	}
}
