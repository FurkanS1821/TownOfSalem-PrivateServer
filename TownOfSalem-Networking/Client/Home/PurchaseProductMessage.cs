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
                var packet = BytesToString(data, 1).Split(',');
                ProductId = packet[0];
                Quantity = Convert.ToInt32(packet[1]);
            }
            catch (Exception e)
            {
                ThrowNetworkMessageFormatException(e);
            }
        }
    }
}