using System;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class CreateLobbyMessage : BaseMessage
    {
        public readonly bool IsHost;
        public readonly int GameModeId;

        public CreateLobbyMessage(byte[] data) : base(data)
        {
            try
            {
                var bytes = Encoding.ASCII.GetBytes(BytesToString(data, 1));
                IsHost = GetBoolValue(bytes[0]);
                GameModeId = bytes[1];
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
