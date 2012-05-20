using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for CharacterClass.
	/// </summary>
	[DataContract(Name = "characterClass")]
	[Serializable]
	public class CharacterClass
	{
		/// <summary></summary>
		[DataMember(Name = "id")]
		public int Id;

		/// <summary></summary>
		[DataMember(Name = "mask")]
		public int Mask;

		/// <summary></summary>
		[DataMember(Name = "name")]
		public string Name;

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
	}
}
