using System.IO;

namespace TownOfSalem_Networking.Client.Home
{
    public class JoinGameMessage : BaseMessage
    {
        public int GameMode;

        public JoinGameMessage(int gameMode) : base(MessageType.JoinGame)
        {
            GameMode = gameMode;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)GameMode);
        }
    }
}
