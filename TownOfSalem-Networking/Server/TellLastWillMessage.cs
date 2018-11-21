using System;

namespace TownOfSalem_Networking.Server
{
    public class TellLastWillMessage : BaseMessage
    {
        public readonly int Position;
        public readonly bool HasLastWill;
        public readonly string WillText;

        public TellLastWillMessage(byte[] data) : base(data)
        {
            try
            {
                Position = data[1] - 1;
                HasLastWill = GetBoolValue(data[2]);
                if (!HasLastWill) return;
                WillText = BytesToString(data, 3).Replace('\r', '\n');
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
