using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class PurchasedLobbyIconsMessage : BaseMessage
    {
        public readonly int[] LobbyIcons;

        public PurchasedLobbyIconsMessage(int[] lobbyIcons) : base(MessageType.PurchasedLobbyIcons)
        {
            LobbyIcons = lobbyIcons;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            for (var i = 0; i < LobbyIcons.Length; i++)
            {
                writer.Write(Encoding.UTF8.GetBytes(LobbyIcons[i].ToString()));

                if (i < LobbyIcons.Length - 1)
                {
                    writer.Write(',');
                }
            }
        }
    }
}
