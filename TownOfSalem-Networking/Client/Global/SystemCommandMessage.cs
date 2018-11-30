using System;

namespace TownOfSalem_Networking.Client.Global
{
    public class SystemCommandMessage : BaseMessage
    {
        public int Command;
        public byte[] Arguments;

        public SystemCommandMessage(byte[] data) : base(data)
        {
            try
            {
                Command = data[1];
                Arguments = new byte[data.Length - 2];
                Array.Copy(data, 2, Arguments, 0, data.Length - 2);
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
