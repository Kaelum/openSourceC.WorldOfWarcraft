using System;
using System.Text;
using System.Web;

namespace openSourceC.WorldOfWarcraft
{
	/// <summary>
	///		Summary description for Extensions.
	/// </summary>
	public static class Extensions
	{
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
			if (stringBuilder.Length != 0) { stringBuilder.Append('&'); }

			return stringBuilder.Append(HttpUtility.UrlEncode(key)).Append('=').Append(HttpUtility.UrlEncode(value));
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
