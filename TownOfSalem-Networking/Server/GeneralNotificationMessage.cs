using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class GeneralNotificationMessage : BaseMessage
    {
        public readonly int PopupType;
        public readonly int MessageCode;
        public readonly string DirectMessage;

        public GeneralNotificationMessage(int popupType, int messageCode, string directMessage)
            : base(MessageType.GeneralNotification)
        {
            PopupType = popupType;
            MessageCode = messageCode;
            DirectMessage = directMessage;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)PopupType);
            writer.Write((byte)MessageCode);
            writer.Write(Encoding.UTF8.GetBytes(DirectMessage)); // Optional only if MessageCode == 1
        }
    }
}