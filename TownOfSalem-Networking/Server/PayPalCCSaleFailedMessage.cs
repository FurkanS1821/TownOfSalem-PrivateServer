using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class PayPalCCSaleFailedMessage : BaseMessage
    {
        public readonly string Message;

        public PayPalCCSaleFailedMessage(string message) : base(MessageType._UNUSED_PaypalCCSaleFailed)
        {
            Message = message;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(Message));
        }
    }
}
