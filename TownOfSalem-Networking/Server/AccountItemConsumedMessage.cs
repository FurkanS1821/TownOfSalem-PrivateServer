using System;

namespace TownOfSalem_Networking.Server
{
    public class AccountItemConsumedMessage : BaseMessage
    {
        public readonly int AccountItemId;
        public readonly int QuantityConsumed;
        public readonly int QuantityRemaining;

        public AccountItemConsumedMessage(byte[] data) : base(data)
        {
            try
            {
                var strArray = BytesToString(data, 1).Split(',');
                AccountItemId = int.Parse(strArray[0]);
                QuantityConsumed = int.Parse(strArray[1]);
                QuantityRemaining = int.Parse(strArray[2]);
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
