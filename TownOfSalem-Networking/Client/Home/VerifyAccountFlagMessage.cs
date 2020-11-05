using System;

namespace TownOfSalem_Networking.Client.Home
{
    public class VerifyAccountFlagMessage : BaseMessage
    {
        public int Flag;

        public VerifyAccountFlagMessage(byte[] data) : base(data)
        {
            try
            {
                Flag = data[1];
            }
            catch (Exception e)
            {
                ThrowNetworkMessageFormatException(e);
            }
        }
    }
}