using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class DisconnectMessage : BaseMessage
    {
        public readonly int Reason;

        public DisconnectMessage(int reason) : base(MessageType.Disconnected)
        {
            Reason = reason;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Reason + 1));
        }
    }
}
