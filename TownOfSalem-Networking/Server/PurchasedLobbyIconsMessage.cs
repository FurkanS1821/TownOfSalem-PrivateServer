using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class PurchasedLobbyIconsMessage : BaseMessage
    {
        public readonly List<int> LobbyIcons;

        public PurchasedLobbyIconsMessage(List<int> lobbyIcons) : base(MessageType.PurchasedLobbyIcons)
        {
            LobbyIcons = lobbyIcons;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(string.Join(",", LobbyIcons)));
        }
    }
}