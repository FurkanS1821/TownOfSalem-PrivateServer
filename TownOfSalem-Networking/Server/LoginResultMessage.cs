using System;

namespace TownOfSalem_Networking.Server
{
    public class LoginResultMessage : BaseMessage
    {
        public LoginStatus Status;

        public LoginResultMessage(byte[] data) : base(data)
        {
            try
            {
                Status = (LoginStatus)(data[1] - 1);
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
