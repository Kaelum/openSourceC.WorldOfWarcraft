using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for CharacterStats.
	/// </summary>
	[DataContract(Name = "characterStats")]
	[Serializable]
	public class CharacterStats
	{
		/// <summary></summary>
		[DataMember(Name = "agi")]
		public int Agi;

		/// <summary></summary>
		[DataMember(Name = "armor")]
		public int Armor;

		/// <summary></summary>
		[DataMember(Name = "attackPower")]
		public int AttackPower;

		/// <summary></summary>
		[DataMember(Name = "block")]
		public double Block;

		/// <summary></summary>
		[DataMember(Name = "blockRating")]
		public int BlockRating;

		/// <summary></summary>
		[DataMember(Name = "crit")]
		public double Crit;

		/// <summary></summary>
		[DataMember(Name = "critRating")]
		public int CritRating;

		/// <summary></summary>
		[DataMember(Name = "dodge")]
		public double Dodge;

		/// <summary></summary>
		[DataMember(Name = "dodgeRating")]
		public int DodgeRating;

		/// <summary></summary>
		[DataMember(Name = "expertiseRating")]
		public int ExpertiseRating;

		/// <summary></summary>
		[DataMember(Name = "hasteRating")]
		public int HasteRating;

		/// <summary></summary>
		[DataMember(Name = "health")]
		public int Health;

		/// <summary></summary>
		[DataMember(Name = "hitPercent")]
		public double HitPercent;

		/// <summary></summary>
		[DataMember(Name = "hitRating")]
		public int HitRating;

		/// <summary></summary>
		[DataMember(Name = "int")]
		public int Int;

		/// <summary></summary>
		[DataMember(Name = "mainHandDmgMax")]
		public double MainHandDmgMax;

		/// <summary></summary>
		[DataMember(Name = "mainHandDmgMin")]
		public double MainHandDmgMin;

		/// <summary></summary>
		[DataMember(Name = "mainHandDps")]
		public double MainHandDps;

		/// <summary></summary>
		[DataMember(Name = "mainHandExpertise")]
		public int MainHandExpertise;

		/// <summary></summary>
		[DataMember(Name = "mainHandSpeed")]
		public double MainHandSpeed;

		/// <summary></summary>
		[DataMember(Name = "mana5")]
		public double Mana5;

		/// <summary></summary>
		[DataMember(Name = "mana5Combat")]
		public double Mana5Combat;

		/// <summary></summary>
		[DataMember(Name = "mastery")]
		public double Mastery;

		/// <summary></summary>
		[DataMember(Name = "masteryRating")]
		public int MasteryRating;

		/// <summary></summary>
		[DataMember(Name = "offHandDmgMax")]
		public double OffHandDmgMax;

		/// <summary></summary>
		[DataMember(Name = "offHandDmgMin")]
		public double OffHandDmgMin;

		/// <summary></summary>
		[DataMember(Name = "offHandDps")]
		public double OffHandDps;

		/// <summary></summary>
		[DataMember(Name = "offHandExpertise")]
		public int OffHandExpertise;

		/// <summary></summary>
		[DataMember(Name = "offHandSpeed")]
		public double OffHandSpeed;

		/// <summary></summary>
		[DataMember(Name = "parry")]
		public double Parry;

		/// <summary></summary>
		[DataMember(Name = "parryRating")]
		public int ParryRating;

		/// <summary></summary>
		[DataMember(Name = "power")]
		public int Power;

		///// <summary></summary>
		//[IgnoreDataMember]
		//public PowerTypeEnum PowerType;

		///// <summary></summary>
		//[DataMember(Name = "powerType")]
		//public string PowerTypeValue
		//{
		//	get { return PowerType.ToString().ToLowerInvariant(); }
		//	set { PowerType = (PowerTypeEnum)Enum.Parse(typeof(PowerTypeEnum), value, true); }
		//}

		/// <summary></summary>
		[IgnoreDataMember]
		public PowerTypeEnum PowerType;

		/// <summary></summary>
		[DataMember(Name = "powerType")]
		public string PowerTypeValue
		{
			get
			{
				switch (PowerType)
				{
					case PowerTypeEnum.RunicPower:
					{
						return "runic-power";
					}

					default:
					{
						return PowerType.ToString().ToLowerInvariant();
					}
				}
			}

			set
			{
				if (Enum.TryParse<PowerTypeEnum>(value, true, out PowerType)) { return; }

				switch (value.ToLowerInvariant())
				{
					case "runic-power":
					{
						PowerType = PowerTypeEnum.RunicPower;
						break;
					}
				}
			}
		}

		/// <summary></summary>
		[DataMember(Name = "pvpPower")]
		public double PvpPower;

		/// <summary></summary>
		[DataMember(Name = "pvpPowerRating")]
		public int PvpPowerRating;

		/// <summary></summary>
		[DataMember(Name = "pvpResilience")]
		public double PvpResilience;

		/// <summary></summary>
		[DataMember(Name = "pvpResilienceRating")]
		public int PvpResilienceRating;

		/// <summary></summary>
		[DataMember(Name = "rangedAttackPower")]
		public int RangedAttackPower;

		/// <summary></summary>
		[DataMember(Name = "rangedDmgMax")]
		public double RangedDmgMax;

		/// <summary></summary>
		[DataMember(Name = "rangedDmgMin")]
		public double RangedDmgMin;

		/// <summary></summary>
		[DataMember(Name = "rangedCrit")]
		public double RangedCrit;

		/// <summary></summary>
		[DataMember(Name = "rangedCritRating")]
		public int RangedCritRating;

		/// <summary></summary>
		[DataMember(Name = "rangedDps")]
		public double RangedDps;

		/// <summary></summary>
		[DataMember(Name = "rangedExpertise")]
		public double RangedExpertise;

		/// <summary></summary>
		[DataMember(Name = "rangedHitPercent")]
		public double RangedHitPercent;

		/// <summary></summary>
		[DataMember(Name = "rangedHitRating")]
		public int RangedHitRating;

		/// <summary></summary>
		[DataMember(Name = "rangedSpeed")]
		public double RangedSpeed;

		/// <summary></summary>
		[DataMember(Name = "spellCrit")]
		public double SpellCrit;

		/// <summary></summary>
		[DataMember(Name = "spellCritRating")]
		public int SpellCritRating;

		/// <summary></summary>
		[DataMember(Name = "spellHitPercent")]
		public double SpellHitPercent;

		/// <summary></summary>
		[DataMember(Name = "spellHitRating")]
		public int SpellHitRating;

		/// <summary></summary>
		[DataMember(Name = "spellPen")]
		public int SpellPen;

		/// <summary></summary>
		[DataMember(Name = "spellPower")]
		public int SpellPower;

		/// <summary></summary>
		[DataMember(Name = "spr")]
		public int Spr;

		/// <summary></summary>
		[DataMember(Name = "sta")]
		public int Sta;

		/// <summary></summary>
		[DataMember(Name = "str")]
		public int Str;
	}
}
