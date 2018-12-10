using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TownOfSalem_Logic.UserData
{
    public static class PlayerManager
    {
        private static Dictionary<(int, string), UserData> AllJsons;

        static PlayerManager()
        {
            if (!Directory.Exists("Database"))
            {
                Directory.CreateDirectory("Database");
            }

            AllJsons = new Dictionary<(int, string), UserData>();
            var path = Path.GetFullPath("Database");
            foreach (var file in Directory.GetFiles(path))
            {
                if (!file.EndsWith(".json"))
                {
                    continue;
                }

                var id = int.Parse(Path.GetFileNameWithoutExtension(file));
                var data = JObject.Parse(File.ReadAllText($"Database/{id}.json"));

                AllJsons.Add((id, data.Value<string>("UserName")), null);
            }
        }

        public static UserData GetUserData(int userId)
        {
            if (AllJsons.All(x => x.Key.Item1 != userId))
            {
                return null;
            }

            var json = File.ReadAllText($"Database/{userId}.json");
            var data = JObject.Parse(json);
            var userName = data.Value<string>("userName");
            return AllJsons[(userId, userName)] = JsonConvert.DeserializeObject<UserData>(json);
        }

        public static UserData GetUserData(string userName)
        {
            var kvp = AllJsons.FirstOrDefault(x => x.Key.Item2 != null && x.Key.Item2.Equals(userName));
            if (kvp.Key.Item2 == null || !kvp.Key.Item2.Equals(userName))
            {
                return null;
            }

            var userData = kvp.Value;
            if (userData != null)
            {
                return userData;
            }

            var userId = kvp.Key.Item1;
            var json = File.ReadAllText($"Database/{userId}.json");
            return AllJsons[(userId, userName)] = JsonConvert.DeserializeObject<UserData>(json);
        }
    }
}
