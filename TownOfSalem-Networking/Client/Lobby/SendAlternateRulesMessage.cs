using System;
using TownOfSalem_Networking.Enums;

namespace TownOfSalem_Networking.Client.Lobby
{
    public class SendAlternateRulesMessage : BaseMessage
    {
        public GameOptionEnum Setting;
        public int Flag;

        public SendAlternateRulesMessage(byte[] data) : base(data)
        {
            try
            {
                Setting = (GameOptionEnum)(data[1] - 1);
                Flag = data[2] - 1;
            }
            catch (Exception e)
            {
                ThrowNetworkMessageFormatException(e);
            }
        }
    }
}