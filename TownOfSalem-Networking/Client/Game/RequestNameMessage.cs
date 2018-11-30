using System;

namespace TownOfSalem_Networking.Client.Game
{
    public class RequestNameMessage : BaseMessage
    {
        public string Name;

        public RequestNameMessage(byte[] data) : base(data)
        {
            try
            {
                Name = BytesToString(data, 1);
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
