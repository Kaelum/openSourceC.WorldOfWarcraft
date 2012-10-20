using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for ItemSetResponse.
	/// </summary>
	[DataContract(Name = "response")]
	[Serializable]
	public class ItemSetResponse : BaseResponse
	{
		/// <summary></summary>
		[DataMember(Name = "id")]
		public int Id;

		/// <summary></summary>
		[DataMember(Name = "name")]
		public string Name;


		/// <summary></summary>
		[IgnoreDataMember]
		public List<int> Items;

		/// <summary></summary>
		[DataMember(Name = "items")]
		public int[] ItemsValue
		{
			get { return (Items == null ? null : Items.ToArray()); }
			set { Items = (value == null ? null : new List<int>(value)); }
		}

		/// <summary></summary>
		[IgnoreDataMember]
		public List<ItemSetBonus> SetBonuses;

		/// <summary></summary>
		[DataMember(Name = "setBonuses")]
		public ItemSetBonus[] SetBonusesValue
		{
			get { return (SetBonuses == null ? null : SetBonuses.ToArray()); }
			set { SetBonuses = (value == null ? null : new List<ItemSetBonus>(value)); }
		}
	}
}
