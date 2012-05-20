using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for ProfileAchievements.
	/// </summary>
	[DataContract(Name = "achievements")]
	[Serializable]
	public class ProfileAchievements
	{
		/// <summary></summary>
		[IgnoreDataMember]
		public List<int> AchievementsCompleted;

		/// <summary></summary>
		[DataMember(Name = "achievementsCompleted")]
		public int[] AchievementsCompletedValue
		{
			get { return (AchievementsCompleted == null ? null : AchievementsCompleted.ToArray()); }
			set { AchievementsCompleted = (value == null ? null : new List<int>(value)); }
		}

		/// <summary>This is the <see cref="T:DateTime"/> representation of <see cref="AchievementsCompletedTimestampValue"/></summary>
		[IgnoreDataMember]
		public List<DateTime> AchievementsCompletedTimestamp;

		/// <summary></summary>
		[DataMember(Name = "achievementsCompletedTimestamp")]
		public long[] AchievementsCompletedTimestampValue
		{
			get
			{
				if (AchievementsCompletedTimestamp == null) { return null; }

				return AchievementsCompletedTimestamp.ConvertAll<long>(
						delegate(DateTime obj) { return obj.ToUnixTime(); }
					).ToArray();
			}

			set
			{
				if (value == null)
				{
					AchievementsCompletedTimestamp = null;
				}
				else
				{
					AchievementsCompletedTimestamp = new List<long>(value).ConvertAll<DateTime>(
							delegate(long obj) { return obj.ToDateTime(); }
						);
				}
			}
		}

		/// <summary></summary>
		[IgnoreDataMember]
		public List<int> Criteria;

		/// <summary></summary>
		[DataMember(Name = "criteria")]
		public int[] CriteriaValue
		{
			get { return (Criteria == null ? null : Criteria.ToArray()); }
			set { Criteria = (value == null ? null : new List<int>(value)); }
		}

		/// <summary>This is the <see cref="T:DateTime"/> representation of <see cref="CriteriaCreatedValue"/></summary>
		[IgnoreDataMember]
		public List<DateTime> CriteriaCreated;

		/// <summary></summary>
		[DataMember(Name = "criteriaCreated")]
		public long[] CriteriaCreatedValue
		{
			get
			{
				if (CriteriaCreated == null) { return null; }

				return CriteriaCreated.ConvertAll<long>(
						delegate(DateTime obj) { return obj.ToUnixTime(); }
					).ToArray();
			}

			set
			{
				if (value == null)
				{
					CriteriaCreated = null;
				}
				else
				{
					CriteriaCreated = new List<long>(value).ConvertAll<DateTime>(
							delegate(long obj) { return obj.ToDateTime(); }
						);
				}
			}
		}

		/// <summary></summary>
		[IgnoreDataMember]
		public List<long> CriteriaQuantity;

		/// <summary></summary>
		[DataMember(Name = "criteriaQuantity")]
		public long[] CriteriaQuantityValue
		{
			get { return (CriteriaQuantity == null ? null : CriteriaQuantity.ToArray()); }
			set { CriteriaQuantity = (value == null ? null : new List<long>(value)); }
		}

		/// <summary>This is the <see cref="T:DateTime"/> representation of <see cref="CriteriaTimestampValue"/></summary>
		[IgnoreDataMember]
		public List<DateTime> CriteriaTimestamp;

		/// <summary></summary>
		[DataMember(Name = "criteriaTimestamp")]
		public long[] CriteriaTimestampValue
		{
			get
			{
				if (CriteriaTimestamp == null) { return null; }

				return CriteriaTimestamp.ConvertAll<long>(
						delegate(DateTime obj) { return obj.ToUnixTime(); }
					).ToArray();
			}

			set
			{
				if (value == null)
				{
					CriteriaTimestamp = null;
				}
				else
				{
					CriteriaTimestamp = new List<long>(value).ConvertAll<DateTime>(
							delegate(long obj) { return obj.ToDateTime(); }
						);
				}
			}
		}
	}
}
