using System;

namespace TownOfSalem_Networking.Server
{
    public class PayPalCCSaleFailedMessage : BaseMessage
    {
        public readonly string Message;

        public PayPalCCSaleFailedMessage(byte[] data) : base(data)
        {
            try
            {
                Message = BytesToString(data, 1);
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
