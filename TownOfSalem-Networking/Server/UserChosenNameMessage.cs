using System;

namespace TownOfSalem_Networking.Server
{
    public class UserChosenNameMessage : BaseMessage
    {
        public readonly int StringTableId;
        public readonly int Position;
        public readonly string PlayerName;

        public UserChosenNameMessage(byte[] data) : base(data)
        {
            try
            {
                StringTableId = data[1] - 1;
                Position = data[2] - 1;
                PlayerName = BytesToString(data, 3);
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
