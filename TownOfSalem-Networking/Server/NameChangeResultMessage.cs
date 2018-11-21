using System;

namespace TownOfSalem_Networking.Server
{
    public class NameChangeResultMessage : BaseMessage
    {
        public readonly NameChangeResultCode Result;

        public NameChangeResultMessage(byte[] data) : base(data)
        {
            try
            {
                Result = (NameChangeResultCode)Convert.ToByte(data[1]);
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
