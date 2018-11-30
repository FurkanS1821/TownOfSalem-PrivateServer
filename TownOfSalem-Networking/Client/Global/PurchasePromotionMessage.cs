using System;

namespace TownOfSalem_Networking.Client.Global
{
    public class PurchasePromotionMessage : BaseMessage
    {
        public int PromotionInstanceId;

        public PurchasePromotionMessage(byte[] data) : base(data)
        {
            try
            {
                PromotionInstanceId = Convert.ToInt32(BytesToString(data, 1));
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
