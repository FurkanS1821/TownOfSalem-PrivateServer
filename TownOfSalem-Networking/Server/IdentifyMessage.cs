using System;

namespace TownOfSalem_Networking.Server
{
    public class IdentifyMessage : BaseMessage
    {
        public readonly string Message;

        public IdentifyMessage(byte[] data) : base(data)
        {
            try
            {
                Message = BytesToString(data, 1);
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
