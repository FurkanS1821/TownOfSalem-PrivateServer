using System;

namespace TownOfSalem_Networking.Server
{
    public class NamesAndPositionsMessage : BaseMessage
    {
        public readonly int Position;
        public readonly string PlayerName;

        public NamesAndPositionsMessage(byte[] data) : base(data)
        {
            try
            {
                Position = data[1] - 1;
                PlayerName = BytesToString(data, 2);
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
