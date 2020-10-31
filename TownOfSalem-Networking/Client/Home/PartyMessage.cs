using System;

namespace TownOfSalem_Networking.Client.Home
{
    public class PartyMessage : BaseMessage
    {
        public string Message;

        public PartyMessage(byte[] data) : base(data)
        {
            try
            {
                Message = BytesToString(data, 1);
            }
            catch (Exception e)
            {
                ThrowNetworkMessageFormatException(e);
            }
        }
    }
}