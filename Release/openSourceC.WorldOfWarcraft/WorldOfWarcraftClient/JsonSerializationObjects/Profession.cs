using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for Profession.
	/// </summary>
	[DataContract(Name = "profession")]
	[Serializable]
	public class Profession
	{
		/// <summary></summary>
		[DataMember(Name = "icon")]
		public string Icon;

		/// <summary></summary>
		[DataMember(Name = "id")]
		public int Id;

		/// <summary></summary>
		[DataMember(Name = "max")]
		public int Max;

		/// <summary></summary>
		[DataMember(Name = "name")]
		public string Name;

		/// <summary></summary>
		[DataMember(Name = "rank")]
		public int Rank;


		/// <summary></summary>
		[IgnoreDataMember]
		public List<int> Recipes;

		/// <summary></summary>
		[DataMember(Name = "recipes")]
		public int[] RecipesValue
		{
			get { return (Recipes == null ? null : Recipes.ToArray()); }
			set { Recipes = (value == null ? null : new List<int>(value)); }
		}
	}
}
