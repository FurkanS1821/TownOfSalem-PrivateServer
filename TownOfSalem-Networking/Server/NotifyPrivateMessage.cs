using System;

namespace TownOfSalem_Networking.Server
{
    public class NotifyPrivateMessage : BaseMessage
    {
        public readonly int FromPosition;
        public readonly int ToPosition;

        public NotifyPrivateMessage(byte[] data) : base(data)
        {
            try
            {
                FromPosition = data[1] - 1;
                ToPosition = data[2] - 1;
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
