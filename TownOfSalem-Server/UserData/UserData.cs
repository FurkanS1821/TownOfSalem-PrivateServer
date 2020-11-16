using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using TownOfSalem_Logic.Properties;
using TownOfSalem_Networking.Structs;

namespace TownOfSalem_Logic.UserData
{
    public class UserData : INotifyPropertyChanged
    {
        [JsonProperty(Required = Required.Always)]
        public int UserId { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string UserName { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string PasswordBcrypt { get; set; }

        [JsonProperty(Required = Required.DisallowNull)]
        public UserStatistics UserStatistics { get; set; } = new UserStatistics();

        [JsonProperty(Required = Required.DisallowNull)]
        public UserSettings UserSettings { get; set; } = new UserSettings();

        [JsonProperty(Required = Required.DisallowNull)]
        public UserSelections UserSelections { get; set; } = new UserSelections();

        public int TownPoints { get; set; }

        public int MeritPoints { get; set; }

        public float TownPointsMultiplier { get; set; } = 1;

        public float MeritPointsMultiplier { get; set; } = 1;

        public int LastBonusWinTime { get; set; }

        public int[] EarnedAchievements { get; set; } = new int[0];

        public int[] PurchasedCharacters { get; set; } = new int[0];

        public int[] PurchasedHouses { get; set; } = new int[0];

        public int[] PurchasedBackgrounds { get; set; } = new int[0];

        public int[] PurchasedPets { get; set; } = new int[0];

        public int[] FriendIds { get; set; } = new int[0];

        public int[] PurchasedLobbyIcons { get; set; } = new int[0];

        public int[] PurchasedDeathAnimations { get; set; } = new int[0];

        public Dictionary<int, int> PurchasedScrolls { get; set; } = new Dictionary<int, int>();

        public int[] TutorialStatus { get; set; } = new int[0];

        public UserAccountFlags UserAccountFlags { get; set; } = new UserAccountFlags();

        public RankedInformation RankedInformation { get; set; } = new RankedInformation();

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
            File.WriteAllText($"Database/{UserId}-{UserName}.json", ToString());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
