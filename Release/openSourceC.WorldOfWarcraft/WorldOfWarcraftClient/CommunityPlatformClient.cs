using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Security.Cryptography;

using openSourceC.WorldOfWarcraft;
using System.IO.Compression;

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
		private const string _apiKeyRecipe = "recipe";

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
		///		<remarks>Settting this propery resets <see cref="P:CurrentLocale"/> to null. To use
		///		the configuration defaults, set this value to null.</remarks>
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

			return GetResponse(request);
		}

		#endregion

		#region API Methods

		#region Arena Team

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetArenaTeamRaw"/>.
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
			string jsonResponse = GetArenaTeamRaw(realm, teamSize, teamName);

			return DeserializeArenaTeamResponse(jsonResponse);
		}

		/// <summary>
		///		Gets the profile of the specified arena team on the specified realm.
		/// </summary>
		/// <param name="jsonResponse">The JSON response returned from the API call.</param>
		/// <param name="realm">The realm that the team is on.</param>
		/// <param name="teamSize">The team size.</param>
		/// <param name="teamName">The name of the team.</param>
		/// <returns>
		///		A deserialized <see cref="ArenaTeamResponse"/> object.
		/// </returns>
		public ArenaTeamResponse GetArenaTeam(out string jsonResponse, string realm, ArenaTeamSizeEnum teamSize, string teamName)
		{
			jsonResponse = GetArenaTeamRaw(realm, teamSize, teamName);

			return DeserializeArenaTeamResponse(jsonResponse);
		}

		/// <summary>
		///		Gets the raw response for the specified arena team on the specified realm.
		/// </summary>
		/// <param name="realm">The realm that the team is on.</param>
		/// <param name="teamSize">The team size.</param>
		/// <param name="teamName">The name of the team.</param>
		/// <returns>
		///		The JSON response returned from the API call.
		/// </returns>
		public string GetArenaTeamRaw(string realm, ArenaTeamSizeEnum teamSize, string teamName)
		{
			StringBuilder query = new StringBuilder();
			query.AppendQueryStringPair(_localeQueryStringKey, CurrentLocale);

			string teamSizeName = teamSize.ToString("F").Replace("Arena", string.Empty);
			string urlPath = string.Format(ApiSettings[_apiKeyArenaTeam].Path, realm, teamSizeName, teamName);

			return GetResponse(urlPath, query.ToString());
		}

		#endregion

		#region Auction Data File

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetAuctionDataFileRaw"/>.
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
			string jsonFile = GetAuctionDataFileRaw(url);

			return DeserializeAuctionDataFile(jsonFile);
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
			jsonFile = GetAuctionDataFileRaw(url);

			return DeserializeAuctionDataFile(jsonFile);
		}

		/// <summary>
		///		Gets the raw auction data file at the specified url.
		/// </summary>
		/// <param name="url">The url of the file.</param>
		/// <returns>
		///		The JSON response returned from the API call.
		/// </returns>
		public string GetAuctionDataFileRaw(string url)
		{
			return GetFile(url);
		}

		#endregion

		#region Auction Data Header

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetAuctionDataHeaderRaw"/>.
		/// </summary>
		/// <param name="jsonResponse">The string to deserialize.</param>
		/// <returns>
		///		A <see cref="T:List&lt;File&gt;"/> collection.
		/// </returns>
		public List<AuctionData> DeserializeAuctionDataHeaderResponse(string jsonResponse)
		{
			JavaScriptSerializer serializer = new JavaScriptSerializer();
			AuctionDataResponse deserializedResponse = serializer.Deserialize<AuctionDataResponse>(jsonResponse);

			return (deserializedResponse == null ? null : deserializedResponse.Files);
		}

		/// <summary>
		///		Gets the auction house data header for the specified realm.
		/// </summary>
		/// <param name="realm">The realm to receive auction house data for.</param>
		/// <returns>
		///		A deserialized <see cref="List&lt;AuctionData&gt;"/> object.
		/// </returns>
		public List<AuctionData> GetAuctionDataHeader(string realm)
		{
			string jsonResponse = GetAuctionDataHeaderRaw(realm);

			return DeserializeAuctionDataHeaderResponse(jsonResponse);
		}

		/// <summary>
		///		Gets the auction house data header for the specified realm.
		/// </summary>
		/// <param name="jsonResponse">The JSON response returned from the API call.</param>
		/// <param name="realm">The realm to receive auction house data for.</param>
		/// <returns>
		///		A deserialized <see cref="List&lt;AuctionData&gt;"/> object.
		/// </returns>
		public List<AuctionData> GetAuctionDataHeader(out string jsonResponse, string realm)
		{
			jsonResponse = GetAuctionDataHeaderRaw(realm);

			return DeserializeAuctionDataHeaderResponse(jsonResponse);
		}

		/// <summary>
		///		Gets the raw auction house data header for the specified realm.
		/// </summary>
		/// <param name="realm">The realm to receive auction house data for.</param>
		/// <returns>
		///		The JSON response returned from the API call.
		/// </returns>
		public string GetAuctionDataHeaderRaw(string realm)
		{
			StringBuilder query = new StringBuilder();
			query.AppendQueryStringPair(_localeQueryStringKey, CurrentLocale);

			string urlPath = string.Format(ApiSettings[_apiKeyAuctionData].Path, realm);

			return GetResponse(urlPath, query.ToString());
		}

		#endregion

		#region Character Achievements

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetCharacterAchievementsRaw"/>.
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
			string jsonResponse = GetCharacterAchievementsRaw();

			return DeserializeCharacterAchievementsResponse(jsonResponse);
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
			jsonResponse = GetCharacterAchievementsRaw();

			return DeserializeCharacterAchievementsResponse(jsonResponse);
		}

		/// <summary>
		///		Gets the raw response for the character achievements.
		/// </summary>
		/// <returns>
		///		The JSON response returned from the API call.
		/// </returns>
		public string GetCharacterAchievementsRaw()
		{
			StringBuilder query = new StringBuilder();
			query.AppendQueryStringPair(_localeQueryStringKey, CurrentLocale);

			string urlPath = ApiSettings[_apiKeyCharacterAchievements].Path;

			return GetResponse(urlPath, query.ToString());
		}

		#endregion

		#region Character Classes

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetCharacterClassesRaw"/>.
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
			string jsonResponse = GetCharacterClassesRaw();

			return DeserializeCharacterClassesResponse(jsonResponse);
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
			jsonResponse = GetCharacterClassesRaw();

			return DeserializeCharacterClassesResponse(jsonResponse);
		}

		/// <summary>
		///		Gets the raw response for character classes.
		/// </summary>
		/// <returns>
		///		The JSON response returned from the API call.
		/// </returns>
		public string GetCharacterClassesRaw()
		{
			StringBuilder query = new StringBuilder();
			query.AppendQueryStringPair(_localeQueryStringKey, CurrentLocale);

			string urlPath = ApiSettings[_apiKeyCharacterClasses].Path;

			return GetResponse(urlPath, query.ToString());
		}

		#endregion

		#region Character Profile

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetCharacterProfileRaw"/>.
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
			string jsonResponse = GetCharacterProfileRaw(realm, character, fields);

			return DeserializeCharacterProfileResponse(jsonResponse);
		}

		/// <summary>
		///		Gets the profile of the specified character on the specified realm.
		/// </summary>
		/// <param name="jsonResponse">The JSON response returned from the API call.</param>
		/// <param name="realm">The realm that the character is on.</param>
		/// <param name="character">The name of the character.</param>
		/// <param name="fields">A bitwise combination of the enumeration values.</param>
		/// <returns>
		///		The JSON response returned from the API call.
		/// </returns>
		public CharacterProfileResponse GetCharacterProfile(out string jsonResponse, string realm, string character, CharacterProfileOptionalFieldsEnum fields)
		{
			jsonResponse = GetCharacterProfileRaw(realm, character, fields);

			return DeserializeCharacterProfileResponse(jsonResponse);
		}

		/// <summary>
		///		Gets the raw response for the profile of the specified character on the specified realm.
		/// </summary>
		/// <param name="realm">The realm that the character is on.</param>
		/// <param name="character">The name of the character.</param>
		/// <param name="fields">A bitwise combination of the enumeration values.</param>
		/// <returns>
		///		The JSON response returned from the API call.
		/// </returns>
		public string GetCharacterProfileRaw(string realm, string character, CharacterProfileOptionalFieldsEnum fields)
		{
			StringBuilder query = new StringBuilder();

			if (fields != CharacterProfileOptionalFieldsEnum.None)
			{
				query.AppendQueryStringPair(_fieldsQueryStringKey, fields.ToString("F").ToLower().Replace(", ", ","));
			}

			query.AppendQueryStringPair(_localeQueryStringKey, CurrentLocale);

			string urlPath = string.Format(ApiSettings[_apiKeyCharacterProfile].Path, realm, character);

			return GetResponse(urlPath, query.ToString());
		}

		#endregion

		#region Character Races

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetCharacterRacesRaw"/>.
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
			string jsonResponse = GetCharacterRacesRaw();

			return DeserializeCharacterRacesResponse(jsonResponse);
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
			jsonResponse = GetCharacterRacesRaw();

			return DeserializeCharacterRacesResponse(jsonResponse);
		}

		/// <summary>
		///		Gets the raw response for character races.
		/// </summary>
		/// <returns>
		///		The JSON response returned from the API call.
		/// </returns>
		public string GetCharacterRacesRaw()
		{
			StringBuilder query = new StringBuilder();
			query.AppendQueryStringPair(_localeQueryStringKey, CurrentLocale);

			string urlPath = ApiSettings[_apiKeyCharacterRaces].Path;

			return GetResponse(urlPath, query.ToString());
		}

		#endregion

		#region Guild Achievements

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetGuildAchievementsRaw"/>.
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
			string jsonResponse = GetGuildAchievementsRaw();

			return DeserializeGuildAchievementsResponse(jsonResponse);
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
			jsonResponse = GetGuildAchievementsRaw();

			return DeserializeGuildAchievementsResponse(jsonResponse);
		}

		/// <summary>
		///		Gets the raw response for guild achievements.
		/// </summary>
		/// <returns>
		///		The JSON response returned from the API call.
		/// </returns>
		public string GetGuildAchievementsRaw()
		{
			StringBuilder query = new StringBuilder();
			query.AppendQueryStringPair(_localeQueryStringKey, CurrentLocale);

			string urlPath = ApiSettings[_apiKeyGuildAchievements].Path;

			return GetResponse(urlPath, query.ToString());
		}

		#endregion

		#region Guild Perks

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetGuildPerksRaw"/>.
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
			string jsonResponse = GetGuildPerksRaw();

			return DeserializeGuildPerksResponse(jsonResponse);
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
			jsonResponse = GetGuildPerksRaw();

			return DeserializeGuildPerksResponse(jsonResponse);
		}

		/// <summary>
		///		Gets the raw response for guild perks.
		/// </summary>
		/// <returns>
		///		The JSON response returned from the API call.
		/// </returns>
		public string GetGuildPerksRaw()
		{
			StringBuilder query = new StringBuilder();
			query.AppendQueryStringPair(_localeQueryStringKey, CurrentLocale);

			string urlPath = ApiSettings[_apiKeyGuildPerks].Path;

			return GetResponse(urlPath, query.ToString());
		}

		#endregion

		#region Guild Profile

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetGuildProfileRaw"/>.
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
			string jsonResponse = GetGuildProfileRaw(realm, guild, fields);

			return DeserializeGuildProfileResponse(jsonResponse);
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
			jsonResponse = GetGuildProfileRaw(realm, guild, fields);

			return DeserializeGuildProfileResponse(jsonResponse);
		}

		/// <summary>
		///		Gets the raw response for the profile of the specified guild on the specified realm.
		/// </summary>
		/// <param name="realm">The realm that the guild is on.</param>
		/// <param name="guild">The name of the guild.</param>
		/// <param name="fields">A bitwise combination of the enumeration values.</param>
		/// <returns>
		///		The JSON response returned from the API call.
		/// </returns>
		public string GetGuildProfileRaw(string realm, string guild, GuildProfileOptionalFieldsEnum fields)
		{
			StringBuilder query = new StringBuilder();

			if (fields != GuildProfileOptionalFieldsEnum.None)
			{
				query.AppendQueryStringPair(_fieldsQueryStringKey, fields.ToString("F").ToLower().Replace(", ", ","));
			}

			query.AppendQueryStringPair(_localeQueryStringKey, CurrentLocale);

			string urlPath = string.Format(ApiSettings[_apiKeyGuildProfile].Path, realm, guild);

			return GetResponse(urlPath, query.ToString());
		}

		#endregion

		#region Guild Rewards

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetGuildRewardsRaw"/>.
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
			string jsonResponse = GetGuildRewardsRaw();

			return DeserializeGuildRewardsResponse(jsonResponse);
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
			jsonResponse = GetGuildRewardsRaw();

			return DeserializeGuildRewardsResponse(jsonResponse);
		}

		/// <summary>
		///		Gets the raw response for guild rewards.
		/// </summary>
		/// <returns>
		///		The JSON response returned from the API call.
		/// </returns>
		public string GetGuildRewardsRaw()
		{
			StringBuilder query = new StringBuilder();
			query.AppendQueryStringPair(_localeQueryStringKey, CurrentLocale);

			string urlPath = ApiSettings[_apiKeyGuildRewards].Path;

			return GetResponse(urlPath, query.ToString());
		}

		#endregion

		#region Item

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetItemRaw"/>.
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
		///		Gets the details of the specified item.
		/// </summary>
		/// <param name="itemId">The id of the item to get details for.</param>
		/// <returns>
		///		A <see cref="T:ItemResponse"/> object.
		/// </returns>
		public ItemResponse GetItem(int itemId)
		{
			string jsonResponse = GetItemRaw(itemId);

			return DeserializeItemResponse(jsonResponse);
		}

		/// <summary>
		///		Gets the details of the specified item.
		/// </summary>
		/// <param name="jsonResponse">The JSON response returned from the API call.</param>
		/// <param name="itemId">The id of the item to get details for.</param>
		/// <returns>
		///		A <see cref="T:ItemResponse"/> object.
		/// </returns>
		public ItemResponse GetItem(out string jsonResponse, int itemId)
		{
			jsonResponse = GetItemRaw(itemId);

			return DeserializeItemResponse(jsonResponse);
		}

		/// <summary>
		///		Gets the raw response for the details of the specified item.
		/// </summary>
		/// <param name="itemId">The id of the item to get details for.</param>
		/// <returns>
		///		The JSON response returned from the API call.
		/// </returns>
		public string GetItemRaw(int itemId)
		{
			StringBuilder query = new StringBuilder();
			query.AppendQueryStringPair(_localeQueryStringKey, CurrentLocale);

			string urlPath = string.Format(ApiSettings[_apiKeyItem].Path, itemId);

			return GetResponse(urlPath, query.ToString());
		}

		#endregion

		#region Item Classes

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetItemClassesRaw"/>.
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
			string jsonResponse = GetItemClassesRaw();

			return DeserializeItemClassesResponse(jsonResponse);
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
			jsonResponse = GetItemClassesRaw();

			return DeserializeItemClassesResponse(jsonResponse);
		}

		/// <summary>
		///		Gets the raw response for item classes.
		/// </summary>
		/// <returns>
		///		The JSON response returned from the API call.
		/// </returns>
		public string GetItemClassesRaw()
		{
			StringBuilder query = new StringBuilder();
			query.AppendQueryStringPair(_localeQueryStringKey, CurrentLocale);

			string urlPath = ApiSettings[_apiKeyItemClasses].Path;

			return GetResponse(urlPath, query.ToString());
		}

		#endregion

		#region Quest

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetQuestRaw"/>.
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
			string jsonResponse = GetQuestRaw(questId);

			return DeserializeQuestResponse(jsonResponse);
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
			jsonResponse = GetQuestRaw(questId);

			return DeserializeQuestResponse(jsonResponse);
		}

		/// <summary>
		///		Gets the raw response for the details for the specified quest.
		/// </summary>
		/// <param name="questId">The id of the quest to get details for.</param>
		/// <returns>
		///		The JSON response returned from the API call.
		/// </returns>
		public string GetQuestRaw(int questId)
		{
			StringBuilder query = new StringBuilder();
			query.AppendQueryStringPair(_localeQueryStringKey, CurrentLocale);

			string urlPath = string.Format(ApiSettings[_apiKeyQuest].Path, questId);

			return GetResponse(urlPath, query.ToString());
		}

		#endregion

		#region Realm Status

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetRealmStatusRaw"/>.
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
			string jsonResponse = GetRealmStatusRaw(realms);

			return DeserializeRealmStatusResponse(jsonResponse);
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
			jsonResponse = GetRealmStatusRaw(realms);

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
			string jsonResponse = GetRealmStatusRaw(JoinList(realms));

			return DeserializeRealmStatusResponse(jsonResponse);
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
			jsonResponse = GetRealmStatusRaw(JoinList(realms));

			return DeserializeRealmStatusResponse(jsonResponse);
		}

		/// <summary>
		///		Gets the raw response for the status of the specified realms.  If relams is null or
		///		empty, the entire list of realms for the region is returned.
		/// </summary>
		/// <param name="realms">A comma seperated list of realms to retrieve. (optional)</param>
		/// <returns>
		///		The JSON response returned from the API call.
		/// </returns>
		public string GetRealmStatusRaw(string realms = null)
		{
			StringBuilder query = new StringBuilder();

			if (!string.IsNullOrWhiteSpace(realms))
			{
				query.AppendQueryStringPair(_realmsQueryStringKey, realms);
			}

			query.AppendQueryStringPair(_localeQueryStringKey, CurrentLocale);

			string urlPath = ApiSettings[_apiKeyRealmStatus].Path;

			return GetResponse(urlPath, query.ToString());
		}

		#endregion

		#region Recipe

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetRecipeRaw"/>.
		/// </summary>
		/// <param name="jsonResponse">The string to deserialize.</param>
		/// <returns>
		///		A <see cref="T:Recipe"/> object.
		/// </returns>
		public Recipe DeserializeRecipeResponse(string jsonResponse)
		{
			JavaScriptSerializer serializer = new JavaScriptSerializer();
			Recipe deserializedResponse = serializer.Deserialize<Recipe>(jsonResponse);

			return deserializedResponse;
		}

		/// <summary>
		///		Gets the details for the specified recipe.
		/// </summary>
		/// <param name="recipeId">The id of the recipe to get details for.</param>
		/// <returns>
		///		A <see cref="T:Recipe"/> object.
		/// </returns>
		public Recipe GetRecipe(int recipeId)
		{
			string jsonResponse = GetRecipeRaw(recipeId);

			return DeserializeRecipeResponse(jsonResponse);
		}

		/// <summary>
		///		Gets the details for the specified recipe.
		/// </summary>
		/// <param name="jsonResponse">The JSON response returned from the API call.</param>
		/// <param name="recipeId">The id of the recipe to get details for.</param>
		/// <returns>
		///		A <see cref="T:Recipe"/> object.
		/// </returns>
		public Recipe GetRecipe(out string jsonResponse, int recipeId)
		{
			jsonResponse = GetRecipeRaw(recipeId);

			return DeserializeRecipeResponse(jsonResponse);
		}

		/// <summary>
		///		Gets the raw response for the details of the specified recipe.
		/// </summary>
		/// <param name="recipeId">The id of the recipe to get details for.</param>
		/// <returns>
		///		The JSON response returned from the API call.
		/// </returns>
		public string GetRecipeRaw(int recipeId)
		{
			StringBuilder query = new StringBuilder();
			query.AppendQueryStringPair(_localeQueryStringKey, CurrentLocale);

			string urlPath = string.Format(ApiSettings[_apiKeyRecipe].Path, recipeId);

			return GetResponse(urlPath, query.ToString());
		}

		#endregion

		#endregion

		#region Private Methods

		private string GetResponse(HttpWebRequest request)
		{
			try
			{
				HttpWebResponse response = (HttpWebResponse)request.GetResponse();
				string responseContentEncoding = response.Headers[HttpResponseHeader.ContentEncoding];
				string responseString;

				if (responseContentEncoding != null && responseContentEncoding.IndexOf("gzip", StringComparison.InvariantCultureIgnoreCase) != -1)
				{
					using (Stream stream = response.GetResponseStream())
					using (GZipStream gzip = new GZipStream(stream, CompressionMode.Decompress))
					using (StreamReader reader = new StreamReader(gzip))
					{
						return (responseString = reader.ReadToEnd());
					}
				}
				else
				{
					using (Stream stream = response.GetResponseStream())
					using (StreamReader reader = new StreamReader(stream))
					{
						return (responseString = reader.ReadToEnd());
					}
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

			return GetResponse(request);
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
