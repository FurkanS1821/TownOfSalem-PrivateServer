using System;
using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    [Obsolete("This message is no longer used as we don't use PayPal anymore.")]
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