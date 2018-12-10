using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using TownOfSalem_Logic.Annotations;
using TownOfSalem_Networking.Structs;

namespace TownOfSalem_Logic.UserData
{
    public class UserData : INotifyPropertyChanged
    {
        [JsonProperty(Required = Required.Always)]
        public int UserId { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string UserName { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string PasswordMd5 { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public UserStatistics UserStatistics { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public UserSettings UserSettings { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public UserSelections UserSelections { get; set; }
        public int TownPoints { get; set; }
        public int MeritPoints { get; set; }
        public float TownPointsMultiplier { get; set; }
        public float MeritPointsMultiplier { get; set; }
        public int LastBonusWinTime { get; set; }
        public int[] EarnedAchievements { get; set; }
        public int[] PurchasedCharacters { get; set; }
        public int[] PurchasedHouses { get; set; }
        public int[] PurchasedBackgrounds { get; set; }
        public int[] PurchasedPets { get; set; }
        public int[] FriendIds { get; set; }
        public int[] PurchasedLobbyIcons { get; set; }
        public int[] PurchasedDeathAnimations { get; set; }
        public Dictionary<int, int> PurchasedScrolls { get; set; }
        public int[] TutorialStatus { get; set; }
        public UserAccountFlags UserAccountFlags { get; set; }
        public RankedInformation RankedInformation { get; set; }

        public UserData()
        {
            PropertyChanged += (sender, args) => Save();
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public void Save()
        {
            File.WriteAllText($"Database/{UserId}.json", ToString());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
