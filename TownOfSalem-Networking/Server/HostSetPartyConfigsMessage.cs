using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class HostSetPartyConfigsMessage : BaseMessage
    {
        public readonly int Brand;
        public readonly int GameMode;
        public readonly int Result;

        public HostSetPartyConfigsMessage(int brand, int gameMode, int result) : base(MessageType.HostSetPartyConfigs)
        {
            Brand = brand;
            GameMode = gameMode;
            Result = result;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Brand + 1));
            writer.Write((byte)(GameMode + 1));
            writer.Write((byte)(Result + 1));
        }
    }
}
