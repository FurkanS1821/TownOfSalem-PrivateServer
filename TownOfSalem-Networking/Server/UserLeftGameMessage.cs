using System;

namespace TownOfSalem_Networking.Server
{
    public class UserLeftGameMessage : BaseMessage
    {
        public readonly bool ShouldRemoveFromLobby;
        public readonly bool ShouldUseAccountName;
        public readonly int Position;

        public UserLeftGameMessage(byte[] data) : base(data)
        {
            try
            {
                ShouldRemoveFromLobby = GetBoolValue(data[1]);
                ShouldUseAccountName = GetBoolValue(data[2]);
                Position = data[3] - 1;
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
