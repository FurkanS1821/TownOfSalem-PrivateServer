using System.IO;
using TownOfSalem_Networking.Enums;

namespace TownOfSalem_Networking.Server
{
    public class HostSetPartyConfigsMessage : BaseMessage
    {
        public readonly GameBrand Brand;
        public readonly GameMode GameMode;
        public readonly PartyConfigChangeResult Result;

        public HostSetPartyConfigsMessage(GameBrand brand, GameMode gameMode, PartyConfigChangeResult result) : base(MessageType.HostSetPartyConfigs)
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

        public enum PartyConfigChangeResult
        {
            Okay = 0,
            SomeoneLacksCoven = 1,
            InvalidGameMode = 2
        }
    }
}
