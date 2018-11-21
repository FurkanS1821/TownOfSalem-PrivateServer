using System;

namespace TownOfSalem_Networking.Server
{
    public class ResurrectionMessage : BaseMessage
    {
        public readonly int Position;
        public readonly int Role;

        public ResurrectionMessage(byte[] data) : base(data)
        {
            try
            {
                Position = data[1] - 1;
                Role = data[2] - 1;
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
