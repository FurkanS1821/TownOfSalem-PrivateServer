using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class CreateLobbyMessage : BaseMessage
    {
        public readonly bool IsHost;
        public readonly int GameModeId;

        public CreateLobbyMessage(bool isHost, int gameModeId) : base(MessageType.CreateLobby)
        {
            IsHost = isHost;
            GameModeId = gameModeId;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(IsHost ? 2 : 1));
            writer.Write((byte)GameModeId);
        }
    }
}