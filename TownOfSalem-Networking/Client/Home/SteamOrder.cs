using System;

namespace TownOfSalem_Networking.Client.Home
{
    [Obsolete("Please use PurchaseProduct instead.")]
    public class SteamOrder : BaseMessage
    {
        public int ProductId;
        public string SteamId;

        [Obsolete("Please use PurchaseProduct instead.", true)]
        public SteamOrder(byte[] data) : base(data)
        {
            try
            {
                ProductId = data[1];
                SteamId = BytesToString(data, 2);
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
