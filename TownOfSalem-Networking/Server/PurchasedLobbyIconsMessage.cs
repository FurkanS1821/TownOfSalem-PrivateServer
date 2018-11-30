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
            for (var i = 0; i < LobbyIcons.Count; i++)
            {
                writer.Write(Encoding.UTF8.GetBytes(LobbyIcons[i].ToString()));

                if (i < LobbyIcons.Count - 1)
                {
                    writer.Write(',');
                }
            }
        }
    }
}
