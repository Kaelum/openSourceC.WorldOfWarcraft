using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace openSourceC.WorldOfWarcraft
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
			get { return WowJavaScriptConverter.ConvertDateTimeToLong(LastModifiedValue); }
			set { LastModifiedValue = WowJavaScriptConverter.ConvertLongToDateTime(value); }
		}

		/// <summary></summary>
		[ScriptIgnore]
		public DateTime LastModifiedValue { get; set; }
	}
}
