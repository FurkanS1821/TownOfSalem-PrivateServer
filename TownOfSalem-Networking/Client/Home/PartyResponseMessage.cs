using System;
using TownOfSalem_Networking.Enums;

namespace TownOfSalem_Networking.Client.Home
{
    public class PartyResponseMessage : BaseMessage
    {
        public PartyResponse Response;
        public int PartyId;

        public PartyResponseMessage(byte[] data) : base(data)
        {
            try
            {
                Response = (PartyResponse)data[1];
                PartyId = Convert.ToInt32(BytesToString(data, 2));
            }
            catch (Exception e)
            {
                ThrowNetworkMessageFormatException(e);
            }
        }
    }
}