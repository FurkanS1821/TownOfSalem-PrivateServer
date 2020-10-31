using System.IO;
using TownOfSalem_Networking.Enums;

namespace TownOfSalem_Networking.Server
{
    public class AlternateRulesMessage : BaseMessage
    {
        public readonly GameOptionEnum Setting;
        public readonly int Flag;

        public AlternateRulesMessage(GameOptionEnum setting, int flag) : base(MessageType.AlternateGameRules)
        {
            Setting = setting;
            Flag = flag;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Setting + 1));
            writer.Write((byte)(Flag + 1));
        }
    }
}