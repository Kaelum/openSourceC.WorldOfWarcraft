using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Web;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary description for WowExtensions.
	/// </summary>
	public static class WowExtensions
	{
		/// <summary>January 1, 1970 @ Midnight UTC.</summary>
		public static readonly DateTime ZeroDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);


		/// <summary>
		///		Appends a <see cref="M:HttpUtility.UrlEncode"/> encoded query-string key-value pair
		///		with a 32-bit signed integer value to the end of the <see cref="StringBuilder"/>
		///		object.
		/// </summary>
		/// <param name="stringBuilder">The <see cref="StringBuilder"/> objecy.</param>
		/// <param name="key">The query-string key to append.</param>
		/// <param name="value">The query-string value to append.</param>
		internal static StringBuilder AppendQueryStringPair(this StringBuilder stringBuilder, string key, bool? value)
		{
			if (!value.HasValue) { return stringBuilder; }

			return AppendQueryStringPair(stringBuilder, key, value.Value.ToString().ToLowerInvariant());
		}

		/// <summary>
		///		Appends a <see cref="M:HttpUtility.UrlEncode"/> encoded query-string key-value pair
		///		with a 32-bit signed integer value to the end of the <see cref="StringBuilder"/>
		///		object.
		/// </summary>
		/// <param name="stringBuilder">The <see cref="StringBuilder"/> objecy.</param>
		/// <param name="key">The query-string key to append.</param>
		/// <param name="value">The query-string value to append.</param>
		internal static StringBuilder AppendQueryStringPair(this StringBuilder stringBuilder, string key, int? value)
		{
			if (!value.HasValue) { return stringBuilder; }

			return AppendQueryStringPair(stringBuilder, key, value.Value.ToString());
		}

		/// <summary>
		///		Appends a <see cref="M:HttpUtility.UrlEncode"/> encoded query-string key-value pair
		///		to the end of the <see cref="StringBuilder"/> object.
		/// </summary>
		/// <param name="stringBuilder">The <see cref="StringBuilder"/> objecy.</param>
		/// <param name="key">The query-string key.</param>
		/// <param name="value">The query-string value.</param>
		/// <returns>
		///		The modified <see cref="StringBuilder"/> object.
		/// </returns>
		internal static StringBuilder AppendQueryStringPair(this StringBuilder stringBuilder, string key, string value)
		{
			if (string.IsNullOrWhiteSpace(value)) { return stringBuilder; }

			if (stringBuilder.Length != 0) { stringBuilder.Append('&'); }

			return stringBuilder.Append(HttpUtility.UrlEncode(key)).Append('=').Append(HttpUtility.UrlEncode(value));
		}

		/// <summary>
		///		Converts a UNIX time (long) to a <see cref="T:DateTime"/>.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static DateTime ToDateTime(this long value)
		{
			return ZeroDate.AddMilliseconds(value);
		}

		/// <summary>
		///		
		/// </summary>
		/// <param name="enumerator"></param>
		/// <returns></returns>
		internal static string ToEnumMemberString(this Enum enumerator)
		{
			EnumMemberAttribute attribute = enumerator.GetType().GetCustomAttributes(typeof(EnumMemberAttribute), true).SingleOrDefault() as EnumMemberAttribute;

			return (attribute == null ? enumerator.ToString().ToLowerInvariant() : attribute.Value);
		}

		/// <summary>
		///		Converts a <see cref="T:DateTime"/> to a UNIX time (long).
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static long ToUnixTime(this DateTime value)
		{
			return (long)value.Subtract(ZeroDate).TotalMilliseconds;
		}

		/// <summary>
		///		Returns a count of the words in the specified string.
		/// </summary>
		/// <param name="str">The string</param>
		/// <returns>
		///		A count of the words found.
		/// </returns>
		public static int WordCount(this String str)
		{
			return str.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
		}
	}
}
