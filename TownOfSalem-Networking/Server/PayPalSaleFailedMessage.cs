using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class PayPalSaleFailedMessage : BaseMessage
    {
        public readonly string Message;

        public PayPalSaleFailedMessage(string message) : base(MessageType._UNUSED_PayPalSaleFailed)
        {
            Message = message;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(Message));
        }
    }
}
