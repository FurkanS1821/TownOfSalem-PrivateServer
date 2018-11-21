using System;

namespace TownOfSalem_Networking.Server
{
    public class PirateDuelOutcomeMessage : BaseMessage
    {
        public readonly PirateDuelAttack Attack;
        public readonly PirateDuelDefense Defense;

        public PirateDuelOutcomeMessage(byte[] data) : base(data)
        {
            try
            {
                Attack = (PirateDuelAttack)data[1];
                Defense = (PirateDuelDefense)data[2];
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
