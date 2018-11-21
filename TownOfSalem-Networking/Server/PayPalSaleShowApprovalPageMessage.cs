using System;

namespace TownOfSalem_Networking.Server
{
    public class PayPalSaleShowApprovalPageMessage : BaseMessage
    {
        public readonly string Url;

        public PayPalSaleShowApprovalPageMessage(byte[] data) : base(data)
        {
            try
            {
                Url = BytesToString(data, 1);
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
