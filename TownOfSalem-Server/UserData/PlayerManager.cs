using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace TownOfSalem_Logic.UserData
{
    public static class PlayerManager
    {
        private static object _idCounterLock = new object();
        private static int _lastUserId;

        public static void ReloadAllData()
        {
            lock (_idCounterLock)
            {
                Program.AllPlayers.Clear();
                _lastUserId = 0;

                if (!Directory.Exists("Database"))
                {
                    Directory.CreateDirectory("Database");
                    return;
                }

                var path = Path.GetFullPath("Database");

                foreach (var file in Directory.GetFiles(path, "*-*.json"))
                {
                    var fileName = Path.GetFileNameWithoutExtension(file).Split('-');

                    var id = int.Parse(fileName[0]);
                    var userName = fileName[1];

                    Program.AllPlayers.Add(new Player {Data = GetUserData(id, userName)});
                    _lastUserId = Math.Max(_lastUserId, id);
                }
            }
        }

        public static Player CreateUser(string username, string passwordEncrypted)
        {
            UserData userData;
            lock (_idCounterLock)
            {
                userData = new UserData
                {
                    PasswordBcrypt = passwordEncrypted,
                    UserName = username,
                    UserId = ++_lastUserId
                };
            }

            userData.Save();
            var player = new Player {Data = userData, LastAction = DateTime.Now};
            Program.AllPlayers.Add(player);
            return player;
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
