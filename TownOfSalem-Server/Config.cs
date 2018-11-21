using System.IO;
using Newtonsoft.Json.Linq;

namespace TownOfSalem_Logic
{
    public class Config
    {
        public Config(string jsonPath)
        {
            if (!File.Exists(jsonPath))
            {
                throw new FileNotFoundException("The given JSON configuration file was not found.");
            }

            var json = JObject.Parse(File.ReadAllText(jsonPath));
            // todo parse it
        }
    }
}
