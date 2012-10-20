using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using System.Text;

using openSourceC.WorldOfWarcraft;

namespace openSourceC.WorldOfWarcraftClient
{
	/// <summary>
	///		Summary descritpion for CommunityPlatformClient.
	/// </summary>
	//[DebuggerStepThrough()]
	public class CommunityPlatformClient
	{
		private const string _apiKeyAchievement = "achievement";
		private const string _apiKeyArenaLadder = "arenaLadder";
		private const string _apiKeyArenaTeam = "arenaTeam";
		private const string _apiKeyAuctionData = "auctionData";
		private const string _apiKeyBattlePetAbility = "battlePetAbility";
		private const string _apiKeyBattlePetSpecies = "battlePetSpecies";
		private const string _apiKeyBattlePetStats = "battlePetStats";
		private const string _apiKeyCharacterProfile = "characterProfile";
		private const string _apiKeyGuildProfile = "guildProfile";
		private const string _apiKeyItem = "item";
		private const string _apiKeyItemSet = "itemSet";
		private const string _apiKeyQuest = "quest";
		private const string _apiKeyRatedBattlegroundLadder = "ratedBattlegroundLadder";
		private const string _apiKeyRealmChallenge = "realmChallenge";
		private const string _apiKeyRealmStatus = "realmStatus";
		private const string _apiKeyRecipe = "recipe";
		private const string _apiKeySpell = "spell";

		// Data Resource API Keys
		private const string _apiKeyBattlegroups = "battlegroups";
		private const string _apiKeyCharacterAchievements = "characterAchievements";
		private const string _apiKeyCharacterClasses = "characterClasses";
		private const string _apiKeyCharacterRaces = "characterRaces";
		private const string _apiKeyGuildAchievements = "guildAchievements";
		private const string _apiKeyGuildPerks = "guildPerks";
		private const string _apiKeyGuildRewards = "guildRewards";
		private const string _apiKeyItemClasses = "itemClasses";
		private const string _apiKeyPetTypes = "petTypes";
		private const string _apiKeyTalents = "talents";

		private const string _breedIdQueryStringKey = "breedId";
		private const string _fieldsQueryStringKey = "fields";
		private const string _levelQueryStringKey = "level";
		private const string _localeQueryStringKey = "locale";
		private const string _qualityIdQueryStringKey = "qualityId";
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

		#region Achievement API

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetAchievementRaw"/>.
		/// </summary>
		/// <param name="jsonResponse">The string to deserialize.</param>
		/// <returns>
		///		A <see cref="T:AchievementResponse"/> object.
		/// </returns>
		public AchievementResponse DeserializeAchievementResponse(string jsonResponse)
		{
			DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(AchievementResponse));

