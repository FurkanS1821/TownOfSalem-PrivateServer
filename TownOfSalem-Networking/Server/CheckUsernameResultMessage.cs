using System;

namespace TownOfSalem_Networking.Server
{
    public class CheckUsernameResultMessage : BaseMessage
    {
        public readonly bool IsAvailable;
        private const byte NAME_AVAILABLE = 1;
        private const byte NAME_UNAVAILABLE = 2;

        public CheckUsernameResultMessage(byte[] data) : base(data)
        {
            try
            {
                IsAvailable = Convert.ToByte(data[1]) == 1;
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
