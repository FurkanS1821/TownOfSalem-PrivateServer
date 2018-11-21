using System;

namespace TownOfSalem_Networking.Server
{
    public class CaptchaQuestion : BaseMessage
    {
        public readonly string Question;

        public CaptchaQuestion(byte[] data) : base(data)
        {
            try
            {
                Question = BytesToString(data, 1);
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
