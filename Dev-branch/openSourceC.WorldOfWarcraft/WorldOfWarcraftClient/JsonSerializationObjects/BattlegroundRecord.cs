using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for BattlegroundRecord.
	/// </summary>
	[DataContract(Name = "battlegroundRecord")]
	[Serializable]
	public class BattlegroundRecord
	{
		/// <summary></summary>
		[DataMember(Name = "bgRating")]
		public int BattlegroundlRating;

		/// <summary>This is the <see cref="T:DateTime"/> representation of <see cref="LastModifiedValue"/></summary>
		[IgnoreDataMember]
		public DateTime LastModified;

		/// <summary></summary>
		[DataMember(Name = "lastModified")]
		public long LastModifiedValue
		{
			get { return LastModified.ToUnixTime(); }
			set { LastModified = value.ToDateTime(); }
		}

		/// <summary></summary>
		[DataMember(Name = "losses")]
		public int Losses;

		/// <summary></summary>
		[DataMember(Name = "played")]
		public int Played;

		/// <summary></summary>
		[DataMember(Name = "rank")]
		public int Rank;

		/// <summary></summary>
		[DataMember(Name = "wins")]
		public int Wins;


		/// <summary></summary>
		[DataMember(Name = "battlegroup")]
		public Battlegroup Battlegroup;

		/// <summary></summary>
		[DataMember(Name = "character")]
		public Character Character;

		/// <summary></summary>
		[DataMember(Name = "realm")]
		public Realm Realm;
	}
}
