using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for TalentGroup.
	/// </summary>
	[DataContract(Name = "talentGroup")]
	[Serializable]
	public class TalentGroup
	{
		/// <summary></summary>
		[DataMember(Name = "class")]
		public string Class;


		/// <summary></summary>
		[IgnoreDataMember]
		public List<TalentGroupGlyph> Glyphs;

		/// <summary></summary>
		[DataMember(Name = "glyphs")]
		public TalentGroupGlyph[] GlyphsValue
		{
			get { return (Glyphs == null ? null : Glyphs.ToArray()); }
			set { Glyphs = (value == null ? null : new List<TalentGroupGlyph>(value)); }
		}

		/// <summary></summary>
		[IgnoreDataMember]
		public List<PetSpecs> PetSpecs;

		/// <summary></summary>
		[DataMember(Name = "petSpecs")]
		public PetSpecs[] PetSpecsValue
		{
			get { return (PetSpecs == null ? null : PetSpecs.ToArray()); }
			set { PetSpecs = (value == null ? null : new List<PetSpecs>(value)); }
		}

		/// <summary></summary>
		[IgnoreDataMember]
		public List<Spec> Specs;

		/// <summary></summary>
		[DataMember(Name = "specs")]
		public Spec[] SpecsValue
		{
			get { return (Specs == null ? null : Specs.ToArray()); }
			set { Specs = (value == null ? null : new List<Spec>(value)); }
		}

		/// <summary></summary>
		[IgnoreDataMember]
		public List<List<TalentTree>> TalentTiers;

		/// <summary></summary>
		[DataMember(Name = "talents")]
		public TalentTree[][] TalentTiersValue
		{
			get
			{
				if (TalentTiers == null) { return null; }

				TalentTree[][] returnValue = new TalentTree[TalentTiers.Count][];

				for (int i = 0; i < TalentTiers.Count; i++)
				{
					returnValue[i] = TalentTiers[i].ToArray();
				}

				return returnValue;
			}

			set
			{
				TalentTiers = new List<List<TalentTree>>();

				for (int i = 0; i < value.Length; i++)
				{
					TalentTiers.Add(new List<TalentTree>(value[i]));
				}
			}
		}
	}
}
