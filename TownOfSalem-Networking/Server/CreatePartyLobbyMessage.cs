using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class CreatePartyLobbyMessage : BaseMessage
    {
        public int LobbyType;

        public CreatePartyLobbyMessage(int lobbyType) : base(MessageType.CreatePartyLobby)
        {
            LobbyType = lobbyType;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)LobbyType);
        }
    }
}
