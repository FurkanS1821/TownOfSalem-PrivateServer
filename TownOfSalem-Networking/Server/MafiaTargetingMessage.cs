using System.IO;
using TownOfSalem_Networking.Structs;

namespace TownOfSalem_Networking.Server
{
    public class MafiaTargetingMessage : BaseMessage
    {
        public readonly FactionTargetInfo TargetInfo;

        public MafiaTargetingMessage(FactionTargetInfo targetInfo) : base(MessageType.MafiaTargeting)
        {
            TargetInfo = targetInfo;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(TargetInfo.Position + 1));
            writer.Write((byte)(TargetInfo.Role + 1));
            writer.Write((byte)(TargetInfo.Target + 1));
            writer.Write((byte)TargetInfo.TargetBehavior);
            writer.Write((byte)TargetInfo.Info);
            writer.Write((byte)TargetInfo.AdditionalInfo);
        }
    }
}
