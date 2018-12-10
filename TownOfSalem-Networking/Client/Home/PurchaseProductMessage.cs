using System;

namespace TownOfSalem_Networking.Client.Home
{
    public class PurchaseProductMessage : BaseMessage
    {
        public string ProductId;
        public int Quantity;

        public PurchaseProductMessage(byte[] data) : base(data)
        {
            try
            {
                var lines = BytesToString(data, 1).Split(',');
                ProductId = lines[0];
                Quantity = Convert.ToInt32(lines[1]);
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
