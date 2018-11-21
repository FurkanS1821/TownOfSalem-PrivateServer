using System;

namespace TownOfSalem_Networking.Server
{
    public class PayPalSaleFailedMessage : BaseMessage
    {
        public readonly string Message;

        public PayPalSaleFailedMessage(byte[] data) : base(data)
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
