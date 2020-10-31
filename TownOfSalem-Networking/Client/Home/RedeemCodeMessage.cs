using System;

namespace TownOfSalem_Networking.Client.Home
{
    public class RedeemCodeMessage : BaseMessage
    {
        public string RedeemCode;

        public RedeemCodeMessage(byte[] data) : base(data)
        {
            try
            {
                RedeemCode = BytesToString(data, 1);
            }
            catch (Exception e)
            {
                ThrowNetworkMessageFormatException(e);
            }
        }
    }
}