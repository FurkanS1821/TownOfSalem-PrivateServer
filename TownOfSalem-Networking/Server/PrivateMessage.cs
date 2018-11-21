using System;

namespace TownOfSalem_Networking.Server
{
    public class PrivateMessage : BaseMessage
    {
        public readonly int SourceType;
        public readonly int Position;
        public readonly int Position2;
        public readonly string Message;

        public PrivateMessage(byte[] data) : base(data)
        {
            try
            {
                SourceType = data[1];
                Position = data[2] - 1;
                if (SourceType == 3)
                {
                    Position2 = data[3] - 1;
                    Message = BytesToString(data, 4);
                }
                else
                {
                    Message = BytesToString(data, 3);
                }
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
