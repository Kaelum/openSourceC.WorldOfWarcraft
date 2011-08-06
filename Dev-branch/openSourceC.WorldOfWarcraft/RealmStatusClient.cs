using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace openSourceC.WorldOfWarcraft
{
	/// <summary>
	///		Summary descritpion for RealmStatusClient.
	/// </summary>
	//[DebuggerStepThrough()]
	public class RealmStatusClient
	{
		private const string _realmsQueryStringKey = "realms";
		private const string _jsonpQueryStringKey = "jsonp";

		/// <summary>Gets or sets the username.</summary>
		public string Username { get; set; }

		/// <summary>Gets or sets the password.</summary>
		public string Password { get; set; }


		#region Constructors

		/// <summary>
		///		Class constructor.
		/// </summary>
		public RealmStatusClient() { }

		/// <summary>
		///		Class constructor.
		/// </summary>
		/// <param name="username">The username.</param>
		/// <param name="password">The password.</param>
		public RealmStatusClient(string username, string password)
		{
			Username = username;
			Password = password;
		}

		#endregion

		#region Http Client Calls

		/// <summary>
		///		Gets the status of the specified realms in JSON format.
		/// </summary>
		/// <param name="region">The BATTLE.NET region key defined in App.config. (null = default)</param>
		/// <param name="realms">A comma seperated list of realms to retrieve. (optional)</param>
		/// <param name="jsonp">A JSONP callback method to wrap around the JSON payload. (optional)</param>
		/// <returns>
		///		A JSON formatted string.  If the realms parameter is not specified, or is null, the
		///		status for all realms in the region is returned.
		/// </returns>
		public string GetRawStatus(string region, string realms = null, string jsonp = null)
		{
			StringBuilder query = new StringBuilder();

			if (!string.IsNullOrWhiteSpace(realms))
			{
				query.AppendQueryStringPair(_realmsQueryStringKey, realms);
			}

			RegionSettings settings = WorldOfWarcraftSection.Instance.Regions[region ?? WorldOfWarcraftSection.Instance.DefaultRegion];
			UriBuilder requestUri = new UriBuilder(settings.BaseUrl);
			requestUri.Query = query.ToString();

			HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(requestUri.Uri);
			request.Credentials = new NetworkCredential(Username, Password);

			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			string responseString;

			using (Stream stream = response.GetResponseStream())
			using (StreamReader reader = new StreamReader(stream))
			{
				return responseString = reader.ReadToEnd();
			}
		}

		/// <summary>
		///		Gets the status of the specified realms in JSON format.
		/// </summary>
		/// <param name="region">The BATTLE.NET region.</param>
		/// <param name="realms">An <see cref="T:IEnumerable&lt;string&gt;"/> list of realms to retrieve.</param>
		/// <param name="jsonp">A JSONP callback method to wrap around the JSON payload. (optional)</param>
		/// <returns>
		///		A JSON formatted string.
		/// </returns>
		public string GetRawStatus(string region, IEnumerable<string> realms, string jsonp = null)
		{
			return GetRawStatus(region, JoinList(realms), jsonp);
		}

		/// <summary>
		///		Gets the status of the specified realms as a strong typed object.
		/// </summary>
		/// <param name="region">The BATTLE.NET region key defined in App.config.</param>
		/// <param name="realms">A comma seperated list of realms to retrieve.</param>
		/// <returns>
		///		A <see cref="List&lt;Realm&gt;"/> object.  If the realms parameter is not
		///		specified, or is null, the status for all realms in the region is returned.
		/// </returns>
		public List<Realm> GetStatus(string region, string realms = null)
		{
			string jsonResponse = GetRawStatus(region, realms);

			JavaScriptSerializer serializer = new JavaScriptSerializer(new RealmStatusTypeResolver());
			RealmStatusResponse deserializedResponse = serializer.Deserialize<RealmStatusResponse>(jsonResponse);
			//string reserializedResponse = serializer.Serialize(deserializedResponse);

			return (deserializedResponse == null ? null : deserializedResponse.Realms);
		}

		/// <summary>
		///		Gets the status of the specified realms as a strong typed object.
		/// </summary>
		/// <param name="region">The BATTLE.NET region.</param>
		/// <param name="realms">An <see cref="T:IEnumerable&lt;string&gt;"/> list of realms to retrieve.</param>
		/// <returns>
		///		A <see cref="List&lt;Realm&gt;"/> object.
		/// </returns>
		public List<Realm> GetStatus(string region, IEnumerable<string> realms)
		{
			return GetStatus(region, JoinList(realms));
		}

		#endregion

		#region Private Methods

		private string JoinList(IEnumerable<string> list)
		{
			if (list == null)
			{
				return null;
			}

			StringBuilder sb = new StringBuilder();

			foreach (string item in list)
			{
				if (sb.Length > 0)
				{
					sb.Append(",");
				}

				sb.Append(item);
			}

			return sb.ToString();
		}

		#endregion
	}
}
