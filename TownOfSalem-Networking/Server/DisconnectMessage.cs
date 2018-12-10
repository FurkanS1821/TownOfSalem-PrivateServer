using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class DisconnectMessage : BaseMessage
    {
        public readonly DisconnectReason Reason;

        public DisconnectMessage(DisconnectReason reason) : base(MessageType.Disconnected)
        {
            Reason = reason;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Reason + 1));
        }

        public enum DisconnectReason : byte
        {
            OldVersion = 1,
            InvalidUsernameOrPassword = 2
        }
    }
}
