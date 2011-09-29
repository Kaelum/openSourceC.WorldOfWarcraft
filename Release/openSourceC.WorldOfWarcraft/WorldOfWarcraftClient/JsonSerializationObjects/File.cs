using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for File.
	/// </summary>
	[Serializable]
	public class File
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
	}
}
