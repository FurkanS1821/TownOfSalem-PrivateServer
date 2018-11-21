using System;

namespace TownOfSalem_Networking.Server
{
    public class AddVampireMessage : BaseMessage
    {
        public readonly int Position;
        public readonly bool IsYoungest;

        public AddVampireMessage(byte[] data) : base(data)
        {
            try
            {
                Position = data[1] - 1;
                IsYoungest = GetBoolValue(Convert.ToByte(data[2]));
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
