using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class UserJoinedGameMessage : BaseMessage
    {
        public readonly bool IsHost;
        public readonly bool IsMe;
        public readonly string Username;
        public readonly int LobbyPosition;
        public readonly int LobbyIconId;

        public UserJoinedGameMessage(bool isHost, bool isMe, string username, int lobbyPosition, int lobbyIconId)
            : base(MessageType.UserJoinedGame)
        {
            IsHost = isHost;
            IsMe = isMe;
            Username = username;
            LobbyPosition = lobbyPosition;
            LobbyIconId = lobbyIconId;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(IsHost ? 2 : 1));
            writer.Write((byte)(IsMe ? 2 : 1));
            writer.Write(Encoding.UTF8.GetBytes(Username));
            writer.Write('*');
            writer.Write((byte)(LobbyPosition + 1));
            writer.Write((byte)(LobbyIconId + 1));
        }
    }
}
