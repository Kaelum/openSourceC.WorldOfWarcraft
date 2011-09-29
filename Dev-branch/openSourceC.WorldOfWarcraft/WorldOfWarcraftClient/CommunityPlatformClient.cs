using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Security.Cryptography;

using openSourceC.WorldOfWarcraft;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary descritpion for CommunityPlatformClient.
	/// </summary>
	//[DebuggerStepThrough()]
	public class CommunityPlatformClient
	{
		private const string _apiKeyArenaTeam = "arenaTeam";
		private const string _apiKeyAuctionData = "auctionData";
		private const string _apiKeyCharacterAchievements = "characterAchievements";
		private const string _apiKeyCharacterClasses = "characterClasses";
		private const string _apiKeyCharacterProfile = "characterProfile";
		private const string _apiKeyCharacterRaces = "characterRaces";
		private const string _apiKeyGuildAchievements = "guildAchievements";
		private const string _apiKeyGuildPerks = "guildPerks";
		private const string _apiKeyGuildProfile = "guildProfile";
		private const string _apiKeyGuildRewards = "guildRewards";
		private const string _apiKeyItem = "item";
		private const string _apiKeyItemClasses = "itemClasses";
		private const string _apiKeyQuest = "quest";
		private const string _apiKeyRealmStatus = "realmStatus";

		private const string _fieldsQueryStringKey = "fields";
		private const string _localeQueryStringKey = "locale";
		private const string _realmsQueryStringKey = "realms";

		private string _currentRegionKey;
		private string _currentLocale;


		#region Constructors

		/// <summary>
		///		Class constructor.
		/// </summary>
		public CommunityPlatformClient()
		{
			_currentRegionKey = WorldOfWarcraftSection.Instance.Regions.Default;
			_currentLocale = null;
		}

		#endregion

		#region Public Properties

		/// <summary>
		///		Gets or sets the current region key.
		///		<remarks>Resets <see cref="P:CurrentLocale"/> to null.</remarks>
		///	</summary>
		public string CurrentRegionKey
		{
			get { return _currentRegionKey; }

			set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					_currentRegionKey = WorldOfWarcraftSection.Instance.Regions.Default;
					_currentLocale = null;
					return;
				}

				if (WorldOfWarcraftSection.Instance.Regions[value] == null)
				{
					throw new IndexOutOfRangeException(string.Format("Unknown region key: {0}.", value));
				}

				_currentRegionKey = value;
				_currentLocale = null;
			}
		}

		/// <summary>
		///		Gets or sets the current locale.
		///	</summary>
		public string CurrentLocale
		{
			get { return _currentLocale; }

			set
			{
				if (string.IsNullOrWhiteSpace(_currentRegionKey))
				{
					throw new SystemException("'CurrentRegionKey' not set.");
				}

				if (WorldOfWarcraftSection.Instance.Regions[_currentRegionKey].Locales[value] == null)
				{
					throw new IndexOutOfRangeException(string.Format("Unknown locale: {0}.", value));
				}

				_currentLocale = value;
			}
		}

		#endregion

		#region Private Properties

		private ApiSettingsCollection ApiSettings
		{
			get { return WorldOfWarcraftSection.Instance.ApiSettings; }
		}

		/// <summary>
		///		Gets the private key.
		///	</summary>
		private string PrivateKey
		{
			get { return WorldOfWarcraftSection.Instance.PrivateKey; }
		}

		/// <summary>
		///		Gets the public key.
		///	</summary>
		private string PublicKey
		{
			get { return WorldOfWarcraftSection.Instance.PublicKey; }
		}

		private bool UseAuthorization
		{
			get { return (!string.IsNullOrWhiteSpace(PrivateKey) & !string.IsNullOrWhiteSpace(PublicKey)); }
		}

		#endregion

		#region Public Methods

		/// <summary>
		///		Gets the file at the specified url and returns it as a string.
		/// </summary>
		/// <param name="url">The url of the file.</param>
		/// <returns>
		///		A <see cref="string"/> containing the contents of the file.
		/// </returns>
		public string GetFile(string url)
		{
			HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);

			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			string responseString;

			using (Stream stream = response.GetResponseStream())
			using (StreamReader reader = new StreamReader(stream))
			{
				return (responseString = reader.ReadToEnd());
			}
		}

		#endregion

		#region API Methods

		#region Arena Team

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetArenaTeam"/>.
		/// </summary>
		/// <param name="jsonResponse">The string to deserialize.</param>
		/// <returns>
		///		A deserialized <see cref="ArenaTeamResponse"/> object.
		/// </returns>
		public ArenaTeamResponse DeserializeArenaTeamResponse(string jsonResponse)
		{
			JavaScriptSerializer serializer = new JavaScriptSerializer();
			ArenaTeamResponse deserializedResponse = serializer.Deserialize<ArenaTeamResponse>(jsonResponse);

			return deserializedResponse;
		}

		/// <summary>
		///		Gets the profile of the specified arena team on the specified realm.
		/// </summary>
		/// <param name="realm">The realm that the team is on.</param>
		/// <param name="teamSize">The team size.</param>
		/// <param name="teamName">The name of the team.</param>
		/// <returns>
		///		A deserialized <see cref="ArenaTeamResponse"/> object.
		/// </returns>
		public ArenaTeamResponse GetArenaTeam(string realm, ArenaTeamSizeEnum teamSize, string teamName)
		{
			string jsonResponse;

			return GetArenaTeam(out jsonResponse, realm, teamSize, teamName);
		}

		/// <summary>
		///		Gets the profile of the specified arena team on the specified realm.
		/// </summary>
		/// <param name="realm">The realm that the team is on.</param>
		/// <param name="teamSize">The team size.</param>
		/// <param name="teamName">The name of the team.</param>
		/// <param name="jsonResponse">The JSON response returned from the API call.</param>
		/// <returns>
		///		A deserialized <see cref="ArenaTeamResponse"/> object.
		/// </returns>
		public ArenaTeamResponse GetArenaTeam(out string jsonResponse, string realm, ArenaTeamSizeEnum teamSize, string teamName)
		{
			StringBuilder query = new StringBuilder();
			query.AppendQueryStringPair(_localeQueryStringKey, CurrentLocale);

			string teamSizeName = teamSize.ToString("F").Replace("Arena", string.Empty);
			string urlPath = string.Format(ApiSettings[_apiKeyArenaTeam].Path, realm, teamSizeName, teamName);

			jsonResponse = GetResponse(urlPath, query.ToString());

			return DeserializeArenaTeamResponse(jsonResponse);
		}

		#endregion

		#region Auction Data File

		/// <summary>
		///		Deserializes a JSON formatted auction data file.
		/// </summary>
		/// <param name="jsonFile">The string to deserialize.</param>
		/// <returns>
		///		A <see cref="T:AuctionDataFile"/> object.
		/// </returns>
		public AuctionDataFile DeserializeAuctionDataFile(string jsonFile)
		{
			JavaScriptSerializer serializer = new JavaScriptSerializer();
			serializer.MaxJsonLength = int.MaxValue;
			AuctionDataFile deserializedResponse = serializer.Deserialize<AuctionDataFile>(jsonFile);

			return deserializedResponse;
		}

		/// <summary>
		///		Gets the auction data file at the specified url.
		/// </summary>
		/// <param name="url">The url of the file.</param>
		/// <returns>
		///		A <see cref="T:AuctionDataFile"/> object.
		/// </returns>
		public AuctionDataFile GetAuctionDataFile(string url)
		{
			string jsonFile;

			return GetAuctionDataFile(out jsonFile, url);
		}

		/// <summary>
		///		Gets the auction data file at the specified url.
		/// </summary>
		/// <param name="jsonFile">The JSON formatted response file returned.</param>
		/// <param name="url">The url of the file.</param>
		/// <returns>
		///		A <see cref="T:AuctionDataFile"/> object.
		/// </returns>
		public AuctionDataFile GetAuctionDataFile(out string jsonFile, string url)
		{
			jsonFile = GetFile(url);

			return DeserializeAuctionDataFile(jsonFile);
		}

		#endregion

		#region Auction Data Header

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetAuctionDataHeader"/>.
		/// </summary>
		/// <param name="jsonResponse">The string to deserialize.</param>
		/// <returns>
		///		A <see cref="T:List&lt;File&gt;"/> collection.
		/// </returns>
		public List<File> DeserializeAuctionDataHeaderResponse(string jsonResponse)
		{
			JavaScriptSerializer serializer = new JavaScriptSerializer();
			AuctionDataHeaderResponse deserializedResponse = serializer.Deserialize<AuctionDataHeaderResponse>(jsonResponse);

			return (deserializedResponse == null ? null : deserializedResponse.Files);
		}

		/// <summary>
		///		Gets the auction house data dump header for the specified realm.
		/// </summary>
		/// <param name="realm">The realm to receive auction house data for.</param>
		/// <returns>
		///		A JSON formatted string.
		/// </returns>
		public List<File> GetAuctionDataHeader(string realm)
		{
			string jsonResponse;

			return GetAuctionDataHeader(out jsonResponse, realm);
		}

		/// <summary>
		///		Gets the auction house data dump header for the specified realm.
		/// </summary>
		/// <param name="jsonResponse">The JSON response returned from the API call.</param>
		/// <param name="realm">The realm to receive auction house data for.</param>
		/// <returns>
		///		A JSON formatted string.
		/// </returns>
		public List<File> GetAuctionDataHeader(out string jsonResponse, string realm)
		{
			StringBuilder query = new StringBuilder();
			query.AppendQueryStringPair(_localeQueryStringKey, CurrentLocale);

			string urlPath = string.Format(ApiSettings[_apiKeyAuctionData].Path, realm);

			jsonResponse = GetResponse(urlPath, query.ToString());

			return DeserializeAuctionDataHeaderResponse(jsonResponse);
		}

		#endregion

		#region Character Achievements

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetCharacterAchievements"/>.
		/// </summary>
		/// <param name="jsonResponse">The string to deserialize.</param>
		/// <returns>
		///		A deserialized <see cref="List&lt;DataAchievement&gt;"/> object.
		/// </returns>
		public List<DataAchievement> DeserializeCharacterAchievementsResponse(string jsonResponse)
		{
			JavaScriptSerializer serializer = new JavaScriptSerializer();
			DataAchievementsResponse deserializedResponse = serializer.Deserialize<DataAchievementsResponse>(jsonResponse);

			return (deserializedResponse == null ? null : deserializedResponse.Achievements);
		}

		/// <summary>
		///		Gets the character achievements.
		/// </summary>
		/// <returns>
		///		A deserialized <see cref="List&lt;DataAchievement&gt;"/> object.
		/// </returns>
		public List<DataAchievement> GetCharacterAchievements()
		{
			string jsonResponse;

			return GetCharacterAchievements(out jsonResponse);
		}

		/// <summary>
		///		Gets the character achievements.
		/// </summary>
		/// <param name="jsonResponse">The JSON response returned from the API call.</param>
		/// <returns>
		///		A deserialized <see cref="List&lt;DataAchievement&gt;"/> object.
		/// </returns>
		public List<DataAchievement> GetCharacterAchievements(out string jsonResponse)
		{
			StringBuilder query = new StringBuilder();
			query.AppendQueryStringPair(_localeQueryStringKey, CurrentLocale);

			string urlPath = ApiSettings[_apiKeyCharacterAchievements].Path;

			jsonResponse = GetResponse(urlPath, query.ToString());

			return DeserializeCharacterAchievementsResponse(jsonResponse);
		}

		#endregion

		#region Character Classes

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetCharacterClasses"/>.
		/// </summary>
		/// <param name="jsonResponse">The string to deserialize.</param>
		/// <returns>
		///		A deserialized <see cref="List&lt;CharacterClass&gt;"/> object.
		/// </returns>
		public List<CharacterClass> DeserializeCharacterClassesResponse(string jsonResponse)
		{
			JavaScriptSerializer serializer = new JavaScriptSerializer();
			CharacterClassesResponse deserializedResponse = serializer.Deserialize<CharacterClassesResponse>(jsonResponse);

			return (deserializedResponse == null ? null : deserializedResponse.Classes);
		}

		/// <summary>
		///		Gets the character classes.
		/// </summary>
		/// <returns>
		///		A deserialized <see cref="List&lt;CharacterClass&gt;"/> object.
		/// </returns>
		public List<CharacterClass> GetCharacterClasses()
		{
			string jsonResponse;

			return GetCharacterClasses(out jsonResponse);
		}

		/// <summary>
		///		Gets the character classes.
		/// </summary>
		/// <param name="jsonResponse">The JSON response returned from the API call.</param>
		/// <returns>
		///		A deserialized <see cref="List&lt;CharacterClass&gt;"/> object.
		/// </returns>
		public List<CharacterClass> GetCharacterClasses(out string jsonResponse)
		{
			StringBuilder query = new StringBuilder();
			query.AppendQueryStringPair(_localeQueryStringKey, CurrentLocale);

			string urlPath = ApiSettings[_apiKeyCharacterClasses].Path;

			jsonResponse = GetResponse(urlPath, query.ToString());

			return DeserializeCharacterClassesResponse(jsonResponse);
		}

		#endregion

		#region Character Profile

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetCharacterProfile"/>.
		/// </summary>
		/// <param name="jsonResponse">The string to deserialize.</param>
		/// <returns>
		///		A deserialized <see cref="CharacterProfileResponse"/> object.
		/// </returns>
		public CharacterProfileResponse DeserializeCharacterProfileResponse(string jsonResponse)
		{
			JavaScriptSerializer serializer = new JavaScriptSerializer();
			CharacterProfileResponse deserializedResponse = serializer.Deserialize<CharacterProfileResponse>(jsonResponse);

			return deserializedResponse;
		}

		/// <summary>
		///		Gets the profile of the specified character on the specified realm.
		/// </summary>
		/// <param name="realm">The realm that the character is on.</param>
		/// <param name="character">The name of the character.</param>
		/// <param name="fields">A bitwise combination of the enumeration values.</param>
		/// <returns>
		///		A deserialized <see cref="CharacterProfileResponse"/> object.
		/// </returns>
		public CharacterProfileResponse GetCharacterProfile(string realm, string character, CharacterProfileOptionalFieldsEnum fields)
		{
			string jsonResponse;

			return GetCharacterProfile(out jsonResponse, realm, character, fields);
		}

		/// <summary>
		///		Gets the profile of the specified character on the specified realm.
		/// </summary>
		/// <param name="jsonResponse">The JSON response returned from the API call.</param>
		/// <param name="realm">The realm that the character is on.</param>
		/// <param name="character">The name of the character.</param>
		/// <param name="fields">A bitwise combination of the enumeration values.</param>
		/// <returns>
		///		A deserialized <see cref="CharacterProfileResponse"/> object.
		/// </returns>
		public CharacterProfileResponse GetCharacterProfile(out string jsonResponse, string realm, string character, CharacterProfileOptionalFieldsEnum fields)
		{
			StringBuilder query = new StringBuilder();

			if (fields != CharacterProfileOptionalFieldsEnum.None)
			{
				query.AppendQueryStringPair(_fieldsQueryStringKey, fields.ToString("F").ToLower().Replace(", ", ","));
			}

			query.AppendQueryStringPair(_localeQueryStringKey, CurrentLocale);

			string urlPath = string.Format(ApiSettings[_apiKeyCharacterProfile].Path, realm, character);

			jsonResponse = GetResponse(urlPath, query.ToString());

			return DeserializeCharacterProfileResponse(jsonResponse);
		}

		#endregion

		#region Character Races

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetCharacterRaces"/>.
		/// </summary>
		/// <param name="jsonResponse">The string to deserialize.</param>
		/// <returns>
		///		A deserialized <see cref="List&lt;CharacterClass&gt;"/> object.
		/// </returns>
		public List<CharacterRace> DeserializeCharacterRacesResponse(string jsonResponse)
		{
			JavaScriptSerializer serializer = new JavaScriptSerializer();
			CharacterRacesResponse deserializedResponse = serializer.Deserialize<CharacterRacesResponse>(jsonResponse);

			return (deserializedResponse == null ? null : deserializedResponse.Races);
		}

		/// <summary>
		///		Gets the character races.
		/// </summary>
		/// <returns>
		///		A deserialized <see cref="List&lt;CharacterClass&gt;"/> object.
		/// </returns>
		public List<CharacterRace> GetCharacterRaces()
		{
			string jsonResponse;

			return GetCharacterRaces(out jsonResponse);
		}

		/// <summary>
		///		Gets the character races.
		/// </summary>
		/// <param name="jsonResponse">The JSON response returned from the API call.</param>
		/// <returns>
		///		A deserialized <see cref="List&lt;CharacterClass&gt;"/> object.
		/// </returns>
		public List<CharacterRace> GetCharacterRaces(out string jsonResponse)
		{
			StringBuilder query = new StringBuilder();
			query.AppendQueryStringPair(_localeQueryStringKey, CurrentLocale);

			string urlPath = ApiSettings[_apiKeyCharacterRaces].Path;

			jsonResponse = GetResponse(urlPath, query.ToString());

			return DeserializeCharacterRacesResponse(jsonResponse);
		}

		#endregion

		#region Guild Achievements

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetGuildAchievements"/>.
		/// </summary>
		/// <param name="jsonResponse">The string to deserialize.</param>
		/// <returns>
		///		A deserialized <see cref="List&lt;DataAchievement&gt;"/> object.
		/// </returns>
		public List<DataAchievement> DeserializeGuildAchievementsResponse(string jsonResponse)
		{
			JavaScriptSerializer serializer = new JavaScriptSerializer();
			DataAchievementsResponse deserializedResponse = serializer.Deserialize<DataAchievementsResponse>(jsonResponse);

			return (deserializedResponse == null ? null : deserializedResponse.Achievements);
		}

		/// <summary>
		///		Gets the guild achievements.
		/// </summary>
		/// <returns>
		///		A deserialized <see cref="List&lt;DataAchievement&gt;"/> object.
		/// </returns>
		public List<DataAchievement> GetGuildAchievements()
		{
			string jsonResponse;

			return GetGuildAchievements(out jsonResponse);
		}

		/// <summary>
		///		Gets the guild achievements.
		/// </summary>
		/// <param name="jsonResponse">The JSON response returned from the API call.</param>
		/// <returns>
		///		A deserialized <see cref="List&lt;DataAchievement&gt;"/> object.
		/// </returns>
		public List<DataAchievement> GetGuildAchievements(out string jsonResponse)
		{
			StringBuilder query = new StringBuilder();
			query.AppendQueryStringPair(_localeQueryStringKey, CurrentLocale);

			string urlPath = ApiSettings[_apiKeyGuildAchievements].Path;

			jsonResponse = GetResponse(urlPath, query.ToString());

			return DeserializeGuildAchievementsResponse(jsonResponse);
		}

		#endregion

		#region Guild Perks

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetGuildPerks"/>.
		/// </summary>
		/// <param name="jsonResponse">The string to deserialize.</param>
		/// <returns>
		///		A deserialized <see cref="List&lt;GuildClass&gt;"/> object.
		/// </returns>
		public List<GuildPerk> DeserializeGuildPerksResponse(string jsonResponse)
		{
			JavaScriptSerializer serializer = new JavaScriptSerializer();
			GuildPerksResponse deserializedResponse = serializer.Deserialize<GuildPerksResponse>(jsonResponse);

			return (deserializedResponse == null ? null : deserializedResponse.Perks);
		}

		/// <summary>
		///		Gets the guild perks.
		/// </summary>
		/// <returns>
		///		A deserialized <see cref="List&lt;GuildClass&gt;"/> object.
		/// </returns>
		public List<GuildPerk> GetGuildPerks()
		{
			string jsonResponse;

			return GetGuildPerks(out jsonResponse);
		}

		/// <summary>
		///		Gets the guild perks.
		/// </summary>
		/// <param name="jsonResponse">The JSON response returned from the API call.</param>
		/// <returns>
		///		A deserialized <see cref="List&lt;GuildClass&gt;"/> object.
		/// </returns>
		public List<GuildPerk> GetGuildPerks(out string jsonResponse)
		{
			StringBuilder query = new StringBuilder();
			query.AppendQueryStringPair(_localeQueryStringKey, CurrentLocale);

			string urlPath = ApiSettings[_apiKeyGuildPerks].Path;

			jsonResponse = GetResponse(urlPath, query.ToString());

			return DeserializeGuildPerksResponse(jsonResponse);
		}

		#endregion

		#region Guild Profile

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetGuildProfile"/>.
		/// </summary>
		/// <param name="jsonResponse">The string to deserialize.</param>
		/// <returns>
		///		A deserialized <see cref="GuildProfileResponse"/> object.
		/// </returns>
		public GuildProfileResponse DeserializeGuildProfileResponse(string jsonResponse)
		{
			JavaScriptSerializer serializer = new JavaScriptSerializer();
			GuildProfileResponse deserializedResponse = serializer.Deserialize<GuildProfileResponse>(jsonResponse);

			return deserializedResponse;
		}

		/// <summary>
		///		Gets the profile of the specified guild on the specified realm.
		/// </summary>
		/// <param name="realm">The realm that the guild is on.</param>
		/// <param name="guild">The name of the guild.</param>
		/// <param name="fields">A bitwise combination of the enumeration values.</param>
		/// <returns>
		///		A deserialized <see cref="GuildProfileResponse"/> object.
		/// </returns>
		public GuildProfileResponse GetGuildProfile(string realm, string guild, GuildProfileOptionalFieldsEnum fields)
		{
			string jsonResponse;

			return GetGuildProfile(out jsonResponse, realm, guild, fields);
		}

		/// <summary>
		///		Gets the profile of the specified guild on the specified realm.
		/// </summary>
		/// <param name="jsonResponse">The JSON response returned from the API call.</param>
		/// <param name="realm">The realm that the guild is on.</param>
		/// <param name="guild">The name of the guild.</param>
		/// <param name="fields">A bitwise combination of the enumeration values.</param>
		/// <returns>
		///		A deserialized <see cref="GuildProfileResponse"/> object.
		/// </returns>
		public GuildProfileResponse GetGuildProfile(out string jsonResponse, string realm, string guild, GuildProfileOptionalFieldsEnum fields)
		{
			StringBuilder query = new StringBuilder();

			if (fields != GuildProfileOptionalFieldsEnum.None)
			{
				query.AppendQueryStringPair(_fieldsQueryStringKey, fields.ToString("F").ToLower().Replace(", ", ","));
			}

			query.AppendQueryStringPair(_localeQueryStringKey, CurrentLocale);

			string urlPath = string.Format(ApiSettings[_apiKeyGuildProfile].Path, realm, guild);

			jsonResponse = GetResponse(urlPath, query.ToString());

			return DeserializeGuildProfileResponse(jsonResponse);
		}

		#endregion

		#region Guild Rewards

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetGuildRewards"/>.
		/// </summary>
		/// <param name="jsonResponse">The string to deserialize.</param>
		/// <returns>
		///		A deserialized <see cref="List&lt;GuildClass&gt;"/> object.
		/// </returns>
		public List<GuildReward> DeserializeGuildRewardsResponse(string jsonResponse)
		{
			JavaScriptSerializer serializer = new JavaScriptSerializer();
			GuildRewardsResponse deserializedResponse = serializer.Deserialize<GuildRewardsResponse>(jsonResponse);

			return (deserializedResponse == null ? null : deserializedResponse.Rewards);
		}

		/// <summary>
		///		Gets the guild rewards.
		/// </summary>
		/// <returns>
		///		A deserialized <see cref="List&lt;GuildClass&gt;"/> object.
		/// </returns>
		public List<GuildReward> GetGuildRewards()
		{
			string jsonResponse;

			return GetGuildRewards(out jsonResponse);
		}

		/// <summary>
		///		Gets the guild rewards.
		/// </summary>
		/// <param name="jsonResponse">The JSON response returned from the API call.</param>
		/// <returns>
		///		A deserialized <see cref="List&lt;GuildClass&gt;"/> object.
		/// </returns>
		public List<GuildReward> GetGuildRewards(out string jsonResponse)
		{
			StringBuilder query = new StringBuilder();
			query.AppendQueryStringPair(_localeQueryStringKey, CurrentLocale);

			string urlPath = ApiSettings[_apiKeyGuildRewards].Path;

			jsonResponse = GetResponse(urlPath, query.ToString());

			return DeserializeGuildRewardsResponse(jsonResponse);
		}

		#endregion

		#region Item

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetItem"/>.
		/// </summary>
		/// <param name="jsonResponse">The string to deserialize.</param>
		/// <returns>
		///		A <see cref="T:ItemResponse"/> object.
		/// </returns>
		public ItemResponse DeserializeItemResponse(string jsonResponse)
		{
			JavaScriptSerializer serializer = new JavaScriptSerializer();
			ItemResponse deserializedResponse = serializer.Deserialize<ItemResponse>(jsonResponse);

			return deserializedResponse;
		}

		/// <summary>
		///		Gets the details for the specified item.
		/// </summary>
		/// <param name="itemId">The id of the item to get details for.</param>
		/// <returns>
		///		A <see cref="T:ItemResponse"/> object.
		/// </returns>
		public ItemResponse GetItem(int itemId)
		{
			string jsonResponse;

			return GetItem(out jsonResponse, itemId);
		}

		/// <summary>
		///		Gets the details for the specified item.
		/// </summary>
		/// <param name="jsonResponse">The JSON response returned from the API call.</param>
		/// <param name="itemId">The id of the item to get details for.</param>
		/// <returns>
		///		A <see cref="T:ItemResponse"/> object.
		/// </returns>
		public ItemResponse GetItem(out string jsonResponse, int itemId)
		{
			StringBuilder query = new StringBuilder();
			query.AppendQueryStringPair(_localeQueryStringKey, CurrentLocale);

			string urlPath = string.Format(ApiSettings[_apiKeyItem].Path, itemId);

			jsonResponse = GetResponse(urlPath, query.ToString());

			return DeserializeItemResponse(jsonResponse);
		}

		#endregion

		#region Item Classes

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetItemClasses"/>.
		/// </summary>
		/// <param name="jsonResponse">The string to deserialize.</param>
		/// <returns>
		///		A deserialized <see cref="List&lt;ItemClass&gt;"/> object.
		/// </returns>
		public List<ItemClass> DeserializeItemClassesResponse(string jsonResponse)
		{
			JavaScriptSerializer serializer = new JavaScriptSerializer();
			ItemClassesResponse deserializedResponse = serializer.Deserialize<ItemClassesResponse>(jsonResponse);

			return (deserializedResponse == null ? null : deserializedResponse.Classes);
		}

		/// <summary>
		///		Gets the item classes.
		/// </summary>
		/// <returns>
		///		A deserialized <see cref="List&lt;ItemClass&gt;"/> object.
		/// </returns>
		public List<ItemClass> GetItemClasses()
		{
			string jsonResponse;

			return GetItemClasses(out jsonResponse);
		}

		/// <summary>
		///		Gets the item classes.
		/// </summary>
		/// <param name="jsonResponse">The JSON response returned from the API call.</param>
		/// <returns>
		///		A deserialized <see cref="List&lt;ItemClass&gt;"/> object.
		/// </returns>
		public List<ItemClass> GetItemClasses(out string jsonResponse)
		{
			StringBuilder query = new StringBuilder();
			query.AppendQueryStringPair(_localeQueryStringKey, CurrentLocale);

			string urlPath = ApiSettings[_apiKeyItemClasses].Path;

			jsonResponse = GetResponse(urlPath, query.ToString());

			return DeserializeItemClassesResponse(jsonResponse);
		}

		#endregion

		#region Quest

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetQuest"/>.
		/// </summary>
		/// <param name="jsonResponse">The string to deserialize.</param>
		/// <returns>
		///		A <see cref="T:Quest"/> object.
		/// </returns>
		public Quest DeserializeQuestResponse(string jsonResponse)
		{
			JavaScriptSerializer serializer = new JavaScriptSerializer();
			Quest deserializedResponse = serializer.Deserialize<Quest>(jsonResponse);

			return deserializedResponse;
		}

		/// <summary>
		///		Gets the details for the specified quest.
		/// </summary>
		/// <param name="questId">The id of the quest to get details for.</param>
		/// <returns>
		///		A <see cref="T:Quest"/> object.
		/// </returns>
		public Quest GetQuest(int questId)
		{
			string jsonResponse;

			return GetQuest(out jsonResponse, questId);
		}

		/// <summary>
		///		Gets the details for the specified quest.
		/// </summary>
		/// <param name="jsonResponse">The JSON response returned from the API call.</param>
		/// <param name="questId">The id of the quest to get details for.</param>
		/// <returns>
		///		A <see cref="T:Quest"/> object.
		/// </returns>
		public Quest GetQuest(out string jsonResponse, int questId)
		{
			StringBuilder query = new StringBuilder();
			query.AppendQueryStringPair(_localeQueryStringKey, CurrentLocale);

			string urlPath = string.Format(ApiSettings[_apiKeyQuest].Path, questId);

			jsonResponse = GetResponse(urlPath, query.ToString());

			return DeserializeQuestResponse(jsonResponse);
		}

		#endregion

		#region Realm Status

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetRealmStatus"/>.
		/// </summary>
		/// <param name="jsonResponse">The string to deserialize.</param>
		/// <returns>
		///		A <see cref="List&lt;Realm&gt;"/> collection.
		/// </returns>
		public List<Realm> DeserializeRealmStatusResponse(string jsonResponse)
		{
			JavaScriptSerializer serializer = new JavaScriptSerializer();
			RealmStatusResponse deserializedResponse = serializer.Deserialize<RealmStatusResponse>(jsonResponse);

			return (deserializedResponse == null ? null : deserializedResponse.Realms);
		}

		/// <summary>
		///		Gets the status of the specified realms.  If relams is null or empty, the entire
		///		list of realms for the region is returned.
		/// </summary>
		/// <param name="realms">A comma seperated list of realms to retrieve. (optional)</param>
		/// <returns>
		///		A <see cref="List&lt;Realm&gt;"/> collection.
		/// </returns>
		public List<Realm> GetRealmStatus(string realms = null)
		{
			string jsonResponse;

			return GetRealmStatus(out jsonResponse, realms);
		}

		/// <summary>
		///		Gets the status of the specified realms.  If relams is null or empty, the entire
		///		list of realms for the region is returned.
		/// </summary>
		/// <param name="jsonResponse">The JSON response returned from the API call.</param>
		/// <param name="realms">A comma seperated list of realms to retrieve. (optional)</param>
		/// <returns>
		///		A <see cref="List&lt;Realm&gt;"/> collection.
		/// </returns>
		public List<Realm> GetRealmStatus(out string jsonResponse, string realms = null)
		{
			StringBuilder query = new StringBuilder();

			if (!string.IsNullOrWhiteSpace(realms))
			{
				query.AppendQueryStringPair(_realmsQueryStringKey, realms);
			}

			query.AppendQueryStringPair(_localeQueryStringKey, CurrentLocale);

			string urlPath = ApiSettings[_apiKeyRealmStatus].Path;

			jsonResponse = GetResponse(urlPath, query.ToString());

			return DeserializeRealmStatusResponse(jsonResponse);
		}

		/// <summary>
		///		Gets the status of the specified realms.  If relams is null or empty, the entire
		///		list of realms for the region is returned.
		/// </summary>
		/// <param name="realms">An <see cref="T:IEnumerable&lt;string&gt;"/> list of realms to retrieve.</param>
		/// <returns>
		///		A <see cref="List&lt;Realm&gt;"/> collection.
		/// </returns>
		public List<Realm> GetRealmStatus(IEnumerable<string> realms)
		{
			string jsonResponse;

			return GetRealmStatus(out jsonResponse, realms);
		}

		/// <summary>
		///		Gets the status of the specified realms.  If relams is null or empty, the entire
		///		list of realms for the region is returned.
		/// </summary>
		/// <param name="jsonResponse">The JSON response returned from the API call.</param>
		/// <param name="realms">An <see cref="T:IEnumerable&lt;string&gt;"/> list of realms to retrieve.</param>
		/// <returns>
		///		A <see cref="List&lt;Realm&gt;"/> collection.
		/// </returns>
		public List<Realm> GetRealmStatus(out string jsonResponse, IEnumerable<string> realms)
		{
			return GetRealmStatus(out jsonResponse, JoinList(realms));
		}

		#endregion

		#endregion

		#region Private Methods

		private string GetResponse(string urlPath, string queryString)
		{
			RegionElement settings = WorldOfWarcraftSection.Instance.Regions[CurrentRegionKey];

			UriBuilder requestUri = new UriBuilder(settings.Host);
			requestUri.Path = urlPath;
			requestUri.Query = queryString;

			// Blizzard recommends using secure requests when using authorization.
			if (UseAuthorization && requestUri.Scheme.Equals("http", StringComparison.InvariantCultureIgnoreCase))
			{
				requestUri.Scheme = "https";
				requestUri.Port = 443;
			}

			HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(requestUri.Uri);

			if (UseAuthorization)
			{
				request.Date = DateTime.UtcNow;

				string stringToSign = string.Format("GET\n{0}\n{1}\n", request.Headers["Date"], requestUri.Path);
				string authorizationHeader = string.Format("BNET {0}:{1}", PublicKey, GetSignature(stringToSign));

				request.Headers.Add("Authorization", authorizationHeader);
			}

			try
			{
				HttpWebResponse response = (HttpWebResponse)request.GetResponse();
				string responseString;

				using (Stream stream = response.GetResponseStream())
				using (StreamReader reader = new StreamReader(stream))
				{
					return (responseString = reader.ReadToEnd());
				}
			}
			catch (WebException ex)
			{
				if (ex.Response == null) { throw; }

				using (Stream stream = ex.Response.GetResponseStream())
				using (StreamReader reader = new StreamReader(stream))
				{
					string jsonErrorResponse = reader.ReadToEnd();

					JavaScriptSerializer serializer = new JavaScriptSerializer();
					ErrorResponse deserializedResponse = serializer.Deserialize<ErrorResponse>(jsonErrorResponse);

					throw new WorldOfWarcraftApiException(deserializedResponse.Status, deserializedResponse.Reason);
				}
			}
		}

		private string GetSignature(string stringToSign)
		{
			string signature;

			using (HMACSHA1 hmac = new HMACSHA1(Encoding.UTF8.GetBytes(PrivateKey)))
			{
				byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(stringToSign));
				return (signature = Convert.ToBase64String(hash));
			}
		}

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
