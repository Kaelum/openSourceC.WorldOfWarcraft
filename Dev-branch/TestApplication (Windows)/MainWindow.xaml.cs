using System;
using System.Diagnostics;
using System.Windows;

using openSourceC.WorldOfWarcraft;
using openSourceC.WorldOfWarcraftClient;

namespace TestApplication
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		/// <summary>
		///		Constructor.
		/// </summary>
		public MainWindow()
		{
			InitializeComponent();

			PrivateKeyTextBox.Text = Properties.Settings.Default.PrivateKey;
			PublicKeyTextBox.Text = Properties.Settings.Default.PublicKey;
		}

		private void RunTestButton_Click(object sender, RoutedEventArgs e)
		{
			//Dispatcher.BeginInvoke()
			RunTestButton.IsEnabled = false;

			AsyncCallback callback = delegate(IAsyncResult ar)
			{
				Dispatcher.Invoke((Action)delegate
				{
					RunTestButton.IsEnabled = true;
				});
			};

			((Action<object, RoutedEventArgs>)RunTestAsynchronously).BeginInvoke(
				sender,
				e,
				callback,
				null
			);
		}

		private class Keys
		{
			public string privateKey;
			public string publicKey;
		}

		#region Business Methods (Threaded)

		private void RunTestAsynchronously(object sender, RoutedEventArgs e)
		{
			Dispatcher.Invoke((Action)delegate
			{
				EventMessageListBox.Items.Add(string.Format("{0} - Test START", DateTime.Now));

				ExceptionTextBox.Text = null;
			});

			try
			{
				foreach (RegionElement region in WorldOfWarcraftSection.Instance.Regions)
				{
					Debug.WriteLine("Region: Key = {0}, Name = {1}, Host = {2}", region.Key, region.Name, region.Host);

					foreach (LocaleElement locale in region.Locales)
					{
						Debug.WriteLine(">>> Locale: Key = {0}, Name = {1}", locale.Key, locale.Name);
					}
				}

				Keys keys = Dispatcher.Invoke<Keys>((Func<Keys>)delegate
				{
					return new Keys
					{
						privateKey = (string.IsNullOrWhiteSpace(PrivateKeyTextBox.Text) ? null : PrivateKeyTextBox.Text),
						publicKey = (string.IsNullOrWhiteSpace(PublicKeyTextBox.Text) ? null : PublicKeyTextBox.Text),
					};
				});

				CommunityPlatformClient client = new CommunityPlatformClient(keys.privateKey, keys.publicKey);
				//client.CurrentRegionKey = WorldOfWarcraftSection.Instance.Regions.Default;
				//client.CurrentLocale = "es_MX";

				// The following example shows the use of the Raw method calls which get the JSON
				// response and don't do any additional processing (i.e. no deserialization).
				// These methods are best used when you only need to retrieve the RAW JSON string
				// and send it to the web client.
				string jsonResponse = client.GetBattlegroupsRaw();
				SetJsonTextBox(jsonResponse);

				// The deserialization methods have been left in tact.  They can be used to
				// deserialize responses that have been received from the web client.
				BattlegroupsResponse battlegroupsList = client.DeserializeBattlegroupsResponse(jsonResponse);
				SetJsonTextBox(battlegroupsList.JsonResponse);

				DataAchievementsResponse characterAchievementsResponse = client.GetCharacterAchievements();
				SetJsonTextBox(characterAchievementsResponse.JsonResponse);

				CharacterClassesResponse characterClassesResponse = client.GetCharacterClasses();
				SetJsonTextBox(characterClassesResponse.JsonResponse);

				CharacterRacesResponse characterRacesResponse = client.GetCharacterRaces();
				SetJsonTextBox(characterRacesResponse.JsonResponse);

				DataAchievementsResponse guildAchievements = client.GetGuildAchievements();
				SetJsonTextBox(guildAchievements.JsonResponse);

				GuildPerksResponse guildPerksResponse = client.GetGuildPerks();
				SetJsonTextBox(guildPerksResponse.JsonResponse);

				GuildRewardsResponse guildRewardsResponse = client.GetGuildRewards();
				SetJsonTextBox(guildRewardsResponse.JsonResponse);

				ItemClassesResponse itemClassesResponse = client.GetItemClasses();
				SetJsonTextBox(itemClassesResponse.JsonResponse);

				PetTypesResponse petTypesResponse = client.GetPetTypes();
				SetJsonTextBox(petTypesResponse.JsonResponse);

				TalentsResponse talentsResponse = client.GetTalents();
				SetJsonTextBox(talentsResponse.JsonResponse);

				AchievementResponse achievementResponse = client.GetAchievement(2144);
				SetJsonTextBox(achievementResponse.JsonResponse);

				ArenaLadderResponse arenaLadderResponse = client.GetArenaLadder("Ruin", ArenaTeamSizeEnum.Arena2v2, 1, 1, true);
				SetJsonTextBox(arenaLadderResponse.JsonResponse);

				arenaLadderResponse = client.GetArenaLadder("Ruin", ArenaTeamSizeEnum.Arena2v2, 2, 1, true);
				SetJsonTextBox(arenaLadderResponse.JsonResponse);

				ArenaTeamResponse arenaTeamResponse = client.GetArenaTeam("Bonechewer", ArenaTeamSizeEnum.Arena2v2, "Samurai Jack");
				SetJsonTextBox(arenaTeamResponse.JsonResponse);

				AuctionDataStatusResponse auctionDataStatusResponse = client.GetAuctionDataStatus("lothar");
				SetJsonTextBox(auctionDataStatusResponse.JsonResponse);

				foreach (AuctionDataStatus auctionData in auctionDataStatusResponse.Files)
				{
					try
					{
						auctionData.Data = client.GetAuctionDataFile(auctionData.Url);
						SetJsonTextBox(auctionData.Data.JsonResponse);
					}
					catch (WorldOfWarcraftApiException ex)
					{
						Debug.WriteLine("WorldOfWarcraftApiException:\n\tGetAuctionDataFile: {0}\n\tStatus: {1}\n\tMessage: {2}", auctionData.Url, ex.Status, ex.Message);
					}
					catch (Exception ex)
					{
						Debug.WriteLine("WorldOfWarcraftApiException:\n\tGetAuctionDataFile: {0}\\n\tMessage: {1}", auctionData.Url, ex.Message);
					}
				}

				BattlePetAbilityResponse battlePetAbilityResponse = client.GetBattlePetAbility(640);
				SetJsonTextBox(battlePetAbilityResponse.JsonResponse);

				BattlePetSpeciesResponse battlePetSpeciesResponse = client.GetBattlePetSpecies(258);
				SetJsonTextBox(battlePetSpeciesResponse.JsonResponse);

				BattlePetStatsResponse battlePetStatsResponse = client.GetBattlePetStats(258, 25, 5, 4);
				SetJsonTextBox(battlePetStatsResponse.JsonResponse);

				RealmChallengeResponse realmChallengeResponse = client.GetRealmChallenge("Lothar");
				SetJsonTextBox(realmChallengeResponse.JsonResponse);

				CharacterProfileResponse characterProfileResponse = client.GetCharacterProfile("lothar", "Kaelum", CharacterProfileOptionalFieldsEnum.All);
				SetJsonTextBox(characterProfileResponse.JsonResponse);

				characterProfileResponse = client.GetCharacterProfile("lothar", "Kaelum", CharacterProfileOptionalFieldsEnum.Stats);
				SetJsonTextBox(characterProfileResponse.JsonResponse);

				characterProfileResponse = client.GetCharacterProfile("blackrock", "Caul", CharacterProfileOptionalFieldsEnum.Items);
				SetJsonTextBox(characterProfileResponse.JsonResponse);

				characterProfileResponse = client.GetCharacterProfile("gurubashi", "Chaud", CharacterProfileOptionalFieldsEnum.Pets);
				SetJsonTextBox(characterProfileResponse.JsonResponse);

				characterProfileResponse = client.GetCharacterProfile("lothar", "Kailor", CharacterProfileOptionalFieldsEnum.PetSlots);
				SetJsonTextBox(characterProfileResponse.JsonResponse);

				characterProfileResponse = client.GetCharacterProfile("lothar", "Grewl", CharacterProfileOptionalFieldsEnum.Talents);
				SetJsonTextBox(characterProfileResponse.JsonResponse);

				GuildProfileResponse guildProfileResponse = client.GetGuildProfile("lothar", "Genus Order", GuildProfileOptionalFieldsEnum.All);
				SetJsonTextBox(guildProfileResponse.JsonResponse);

				guildProfileResponse = client.GetGuildProfile("lothar", "Triple Threat", GuildProfileOptionalFieldsEnum.News);
				SetJsonTextBox(guildProfileResponse.JsonResponse);

				ItemResponse itemResponse = client.GetItem(18803);
				SetJsonTextBox(itemResponse.JsonResponse);

				itemResponse = client.GetItem(60244);
				SetJsonTextBox(itemResponse.JsonResponse);

				itemResponse = client.GetItem(60245);
				SetJsonTextBox(itemResponse.JsonResponse);

				itemResponse = client.GetItem(62386);
				SetJsonTextBox(itemResponse.JsonResponse);

				itemResponse = client.GetItem(70142);
				SetJsonTextBox(itemResponse.JsonResponse);

				ItemSetResponse itemSetResponse = client.GetItemSet(931);
				SetJsonTextBox(itemSetResponse.JsonResponse);

				itemSetResponse = client.GetItemSet(1060);
				SetJsonTextBox(itemSetResponse.JsonResponse);

				for (int i = 1; i < 100; i++)
				{
					// The following try-catch block shows how to use WorldOfWarcraftApiException to
					// catch exceptions.  This applies to all of the API method calls.
					try
					{
						QuestResponse questResponse = client.GetQuest(i);
						SetJsonTextBox(questResponse.JsonResponse);
					}
					catch (WorldOfWarcraftApiException ex)
					{
						Debug.WriteLine("Quest({0}): WorldOfWarcraftApiException:\n\tStatus: {1}\n\tMessage: {2}", i, ex.Status, ex.Message);
					}
					catch (Exception ex)
					{
						Debug.WriteLine("Quest({0}): Exception:\n\tMessage: {1}", i, ex.Message);
					}
				}

				RatedBattlegroundLadderResponse ratedBattlegroundLadderResponse = client.GetRatedBattlegroundLadder(1, 1, true);
				SetJsonTextBox(ratedBattlegroundLadderResponse.JsonResponse);

				ratedBattlegroundLadderResponse = client.GetRatedBattlegroundLadder(2, 1, true);
				SetJsonTextBox(ratedBattlegroundLadderResponse.JsonResponse);

				RealmStatusResponse realmStatusResponse = client.GetRealmStatus("lothar,blackrock");
				SetJsonTextBox(realmStatusResponse.JsonResponse);

				RecipeResponse recipeResponse = client.GetRecipe(33994);
				SetJsonTextBox(recipeResponse.JsonResponse);

				SpellResponse spellResponse = client.GetSpell(8056);
				SetJsonTextBox(spellResponse.JsonResponse);
			}
			catch (Exception ex)
			{
				Dispatcher.Invoke((Action)delegate
				{
					ExceptionTextBox.Text = Format.Exception(ex);
				});
			}

			Dispatcher.Invoke((Action)delegate
			{
				EventMessageListBox.Items.Add(string.Format("{0} - Test END", DateTime.Now));
			});
		}

		private void SetJsonTextBox(string message)
		{
			Dispatcher.Invoke((Action)delegate
			{
				JsonTextBox.Text = message;
			});
		}

		#endregion

		#region Control Events

		private void PrivateKeyTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
		{
			Properties.Settings.Default.PrivateKey = PrivateKeyTextBox.Text;
			Properties.Settings.Default.Save();
		}

		private void PublicKeyTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
		{
			Properties.Settings.Default.PublicKey = PublicKeyTextBox.Text;
			Properties.Settings.Default.Save();
		}

		#endregion
	}
}
