using System;

namespace TownOfSalem_Networking.Server
{
    public class CreatePartyLobbyMessage : BaseMessage
    {
        public int LobbyType;

        public CreatePartyLobbyMessage(byte[] data) : base(data)
        {
            try
            {
                LobbyType = data[1];
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
