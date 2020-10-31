using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class PickNamesMessage : BaseMessage
    {
        public readonly int PlayerCount;
        public readonly int GameMode;

        public PickNamesMessage(int playerCount, int gameMode) : base(MessageType.PickNames)
        {
            PlayerCount = playerCount;
            GameMode = gameMode;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(PlayerCount + 1));
            writer.Write((byte)(GameMode + 1));
        }
    }
}