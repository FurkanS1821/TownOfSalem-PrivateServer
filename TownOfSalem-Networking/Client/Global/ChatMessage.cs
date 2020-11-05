using System;

namespace TownOfSalem_Networking.Client.Global
{
    public class ChatMessage : BaseMessage
    {
        public string Message;

        public ChatMessage(byte[] data) : base(data)
        {
            try
            {
                Message = BytesToString(data, 1);
            }
            catch (Exception e)
            {
                ThrowNetworkMessageFormatException(e);
            }
        }
    }
}