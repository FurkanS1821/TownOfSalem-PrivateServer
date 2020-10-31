using System.Collections.Generic;
using System.Linq;
using TownOfSalem_Logic.Enums;

namespace TownOfSalem_Logic
{
    public class Game
    {
        public GamePhase Phase;
        public Dictionary<TOSNetworkService, PlayerData> Players = new Dictionary<TOSNetworkService, PlayerData>();
        public Role[] RoleList;

        public Game(TOSNetworkService[] clients, Role[] roleList)
        {
            RoleList = roleList;
            foreach (var client in clients)
            {
                Players.Add(client, new PlayerData());
            }

            AssignRandomPositionsToPlayers();
        }

        public void AssignRandomPositionsToPlayers()
        {
            var placesLeft = Enumerable.Range(1, Players.Count).ToList();
            foreach (var player in Players)
            {
                var randomIndex = Utility.Random.Next(0, placesLeft.Count);
                player.Value.Position = placesLeft[randomIndex];
                placesLeft.RemoveAt(randomIndex);
            }
        }
    }

    public class PlayerData
    {
        public string UserName;
        public int Position;
        public Role Role;
        public Role RoleOverride;
        public string Will;
        public string DeathNote;
        public string Forgery;
        public bool IsDoused;
        public bool IsHexed;
        public bool IsFramed;
    }
}
