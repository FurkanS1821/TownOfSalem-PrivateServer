using System;

namespace TownOfSalem_Networking.Server
{
    public class SystemMessage : BaseMessage
    {
        public readonly string Message;

        public SystemMessage(byte[] data) : base(data)
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
