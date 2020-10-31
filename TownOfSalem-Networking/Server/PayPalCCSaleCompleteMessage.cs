using System;

namespace TownOfSalem_Networking.Server
{
    [Obsolete("This message is no longer used as we don't use PayPal anymore.")]
    public class PayPalCCSaleCompleteMessage : BaseMessage
    {
        public PayPalCCSaleCompleteMessage() : base(MessageType._UNUSED_PayPalCCSaleComplete)
        {
        }
    }
}