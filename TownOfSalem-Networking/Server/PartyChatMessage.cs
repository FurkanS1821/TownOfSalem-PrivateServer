using System;

namespace TownOfSalem_Networking.Server
{
    public class PartyChatMessage : BaseMessage
    {
        public readonly string From;
        public readonly string Message;

        public PartyChatMessage(byte[] data) : base(data)
        {
            try
            {
                var strArray = BytesToString(data, 1).Split('*');
                From = strArray[0];
                Message = strArray[1];
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
