using System;

namespace TownOfSalem_Networking.Client.Lobby
{
    public class PartyStartMessage : BaseMessage
    {
        public int GameMode;

        public PartyStartMessage(byte[] data) : base(data)
        {
            try
            {
                GameMode = data[1];
            }
            catch (Exception e)
            {
                ThrowNetworkMessageFormatException(e);
            }
        }
    }
}