using System;

namespace TownOfSalem_Networking.Server
{
    public class JailorDeathNoteMessage : BaseMessage
    {
        public readonly int Position;
        public readonly bool HasLastWill;
        public readonly int Choice;

        public JailorDeathNoteMessage(byte[] data) : base(data)
        {
            try
            {
                Position = data[1] - 1;
                HasLastWill = GetBoolValue(data[2]);
                Choice = data[3] - 1;
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
