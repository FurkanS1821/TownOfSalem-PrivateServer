using System;

namespace TownOfSalem_Networking.Server
{
    public class CaptchaResult : BaseMessage
    {
        public readonly bool Status;

        public CaptchaResult(byte[] data) : base(data)
        {
            try
            {
                Status = GetBoolValue(data[1]);
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
