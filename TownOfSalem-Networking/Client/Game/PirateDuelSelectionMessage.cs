using System;

namespace TownOfSalem_Networking.Client.Game
{
    public class PirateDuelSelectionMessage : BaseMessage
    {
        public int Selection;

        public PirateDuelSelectionMessage(byte[] data) : base(data)
        {
            try
            {
                Selection = data[1];
            }
            catch (Exception e)
            {
                ThrowNetworkMessageFormatException(e);
            }
        }
    }
}