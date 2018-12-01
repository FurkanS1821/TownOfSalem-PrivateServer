using System.IO;
using TownOfSalem_Networking.Enums;

namespace TownOfSalem_Networking.Server
{
    public class TrapperTrapReadyMessage : BaseMessage
    {
        public readonly TrapStatus Status;

        public TrapperTrapReadyMessage(TrapStatus status) : base(MessageType.TrapperTrapReady)
        {
            Status = status;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)Status);
        }
    }
}