			using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonResponse)))
			{
				AchievementResponse deserializedResponse = (AchievementResponse)serializer.ReadObject(stream);
				deserializedResponse.JsonResponse = jsonResponse;

				return deserializedResponse;
			}
		}

		/// <summary>
		///		Gets the details of the specified achievement.
		/// </summary>
		/// <param name="achievementId">The id of the achievement to get details for.</param>
		/// <returns>
		///		A <see cref="T:AchievementResponse"/> object.
		/// </returns>
		public AchievementResponse GetAchievement(int achievementId)
		{
			return DeserializeAchievementResponse(GetAchievementRaw(achievementId));
		}

		/// <summary>
		///		Gets the raw response for the details of the specified achievement.
		/// </summary>
		/// <param name="achievementId">The id of the achievement to get details for.</param>
		/// <returns>
		///		The JSON response returned from the API call.
		/// </returns>
		public string GetAchievementRaw(int achievementId)
		{
			StringBuilder query = new StringBuilder();
			query.AppendQueryStringPair(_localeQueryStringKey, CurrentLocale);

			string urlPath = string.Format(ApiSettings[_apiKeyAchievement].Path, achievementId);

			return GetResponse(urlPath, query.ToString());
		}

		#endregion

		#region Auction API

		#region Data File

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetAuctionDataFileRaw"/>.
		/// </summary>
		/// <param name="jsonResponse">The string to deserialize.</param>
		/// <returns>
		///		A deserialized <see cref="T:AuctionDataFileResponse"/> object.
		/// </returns>
		public AuctionDataFileResponse DeserializeAuctionDataFile(string jsonResponse)
		{
			DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(AuctionDataFileResponse));

			using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonResponse)))
			{
				AuctionDataFileResponse deserializedResponse = (AuctionDataFileResponse)serializer.ReadObject(stream);
				deserializedResponse.JsonResponse = jsonResponse;

				return deserializedResponse;
			}
		}

		/// <summary>
		///		Gets the auction data file at the specified url.
		/// </summary>
		/// <param name="url">The url of the file.</param>
		/// <returns>
		///		A deserialized <see cref="T:AuctionDataFileResponse"/> object.
		/// </returns>
		public AuctionDataFileResponse GetAuctionDataFile(string url)
		{
			return DeserializeAuctionDataFile(GetAuctionDataFileRaw(url));
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

		#region Data Status

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetAuctionDataStatusRaw"/>.
		/// </summary>
		/// <param name="jsonResponse">The string to deserialize.</param>
		/// <returns>
		///		A deserialized <see cref="T:AuctionDataStatusResponse"/> object.
		/// </returns>
		public AuctionDataStatusResponse DeserializeAuctionDataStatusResponse(string jsonResponse)
		{
			DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(AuctionDataStatusResponse));

			using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonResponse)))
			{
				AuctionDataStatusResponse deserializedResponse = (AuctionDataStatusResponse)serializer.ReadObject(stream);
				deserializedResponse.JsonResponse = jsonResponse;

				return deserializedResponse;
			}
		}

		/// <summary>
		///		Gets the auction house data header for the specified realm.
		/// </summary>
		/// <param name="realm">The realm to receive auction house data for.</param>
		/// <returns>
		///		A deserialized <see cref="T:AuctionDataStatusResponse"/> object.
		/// </returns>
		public AuctionDataStatusResponse GetAuctionDataStatus(string realm)
		{
			return DeserializeAuctionDataStatusResponse(GetAuctionDataStatusRaw(realm));
		}

		/// <summary>
		///		Gets the raw auction house data header for the specified realm.
		/// </summary>
		/// <param name="realm">The realm to receive auction house data for.</param>
		/// <returns>
		///		The JSON response returned from the API call.
		/// </returns>
		public string GetAuctionDataStatusRaw(string realm)
		{
			StringBuilder query = new StringBuilder();
			query.AppendQueryStringPair(_localeQueryStringKey, CurrentLocale);

			string urlPath = string.Format(ApiSettings[_apiKeyAuctionData].Path, realm);

			return GetResponse(urlPath, query.ToString());
		}

		#endregion

		#endregion

		#region BattlePet API

		#region Ability

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetBattlePetAbilityRaw"/>.
		/// </summary>
		/// <param name="jsonResponse">The string to deserialize.</param>
		/// <returns>
		///		A deserialized <see cref="T:BattlePetAbilityResponse"/> object.
		/// </returns>
		public BattlePetAbilityResponse DeserializeBattlePetAbilityResponse(string jsonResponse)
		{
			DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(BattlePetAbilityResponse));

			using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonResponse)))
			{
				BattlePetAbilityResponse deserializedResponse = (BattlePetAbilityResponse)serializer.ReadObject(stream);
				deserializedResponse.JsonResponse = jsonResponse;

				return deserializedResponse;
			}
		}

		/// <summary>
		///		Gets the profile of the specified character on the specified realm.
		/// </summary>
		/// <param name="abilityId">The identifier of the ability.</param>
		/// <returns>
		///		A deserialized <see cref="T:BattlePetAbilityResponse"/> object.
		/// </returns>
		public BattlePetAbilityResponse GetBattlePetAbility(int abilityId)
		{
			return DeserializeBattlePetAbilityResponse(GetBattlePetAbilityRaw(abilityId));
		}

		/// <summary>
		///		Gets the raw response for the profile of the specified character on the specified realm.
		/// </summary>
		/// <param name="abilityId">The identifier of the ability.</param>
		/// <returns>
		///		The JSON response returned from the API call.
		/// </returns>
		public string GetBattlePetAbilityRaw(int abilityId)
		{
			StringBuilder query = new StringBuilder();

			query.AppendQueryStringPair(_localeQueryStringKey, CurrentLocale);

			string urlPath = string.Format(ApiSettings[_apiKeyBattlePetAbility].Path, abilityId);

			return GetResponse(urlPath, query.ToString());
		}

		#endregion

		#region Species

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetBattlePetSpeciesRaw"/>.
		/// </summary>
		/// <param name="jsonResponse">The string to deserialize.</param>
		/// <returns>
		///		A deserialized <see cref="T:BattlePetSpeciesResponse"/> object.
		/// </returns>
		public BattlePetSpeciesResponse DeserializeBattlePetSpeciesResponse(string jsonResponse)
		{
			DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(BattlePetSpeciesResponse));

			using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonResponse)))
			{
				BattlePetSpeciesResponse deserializedResponse = (BattlePetSpeciesResponse)serializer.ReadObject(stream);
				deserializedResponse.JsonResponse = jsonResponse;

				return deserializedResponse;
			}
		}

		/// <summary>
		///		Gets the profile of the specified character on the specified realm.
		/// </summary>
		/// <param name="speciesId">The identifier of the species.</param>
		/// <returns>
		///		A deserialized <see cref="T:BattlePetSpeciesResponse"/> object.
		/// </returns>
		public BattlePetSpeciesResponse GetBattlePetSpecies(int speciesId)
		{
			return DeserializeBattlePetSpeciesResponse(GetBattlePetSpeciesRaw(speciesId));
		}

		/// <summary>
		///		Gets the raw response for the profile of the specified character on the specified realm.
		/// </summary>
		/// <param name="speciesId">The identifier of the species.</param>
		/// <returns>
		///		The JSON response returned from the API call.
		/// </returns>
		public string GetBattlePetSpeciesRaw(int speciesId)
		{
			StringBuilder query = new StringBuilder();
			string responseString;

			query.AppendQueryStringPair(_localeQueryStringKey, CurrentLocale);

			string urlPath = string.Format(ApiSettings[_apiKeyBattlePetSpecies].Path, speciesId);

			return (responseString = GetResponse(urlPath, query.ToString()));
		}

		#endregion

		#region Stats

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetBattlePetStatsRaw"/>.
		/// </summary>
		/// <param name="jsonResponse">The string to deserialize.</param>
		/// <returns>
		///		A deserialized <see cref="T:BattlePetStatsResponse"/> object.
		/// </returns>
		public BattlePetStatsResponse DeserializeBattlePetStatsResponse(string jsonResponse)
		{
			DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(BattlePetStatsResponse));

			using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonResponse)))
			{
				BattlePetStatsResponse deserializedResponse = (BattlePetStatsResponse)serializer.ReadObject(stream);
				deserializedResponse.JsonResponse = jsonResponse;

				return deserializedResponse;
			}
		}

		/// <summary>
		///		Gets the profile of the specified character on the specified realm.
		/// </summary>
		/// <param name="speciesId">The identifier of the species.</param>
		/// <param name="level">The Pet's level. (optional, default = 1)</param>
		/// <param name="breedId">The Pet's breed (can be retrieved from the character profile
		///		api). (optional, default = 3)</param>
		/// <param name="qualityId">The Pet's quality (can be retrieved from the character profile
		///		api). (optional, default = 1)</param>
		/// <returns>
		///		A deserialized <see cref="T:BattlePetStatsResponse"/> object.
		/// </returns>
		public BattlePetStatsResponse GetBattlePetStats(int speciesId, int? level = null, int? breedId = null, int? qualityId = null)
		{
			return DeserializeBattlePetStatsResponse(GetBattlePetStatsRaw(speciesId, level, breedId, qualityId));
		}

		/// <summary>
		///		Gets the raw response for the profile of the specified character on the specified realm.
		/// </summary>
		/// <param name="speciesId">The identifier of the species.</param>
		/// <param name="level">The Pet's level. (optional, default = 1)</param>
		/// <param name="breedId">The Pet's breed (can be retrieved from the character profile
		///		api). (optional, default = 3)</param>
		/// <param name="qualityId">The Pet's quality (can be retrieved from the character profile
		///		api). (optional, default = 1)</param>
		/// <returns>
		///		The JSON response returned from the API call.
		/// </returns>
		public string GetBattlePetStatsRaw(int speciesId, int? level = null, int? breedId = null, int? qualityId = null)
		{
			StringBuilder query = new StringBuilder();

			query.AppendQueryStringPair(_levelQueryStringKey, level);
			query.AppendQueryStringPair(_breedIdQueryStringKey, breedId);
			query.AppendQueryStringPair(_qualityIdQueryStringKey, qualityId);
			query.AppendQueryStringPair(_localeQueryStringKey, CurrentLocale);

			string urlPath = string.Format(ApiSettings[_apiKeyBattlePetStats].Path, speciesId);

			return GetResponse(urlPath, query.ToString());
		}

		#endregion

		#endregion

		#region Challenge Mode API

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetRealmChallengeRaw"/>.
		/// </summary>
		/// <param name="jsonResponse">The string to deserialize.</param>
		/// <returns>
		///		A deserialized <see cref="RealmChallengeResponse"/> object.
		/// </returns>
		public RealmChallengeResponse DeserializeRealmChallengeResponse(string jsonResponse)
		{
			DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(RealmChallengeResponse));

			using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonResponse)))
			{
				RealmChallengeResponse deserializedResponse = (RealmChallengeResponse)serializer.ReadObject(stream);
				deserializedResponse.JsonResponse = jsonResponse;

				return deserializedResponse;
			}
		}

		/// <summary>
		///		Gets the leaderboard for the specified realm.
		/// </summary>
		/// <param name="realm">The realm to retrieve.</param>
		/// <returns>
		///		A deserialized <see cref="RealmChallengeResponse"/> object.
		/// </returns>
		public RealmChallengeResponse GetRealmChallenge(string realm)
		{
			return DeserializeRealmChallengeResponse(GetRealmChallengeRaw(realm));
		}

		/// <summary>
		///		Gets the raw response for the leaderboard of the specified realms.
		/// </summary>
		/// <param name="realm">The realm to retrieve.</param>
		/// <returns>
		///		The JSON response returned from the API call.
		/// </returns>
		public string GetRealmChallengeRaw(string realm)
		{
			StringBuilder query = new StringBuilder();
			query.AppendQueryStringPair(_localeQueryStringKey, CurrentLocale);

			string urlPath = string.Format(ApiSettings[_apiKeyRealmChallenge].Path, realm);

			return GetResponse(urlPath, query.ToString());
		}

		#endregion

		#region Character Profile API

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetCharacterProfileRaw"/>.
		/// </summary>
		/// <param name="jsonResponse">The string to deserialize.</param>
		/// <returns>
		///		A deserialized <see cref="T:CharacterProfileResponse"/> object.
		/// </returns>
		public CharacterProfileResponse DeserializeCharacterProfileResponse(string jsonResponse)
		{
			DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(CharacterProfileResponse));

			using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonResponse)))
			{
				CharacterProfileResponse deserializedResponse = (CharacterProfileResponse)serializer.ReadObject(stream);
				deserializedResponse.JsonResponse = jsonResponse;

				return deserializedResponse;
			}
		}

		/// <summary>
		///		Gets the profile of the specified character on the specified realm.
		/// </summary>
		/// <param name="realm">The realm that the character is on.</param>
		/// <param name="character">The name of the character.</param>
		/// <param name="fields">A bitwise combination of the enumeration values.</param>
		/// <returns>
		///		A deserialized <see cref="T:CharacterProfileResponse"/> object.
		/// </returns>
		public CharacterProfileResponse GetCharacterProfile(string realm, string character, CharacterProfileOptionalFieldsEnum fields)
		{
			return DeserializeCharacterProfileResponse(GetCharacterProfileRaw(realm, character, fields));
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
			string response;
			StringBuilder query = new StringBuilder();

			if (fields != CharacterProfileOptionalFieldsEnum.None)
			{
				StringBuilder flags = new StringBuilder();

				foreach (string flag in Enum.GetNames(typeof(CharacterProfileOptionalFieldsEnum)))
				{
					if (flag.Equals("None", StringComparison.InvariantCultureIgnoreCase) || flag.Equals("All", StringComparison.InvariantCultureIgnoreCase)) { continue; }

					CharacterProfileOptionalFieldsEnum flagValue = (CharacterProfileOptionalFieldsEnum)Enum.Parse(typeof(CharacterProfileOptionalFieldsEnum), flag);

					if (fields.HasFlag(flagValue))
					{
						if (flags.Length > 0) { flags.Append(","); }

						MemberInfo memberInfo = typeof(CharacterProfileOptionalFieldsEnum).GetMember(flag)[0];
						EnumMemberAttribute attribute = (EnumMemberAttribute)memberInfo.GetCustomAttributes(typeof(EnumMemberAttribute), true)[0];

						flags.Append(attribute.Value);
					}
				}

				query.AppendQueryStringPair(_fieldsQueryStringKey, flags.ToString());
			}

			query.AppendQueryStringPair(_localeQueryStringKey, CurrentLocale);

			string urlPath = string.Format(ApiSettings[_apiKeyCharacterProfile].Path, realm, character);

			return (response = GetResponse(urlPath, query.ToString()));
		}

		#endregion

		#region Guild Profile API

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetGuildProfileRaw"/>.
		/// </summary>
		/// <param name="jsonResponse">The string to deserialize.</param>
		/// <returns>
		///		A deserialized <see cref="T:GuildProfileResponse"/> object.
		/// </returns>
		public GuildProfileResponse DeserializeGuildProfileResponse(string jsonResponse)
		{
			DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(GuildProfileResponse));

			using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonResponse)))
			{
				GuildProfileResponse deserializedResponse = (GuildProfileResponse)serializer.ReadObject(stream);
				deserializedResponse.JsonResponse = jsonResponse;

				return deserializedResponse;
			}
		}

		/// <summary>
		///		Gets the profile of the specified guild on the specified realm.
		/// </summary>
		/// <param name="realm">The realm that the guild is on.</param>
		/// <param name="guild">The name of the guild.</param>
		/// <param name="fields">A bitwise combination of the enumeration values.</param>
		/// <returns>
		///		A deserialized <see cref="T:GuildProfileResponse"/> object.
		/// </returns>
		public GuildProfileResponse GetGuildProfile(string realm, string guild, GuildProfileOptionalFieldsEnum fields)
		{
			return DeserializeGuildProfileResponse(GetGuildProfileRaw(realm, guild, fields));
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
			string response;
			StringBuilder query = new StringBuilder();

			if (fields != GuildProfileOptionalFieldsEnum.None)
			{
				StringBuilder flags = new StringBuilder();

				foreach (string flag in Enum.GetNames(typeof(GuildProfileOptionalFieldsEnum)))
				{
					if (flag.Equals("None", StringComparison.InvariantCultureIgnoreCase) || flag.Equals("All", StringComparison.InvariantCultureIgnoreCase)) { continue; }

					GuildProfileOptionalFieldsEnum flagValue = (GuildProfileOptionalFieldsEnum)Enum.Parse(typeof(GuildProfileOptionalFieldsEnum), flag);

					if (fields.HasFlag(flagValue))
					{
						if (flags.Length > 0) { flags.Append(","); }

						MemberInfo memberInfo = typeof(GuildProfileOptionalFieldsEnum).GetMember(flag)[0];
						EnumMemberAttribute attribute = (EnumMemberAttribute)memberInfo.GetCustomAttributes(typeof(EnumMemberAttribute), true)[0];

						flags.Append(attribute.Value);
					}
				}

				query.AppendQueryStringPair(_fieldsQueryStringKey, flags.ToString());
			}

			query.AppendQueryStringPair(_localeQueryStringKey, CurrentLocale);

			string urlPath = string.Format(ApiSettings[_apiKeyGuildProfile].Path, realm, guild);

			return (response = GetResponse(urlPath, query.ToString()));
		}

		#endregion

		#region Item API

		#region Individual Item

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetItemRaw"/>.
		/// </summary>
		/// <param name="jsonResponse">The string to deserialize.</param>
		/// <returns>
		///		A <see cref="T:ItemResponse"/> object.
		/// </returns>
		public ItemResponse DeserializeItemResponse(string jsonResponse)
		{
			DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ItemResponse));

			using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonResponse)))
			{
				ItemResponse deserializedResponse = (ItemResponse)serializer.ReadObject(stream);
				deserializedResponse.JsonResponse = jsonResponse;

				return deserializedResponse;
			}
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
			return DeserializeItemResponse(GetItemRaw(itemId));
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
			string returnValue;

			StringBuilder query = new StringBuilder();
			query.AppendQueryStringPair(_localeQueryStringKey, CurrentLocale);

			string urlPath = string.Format(ApiSettings[_apiKeyItem].Path, itemId);

			return (returnValue = GetResponse(urlPath, query.ToString()));
		}

		#endregion

		#region Item Set

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetItemRaw"/>.
		/// </summary>
		/// <param name="jsonResponse">The string to deserialize.</param>
		/// <returns>
		///		A <see cref="T:ItemSetResponse"/> object.
		/// </returns>
		public ItemSetResponse DeserializeItemSetResponse(string jsonResponse)
		{
			DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ItemSetResponse));

			using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonResponse)))
			{
				ItemSetResponse deserializedResponse = (ItemSetResponse)serializer.ReadObject(stream);
				deserializedResponse.JsonResponse = jsonResponse;

				return deserializedResponse;
			}
		}

		/// <summary>
		///		Gets the details of the specified item set.
		/// </summary>
		/// <param name="setId">The id of the item set to get details for.</param>
		/// <returns>
		///		A <see cref="T:ItemSetResponse"/> object.
		/// </returns>
		public ItemSetResponse GetItemSet(int setId)
		{
			return DeserializeItemSetResponse(GetItemSetRaw(setId));
		}

		/// <summary>
		///		Gets the raw response for the details of the specified item set.
		/// </summary>
		/// <param name="setId">The id of the item set to get details for.</param>
		/// <returns>
		///		The JSON response returned from the API call.
		/// </returns>
		public string GetItemSetRaw(int setId)
		{
			string returnValue;

			StringBuilder query = new StringBuilder();
			query.AppendQueryStringPair(_localeQueryStringKey, CurrentLocale);

			string urlPath = string.Format(ApiSettings[_apiKeyItemSet].Path, setId);

			return (returnValue = GetResponse(urlPath, query.ToString()));
		}

		#endregion

		#endregion

		#region PVP API

		#region Arena Ladder API

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetArenaLadderRaw"/>.
		/// </summary>
		/// <param name="jsonResponse">The string to deserialize.</param>
		/// <returns>
		///		A deserialized <see cref="T:ArenaLadderResponse"/> object.
		/// </returns>
		public ArenaLadderResponse DeserializeArenaLadderResponse(string jsonResponse)
		{
			DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ArenaLadderResponse));

			using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonResponse)))
			{
				ArenaLadderResponse deserializedResponse = (ArenaLadderResponse)serializer.ReadObject(stream);
				deserializedResponse.JsonResponse = jsonResponse;

				return deserializedResponse;
			}
		}

		/// <summary>
		///		Gets the profile of the specified arena team ladder on the specified battlegroup.
		/// </summary>
		/// <param name="battlegroup">The battlegroup.</param>
		/// <param name="teamSize">The team size.</param>
		/// <param name="pageNumber">Page number to return. Defaults to 1.</param>
		/// <param name="pageSize">Number of results per page. Defaults to 50.</param>
		/// <param name="ascendingOrder"><b>true</b> to return the results in ascending order,
		///		<b>false</b> for descending order. Defaults to <b>true</b>.</param>
		/// <returns>
		///		A deserialized <see cref="T:ArenaLadderResponse"/> object.
		/// </returns>
		public ArenaLadderResponse GetArenaLadder(string battlegroup, ArenaTeamSizeEnum teamSize, int? pageNumber = null, int? pageSize = null, bool? ascendingOrder = null)
		{
			return DeserializeArenaLadderResponse(GetArenaLadderRaw(battlegroup, teamSize, pageNumber, pageSize, ascendingOrder));
		}

		/// <summary>
		///		Gets the raw response for the specified arena team ladder on the specified battlegroup.
		/// </summary>
		/// <param name="battlegroup">The battlegroup.</param>
		/// <param name="teamSize">The team size.</param>
		/// <param name="pageNumber">Page number to return. Defaults to 1.</param>
		/// <param name="pageSize">Number of results per page. Defaults to 50.</param>
		/// <param name="ascendingOrder"><b>true</b> to return the results in ascending order,
		///		<b>false</b> for descending order. Defaults to <b>true</b>.</param>
		/// <returns>
		///		The JSON response returned from the API call.
		/// </returns>
		public string GetArenaLadderRaw(string battlegroup, ArenaTeamSizeEnum teamSize, int? pageNumber = null, int? pageSize = null, bool? ascendingOrder = null)
		{
			StringBuilder query = new StringBuilder();
			query.AppendQueryStringPair("page", pageNumber);
			query.AppendQueryStringPair("size", pageSize);
			query.AppendQueryStringPair("asc", ascendingOrder);
			query.AppendQueryStringPair(_localeQueryStringKey, CurrentLocale);

			string teamSizeName = teamSize.ToString("F").Replace("Arena", string.Empty);
			string urlPath = string.Format(ApiSettings[_apiKeyArenaLadder].Path, battlegroup, teamSizeName);

			return GetResponse(urlPath, query.ToString());
		}

		#endregion

		#region Arena Team API

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetArenaTeamRaw"/>.
		/// </summary>
		/// <param name="jsonResponse">The string to deserialize.</param>
		/// <returns>
		///		A deserialized <see cref="T:ArenaTeamResponse"/> object.
		/// </returns>
		public ArenaTeamResponse DeserializeArenaTeamResponse(string jsonResponse)
		{
			DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ArenaTeamResponse));

			using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonResponse)))
			{
				ArenaTeamResponse deserializedResponse = (ArenaTeamResponse)serializer.ReadObject(stream);
				deserializedResponse.JsonResponse = jsonResponse;

				return deserializedResponse;
			}
		}

		/// <summary>
		///		Gets the profile of the specified arena team on the specified realm.
		/// </summary>
		/// <param name="realm">The realm that the team is on.</param>
		/// <param name="teamSize">The team size.</param>
		/// <param name="teamName">The name of the team.</param>
		/// <returns>
		///		A deserialized <see cref="T:ArenaTeamResponse"/> object.
		/// </returns>
		public ArenaTeamResponse GetArenaTeam(string realm, ArenaTeamSizeEnum teamSize, string teamName)
		{
			return DeserializeArenaTeamResponse(GetArenaTeamRaw(realm, teamSize, teamName));
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

		#region Rated Battleground Ladder API

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetArenaLadderRaw"/>.
		/// </summary>
		/// <param name="jsonResponse">The string to deserialize.</param>
		/// <returns>
		///		A deserialized <see cref="T:RatedBattlegroundLadderResponse"/> object.
		/// </returns>
		public RatedBattlegroundLadderResponse DeserializeRatedBattlegroundLadderResponse(string jsonResponse)
		{
			DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(RatedBattlegroundLadderResponse));

			using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonResponse)))
			{
				RatedBattlegroundLadderResponse deserializedResponse = (RatedBattlegroundLadderResponse)serializer.ReadObject(stream);
				deserializedResponse.JsonResponse = jsonResponse;

				return deserializedResponse;
			}
		}

		/// <summary>
		///		Gets the profile of the specified rated battleground ladder.
		/// </summary>
		/// <param name="pageNumber">Page number to return. Defaults to 1.</param>
		/// <param name="pageSize">Number of results per page. Defaults to 50.</param>
		/// <param name="ascendingOrder"><b>true</b> to return the results in ascending order,
		///		<b>false</b> for descending order. Defaults to <b>true</b>.</param>
		/// <returns>
		///		A deserialized <see cref="T:RatedBattlegroundLadderResponse"/> object.
		/// </returns>
		public RatedBattlegroundLadderResponse GetRatedBattlegroundLadder(int? pageNumber = null, int? pageSize = null, bool? ascendingOrder = null)
		{
			return DeserializeRatedBattlegroundLadderResponse(GetRatedBattlegroundLadderRaw(pageNumber, pageSize, ascendingOrder));
		}

		/// <summary>
		///		Gets the raw response for the specified rated battleground ladder.
		/// </summary>
		/// <param name="pageNumber">Page number to return. Defaults to 1.</param>
		/// <param name="pageSize">Number of results per page. Defaults to 50.</param>
		/// <param name="ascendingOrder"><b>true</b> to return the results in ascending order,
		///		<b>false</b> for descending order. Defaults to <b>true</b>.</param>
		/// <returns>
		///		The JSON response returned from the API call.
		/// </returns>
		public string GetRatedBattlegroundLadderRaw(int? pageNumber = null, int? pageSize = null, bool? ascendingOrder = null)
		{
			StringBuilder query = new StringBuilder();
			query.AppendQueryStringPair("page", pageNumber);
			query.AppendQueryStringPair("size", pageSize);
			query.AppendQueryStringPair("asc", ascendingOrder);
			query.AppendQueryStringPair(_localeQueryStringKey, CurrentLocale);

			string urlPath = string.Format(ApiSettings[_apiKeyRatedBattlegroundLadder].Path);

			return GetResponse(urlPath, query.ToString());
		}

		#endregion

		#endregion

		#region Quest API

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetQuestRaw"/>.
		/// </summary>
		/// <param name="jsonResponse">The string to deserialize.</param>
		/// <returns>
		///		A deserialized <see cref="QuestResponse"/> object.
		/// </returns>
		public QuestResponse DeserializeQuestResponse(string jsonResponse)
		{
			DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(QuestResponse));

			using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonResponse)))
			{
				QuestResponse deserializedResponse = (QuestResponse)serializer.ReadObject(stream);
				deserializedResponse.JsonResponse = jsonResponse;

				return deserializedResponse;
			}
		}

		/// <summary>
		///		Gets the details for the specified quest.
		/// </summary>
		/// <param name="questId">The id of the quest to get details for.</param>
		/// <returns>
		///		A deserialized <see cref="QuestResponse"/> object.
		/// </returns>
		public QuestResponse GetQuest(int questId)
		{
			return DeserializeQuestResponse(GetQuestRaw(questId));
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

		#region Realm Status API

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetRealmStatusRaw"/>.
		/// </summary>
		/// <param name="jsonResponse">The string to deserialize.</param>
		/// <returns>
		///		A deserialized <see cref="RealmStatusResponse"/> object.
		/// </returns>
		public RealmStatusResponse DeserializeRealmStatusResponse(string jsonResponse)
		{
			DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(RealmStatusResponse));

			using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonResponse)))
			{
				RealmStatusResponse deserializedResponse = (RealmStatusResponse)serializer.ReadObject(stream);
				deserializedResponse.JsonResponse = jsonResponse;

				return deserializedResponse;
			}
		}

		/// <summary>
		///		Gets the status of the specified realms.  If relams is null or empty, the entire
		///		list of realms for the region is returned.
		/// </summary>
		/// <param name="realms">A comma seperated list of realms to retrieve. (optional)</param>
		/// <returns>
		///		A deserialized <see cref="RealmStatusResponse"/> object.
		/// </returns>
		public RealmStatusResponse GetRealmStatus(string realms = null)
		{
			return DeserializeRealmStatusResponse(GetRealmStatusRaw(realms));
		}

		/// <summary>
		///		Gets the status of the specified realms.  If relams is null or empty, the entire
		///		list of realms for the region is returned.
		/// </summary>
		/// <param name="realms">An <see cref="T:IEnumerable&lt;string&gt;"/> list of realms to retrieve.</param>
		/// <returns>
		///		A deserialized <see cref="RealmStatusResponse"/> object.
		/// </returns>
		public RealmStatusResponse GetRealmStatus(IEnumerable<string> realms)
		{
			return DeserializeRealmStatusResponse(GetRealmStatusRaw(JoinList(realms)));
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
			query.AppendQueryStringPair(_realmsQueryStringKey, realms);
			query.AppendQueryStringPair(_localeQueryStringKey, CurrentLocale);

			string urlPath = ApiSettings[_apiKeyRealmStatus].Path;

			return GetResponse(urlPath, query.ToString());
		}

		#endregion

		#region Recipe API

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetRecipeRaw"/>.
		/// </summary>
		/// <param name="jsonResponse">The string to deserialize.</param>
		/// <returns>
		///		A deserialized <see cref="RecipeResponse"/> object.
		/// </returns>
		public RecipeResponse DeserializeRecipeResponse(string jsonResponse)
		{
			DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(RecipeResponse));

			using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonResponse)))
			{
				RecipeResponse deserializedResponse = (RecipeResponse)serializer.ReadObject(stream);
				deserializedResponse.JsonResponse = jsonResponse;

				return deserializedResponse;
			}
		}

		/// <summary>
		///		Gets the details for the specified recipe.
		/// </summary>
		/// <param name="recipeId">The id of the recipe to get details for.</param>
		/// <returns>
		///		A deserialized <see cref="RecipeResponse"/> object.
		/// </returns>
		public RecipeResponse GetRecipe(int recipeId)
		{
			return DeserializeRecipeResponse(GetRecipeRaw(recipeId));
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

		#region Spell API

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetSpellRaw"/>.
		/// </summary>
		/// <param name="jsonResponse">The string to deserialize.</param>
		/// <returns>
		///		A deserialized <see cref="SpellResponse"/> object.
		/// </returns>
		public SpellResponse DeserializeSpellResponse(string jsonResponse)
		{
			DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(SpellResponse));

			using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonResponse)))
			{
				SpellResponse deserializedResponse = (SpellResponse)serializer.ReadObject(stream);
				deserializedResponse.JsonResponse = jsonResponse;

				return deserializedResponse;
			}
		}

		/// <summary>
		///		Gets the details for the specified Spell.
		/// </summary>
		/// <param name="SpellId">The id of the Spell to get details for.</param>
		/// <returns>
		///		A deserialized <see cref="SpellResponse"/> object.
		/// </returns>
		public SpellResponse GetSpell(int SpellId)
		{
			return DeserializeSpellResponse(GetSpellRaw(SpellId));
		}

		/// <summary>
		///		Gets the raw response for the details of the specified Spell.
		/// </summary>
		/// <param name="SpellId">The id of the Spell to get details for.</param>
		/// <returns>
		///		The JSON response returned from the API call.
		/// </returns>
		public string GetSpellRaw(int SpellId)
		{
			StringBuilder query = new StringBuilder();
			query.AppendQueryStringPair(_localeQueryStringKey, CurrentLocale);

			string urlPath = string.Format(ApiSettings[_apiKeySpell].Path, SpellId);

			return GetResponse(urlPath, query.ToString());
		}

		#endregion

		#region Data Resources

		#region Battlegroups

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetBattlegroupsRaw"/>.
		/// </summary>
		/// <param name="jsonResponse">The string to deserialize.</param>
		/// <returns>
		///		A deserialized <see cref="T:BattlegroupResponse"/> object.
		/// </returns>
		public BattlegroupsResponse DeserializeBattlegroupsResponse(string jsonResponse)
		{
			DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(BattlegroupsResponse));

			using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonResponse)))
			{
				BattlegroupsResponse deserializedResponse = (BattlegroupsResponse)serializer.ReadObject(stream);
				deserializedResponse.JsonResponse = jsonResponse;

				return deserializedResponse;
			}
		}

		/// <summary>
		///		Gets the battlegroups.
		/// </summary>
		/// <returns>
		///		A deserialized <see cref="T:BattlegroupResponse"/> object.
		/// </returns>
		public BattlegroupsResponse GetBattlegroups()
		{
			return DeserializeBattlegroupsResponse(GetBattlegroupsRaw());
		}

		/// <summary>
		///		Gets the raw response for the battlegroups.
		/// </summary>
		/// <returns>
		///		The JSON response returned from the API call.
		/// </returns>
		public string GetBattlegroupsRaw()
		{
			string returnValue;

			StringBuilder query = new StringBuilder();
			query.AppendQueryStringPair(_localeQueryStringKey, CurrentLocale);

			string urlPath = ApiSettings[_apiKeyBattlegroups].Path;

			return (returnValue = GetResponse(urlPath, query.ToString()));
		}

		#endregion

		#region Character Achievements

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetCharacterAchievementsRaw"/>.
		/// </summary>
		/// <param name="jsonResponse">The string to deserialize.</param>
		/// <returns>
		///		A deserialized <see cref="T:DataAchievementsResponse"/> object.
		/// </returns>
		public DataAchievementsResponse DeserializeCharacterAchievementsResponse(string jsonResponse)
		{
			DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(DataAchievementsResponse));

			using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonResponse)))
			{
				DataAchievementsResponse deserializedResponse = (DataAchievementsResponse)serializer.ReadObject(stream);
				deserializedResponse.JsonResponse = jsonResponse;

				return deserializedResponse;
			}
		}

		/// <summary>
		///		Gets the character achievements.
		/// </summary>
		/// <returns>
		///		A deserialized <see cref="T:DataAchievementsResponse"/> object.
		/// </returns>
		public DataAchievementsResponse GetCharacterAchievements()
		{
			return DeserializeCharacterAchievementsResponse(GetCharacterAchievementsRaw());
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
		///		A deserialized <see cref="T:CharacterClassesResponse"/> object.
		/// </returns>
		public CharacterClassesResponse DeserializeCharacterClassesResponse(string jsonResponse)
		{
			DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(CharacterClassesResponse));

			using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonResponse)))
			{
				CharacterClassesResponse deserializedResponse = (CharacterClassesResponse)serializer.ReadObject(stream);
				deserializedResponse.JsonResponse = jsonResponse;

				return deserializedResponse;
			}
		}

		/// <summary>
		///		Gets the character classes.
		/// </summary>
		/// <returns>
		///		A deserialized <see cref="T:CharacterClassesResponse"/> object.
		/// </returns>
		public CharacterClassesResponse GetCharacterClasses()
		{
			return DeserializeCharacterClassesResponse(GetCharacterClassesRaw());
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

		#region Character Races

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetCharacterRacesRaw"/>.
		/// </summary>
		/// <param name="jsonResponse">The string to deserialize.</param>
		/// <returns>
		///		A deserialized <see cref="T:CharacterRacesResponse"/> object.
		/// </returns>
		public CharacterRacesResponse DeserializeCharacterRacesResponse(string jsonResponse)
		{
			DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(CharacterRacesResponse));

			using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonResponse)))
			{
				CharacterRacesResponse deserializedResponse = (CharacterRacesResponse)serializer.ReadObject(stream);
				deserializedResponse.JsonResponse = jsonResponse;

				return deserializedResponse;
			}
		}

		/// <summary>
		///		Gets the character races.
		/// </summary>
		/// <returns>
		///		A deserialized <see cref="T:CharacterRacesResponse"/> object.
		/// </returns>
		public CharacterRacesResponse GetCharacterRaces()
		{
			return DeserializeCharacterRacesResponse(GetCharacterRacesRaw());
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
		///		A deserialized <see cref="T:DataAchievementsResponse"/> object.
		/// </returns>
		public DataAchievementsResponse DeserializeGuildAchievementsResponse(string jsonResponse)
		{
			DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(DataAchievementsResponse));

			using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonResponse)))
			{
				DataAchievementsResponse deserializedResponse = (DataAchievementsResponse)serializer.ReadObject(stream);
				deserializedResponse.JsonResponse = jsonResponse;

				return deserializedResponse;
			}
		}

		/// <summary>
		///		Gets the guild achievements.
		/// </summary>
		/// <returns>
		///		A deserialized <see cref="T:DataAchievementsResponse"/> object.
		/// </returns>
		public DataAchievementsResponse GetGuildAchievements()
		{
			return DeserializeGuildAchievementsResponse(GetGuildAchievementsRaw());
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
		///		A deserialized <see cref="T:GuildPerksResponse"/> object.
		/// </returns>
		public GuildPerksResponse DeserializeGuildPerksResponse(string jsonResponse)
		{
			DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(GuildPerksResponse));

			using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonResponse)))
			{
				GuildPerksResponse deserializedResponse = (GuildPerksResponse)serializer.ReadObject(stream);
				deserializedResponse.JsonResponse = jsonResponse;

				return deserializedResponse;
			}
		}

		/// <summary>
		///		Gets the guild perks.
		/// </summary>
		/// <returns>
		///		A deserialized <see cref="T:GuildPerksResponse"/> object.
		/// </returns>
		public GuildPerksResponse GetGuildPerks()
		{
			return DeserializeGuildPerksResponse(GetGuildPerksRaw());
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

		#region Guild Rewards

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetGuildRewardsRaw"/>.
		/// </summary>
		/// <param name="jsonResponse">The string to deserialize.</param>
		/// <returns>
		///		A deserialized <see cref="T:GuildRewardsResponse"/> object.
		/// </returns>
		public GuildRewardsResponse DeserializeGuildRewardsResponse(string jsonResponse)
		{
			DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(GuildRewardsResponse));

			using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonResponse)))
			{
				GuildRewardsResponse deserializedResponse = (GuildRewardsResponse)serializer.ReadObject(stream);
				deserializedResponse.JsonResponse = jsonResponse;

				return deserializedResponse;
			}
		}

		/// <summary>
		///		Gets the guild rewards.
		/// </summary>
		/// <returns>
		///		A deserialized <see cref="T:GuildRewardsResponse"/> object.
		/// </returns>
		public GuildRewardsResponse GetGuildRewards()
		{
			return DeserializeGuildRewardsResponse(GetGuildRewardsRaw());
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

		#region Item Classes

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetItemClassesRaw"/>.
		/// </summary>
		/// <param name="jsonResponse">The string to deserialize.</param>
		/// <returns>
		///		A deserialized <see cref="T:ItemClassesResponse"/> object.
		/// </returns>
		public ItemClassesResponse DeserializeItemClassesResponse(string jsonResponse)
		{
			DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ItemClassesResponse));

			using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonResponse)))
			{
				ItemClassesResponse deserializedResponse = (ItemClassesResponse)serializer.ReadObject(stream);
				deserializedResponse.JsonResponse = jsonResponse;

				return deserializedResponse;
			}
		}

		/// <summary>
		///		Gets the item classes.
		/// </summary>
		/// <returns>
		///		A deserialized <see cref="T:ItemClassesResponse"/> object.
		/// </returns>
		public ItemClassesResponse GetItemClasses()
		{
			return DeserializeItemClassesResponse(GetItemClassesRaw());
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

		#region Pet Types

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetPetTypesRaw"/>.
		/// </summary>
		/// <param name="jsonResponse">The string to deserialize.</param>
		/// <returns>
		///		A deserialized <see cref="T:PetTypesResponse"/> object.
		/// </returns>
		public PetTypesResponse DeserializePetTypesResponse(string jsonResponse)
		{
			DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(PetTypesResponse));

			using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonResponse)))
			{
				PetTypesResponse deserializedResponse = (PetTypesResponse)serializer.ReadObject(stream);
				deserializedResponse.JsonResponse = jsonResponse;

				return deserializedResponse;
			}
		}

		/// <summary>
		///		Gets the pet types.
		/// </summary>
		/// <returns>
		///		A deserialized <see cref="T:PetTypesResponse"/> object.
		/// </returns>
		public PetTypesResponse GetPetTypes()
		{
			return DeserializePetTypesResponse(GetPetTypesRaw());
		}

		/// <summary>
		///		Gets the raw response for pet types.
		/// </summary>
		/// <returns>
		///		The JSON response returned from the API call.
		/// </returns>
		public string GetPetTypesRaw()
		{
			StringBuilder query = new StringBuilder();
			query.AppendQueryStringPair(_localeQueryStringKey, CurrentLocale);

			string urlPath = ApiSettings[_apiKeyPetTypes].Path;

			return GetResponse(urlPath, query.ToString());
		}

		#endregion

		#region Talents

		/// <summary>
		///		Deserializes the JSON response from <see cref="M:GetTalentsRaw"/>.
		/// </summary>
		/// <param name="jsonResponse">The string to deserialize.</param>
		/// <returns>
		///		A deserialized <see cref="T:TalentsResponse"/> object.
		/// </returns>
		public TalentsResponse DeserializeTalentsResponse(string jsonResponse)
		{
			DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(TalentsResponse));

			using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonResponse)))
			{
				TalentsResponse deserializedResponse = (TalentsResponse)serializer.ReadObject(stream);
				deserializedResponse.JsonResponse = jsonResponse;

				return deserializedResponse;
			}
		}

		/// <summary>
		///		Gets the talents.
		/// </summary>
		/// <returns>
		///		A deserialized <see cref="T:TalentsResponse"/> object.
		/// </returns>
		public TalentsResponse GetTalents()
		{
			return DeserializeTalentsResponse(GetTalentsRaw());
		}

		/// <summary>
		///		Gets the raw response for talents.
		/// </summary>
		/// <returns>
		///		The JSON response returned from the API call.
		/// </returns>
		public string GetTalentsRaw()
		{
			StringBuilder query = new StringBuilder();
			query.AppendQueryStringPair(_localeQueryStringKey, CurrentLocale);

			string urlPath = ApiSettings[_apiKeyTalents].Path;

			return GetResponse(urlPath, query.ToString());
		}

		#endregion

		#endregion

		#endregion

		#region Private Methods

		private string GetResponse(HttpWebRequest request)
		{
			string returnValue;

			try
			{
				request.AutomaticDecompression = DecompressionMethods.GZip;

				HttpWebResponse response = (HttpWebResponse)request.GetResponse();
				string responseContentEncoding = response.Headers[HttpResponseHeader.ContentEncoding];

				if (responseContentEncoding != null && responseContentEncoding.IndexOf("gzip", StringComparison.InvariantCultureIgnoreCase) != -1)
				{
					using (Stream stream = response.GetResponseStream())
					using (GZipStream gzip = new GZipStream(stream, CompressionMode.Decompress))
					using (StreamReader reader = new StreamReader(gzip))
					{
						return (returnValue = reader.ReadToEnd());
					}
				}
				else
				{
					using (Stream stream = response.GetResponseStream())
					using (StreamReader reader = new StreamReader(stream))
					{
						return (returnValue = reader.ReadToEnd());
					}
				}
			}
			catch (WebException ex)
			{
				if (ex.Response == null) { throw; }

				try
				{
					using (Stream stream = ex.Response.GetResponseStream())
					{
						DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ErrorResponse));
						ErrorResponse deserializedResponse = (ErrorResponse)serializer.ReadObject(stream);

						throw new WorldOfWarcraftApiException(deserializedResponse.Status, deserializedResponse.Reason);
					}
				}
				catch (WorldOfWarcraftApiException) { throw; }
				catch { }

				throw;
			}
		}

		private string GetResponse(string urlPath, string queryString)
		{
			string returnValue;

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

			return (returnValue = GetResponse(request));
		}

		private string GetSignature(string stringToSign)
		{
			string returnValue;

			using (HMACSHA1 hmac = new HMACSHA1(Encoding.UTF8.GetBytes(PrivateKey)))
			{
				byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(stringToSign));
				return (returnValue = Convert.ToBase64String(hash));
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
