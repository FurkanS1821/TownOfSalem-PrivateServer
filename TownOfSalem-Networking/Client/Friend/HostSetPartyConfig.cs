using System.IO;

namespace TownOfSalem_Networking.Client.Friend
{
    public class HostSetPartyConfig : BaseMessage
    {
        public int Brand;
        public int GameMode;

        public HostSetPartyConfig(int brand, int gameMode) : base(MessageType.HostSetPartyConfig)
        {
            Brand = brand;
            GameMode = gameMode;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Brand + 1));
            writer.Write((byte)(GameMode + 1));
        }
    }
}
