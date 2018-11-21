using System;

namespace TownOfSalem_Networking.Server
{
    public class JailedTargetMessage : BaseMessage
    {
        public readonly int Position;
        public readonly bool HasExecutionsRemaining;
        public readonly bool HasKilledTown;

        public JailedTargetMessage(byte[] data) : base(data)
        {
            try
            {
                Position = Convert.ToInt32(data[1]) - 1;
                HasExecutionsRemaining = GetBoolValue(Convert.ToByte(data[2]));
                HasKilledTown = GetBoolValue(Convert.ToByte(data[3]));
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
