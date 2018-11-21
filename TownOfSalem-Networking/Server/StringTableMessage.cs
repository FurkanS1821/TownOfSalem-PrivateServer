using System;

namespace TownOfSalem_Networking.Server
{
    public class StringTableMessage : BaseMessage
    {
        public readonly int StringTableId;

        public StringTableMessage(byte[] data) : base(data)
        {
            try
            {
                StringTableId = data[1] - 1;
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
