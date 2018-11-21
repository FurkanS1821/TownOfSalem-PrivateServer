using System.IO;

namespace TownOfSalem_Networking.Client.Home
{
    public class RequestRankedGameMessage : BaseMessage
    {
        public int GameMode;

        public RequestRankedGameMessage(int mode) : base(MessageType.RequestRankedGame)
        {
            GameMode = mode;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)GameMode);
        }
    }
}
