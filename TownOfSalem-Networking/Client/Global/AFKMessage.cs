using System;

namespace TownOfSalem_Networking.Client.Global
{
    public class AFKMessage : BaseMessage
    {
        public AFKStatus Status;

        public AFKMessage(byte[] data) : base(data)
        {
            try
            {
                Status = (AFKStatus)data[1];
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
