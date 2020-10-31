using System;

namespace TownOfSalem_Networking.Client.Home
{
    public class JoinGameMessage : BaseMessage
    {
        public int GameMode;

        public JoinGameMessage(byte[] data) : base(data)
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