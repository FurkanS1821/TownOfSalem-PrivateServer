using System;

namespace TownOfSalem_Networking.Server
{
    public class AfterGameScreenChatMessage : BaseMessage
    {
        public readonly int Position;
        public readonly string Message;

        public AfterGameScreenChatMessage(byte[] data) : base(data)
        {
            try
            {
                Position = Convert.ToInt32(data[1]) - 1;
                Message = BytesToString(data, 2);
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
