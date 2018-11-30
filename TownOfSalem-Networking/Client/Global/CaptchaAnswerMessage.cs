using System;

namespace TownOfSalem_Networking.Client.Global
{
    public class CaptchaAnswerMessage : BaseMessage
    {
        public string Answer;

        public CaptchaAnswerMessage(byte[] data) : base(data)
        {
            try
            {
                Answer = BytesToString(data, 1);
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
