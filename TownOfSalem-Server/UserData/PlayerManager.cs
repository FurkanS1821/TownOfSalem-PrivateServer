using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace TownOfSalem_Logic.UserData
{
    public static class PlayerManager
    {
        public static void LoadAndResetAllData()
        {
            Program.AllPlayers.Clear();

            if (!Directory.Exists("Database"))
            {
                Directory.CreateDirectory("Database");
            }

            var path = Path.GetFullPath("Database");

            foreach (var file in Directory.GetFiles(path, "*-*.json"))
            {
                var fileName = Path.GetFileNameWithoutExtension(file).Split('-');

                var id = int.Parse(fileName[0]);
                var userName = fileName[1];

                Program.AllPlayers.Add(new Player {Data = GetUserData(id, userName)});
            }
        }

        private static UserData GetUserData(int userId, string userName)
        {
            var json = File.ReadAllText($"Database/{userId}-{userName}.json");
            return JsonConvert.DeserializeObject<UserData>(json);
        }

        public static Player FindUser(string userName)
        {
            lock (Program.PlayersLock)
            {
                return Program.AllPlayers.FirstOrDefault(
                    x => x.Data.UserName.Equals(userName, StringComparison.InvariantCultureIgnoreCase)
                );
            }
        }

        public static Player FindUser(int userId)
        {
            lock (Program.PlayersLock)
            {
                return Program.AllPlayers.FirstOrDefault(x => x.Data.UserId == userId);
            }
        }
    }
}
