using System;

namespace TownOfSalem_Networking.Server
{
    public class AssignNewHostMessage : BaseMessage
    {
        public readonly int NewHostPosition;

        public AssignNewHostMessage(byte[] data) : base(data)
        {
            try
            {
                NewHostPosition = data[1] - 1;
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
