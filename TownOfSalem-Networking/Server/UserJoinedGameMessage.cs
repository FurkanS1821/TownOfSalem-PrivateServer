using System;

namespace TownOfSalem_Networking.Server
{
    public class UserJoinedGameMessage : BaseMessage
    {
        public readonly bool IsHost;
        public readonly bool IsMe;
        public readonly string Username;
        public readonly int LobbyPosition;
        public readonly int LobbyIconId;

        public UserJoinedGameMessage(byte[] data) : base(data)
        {
            try
            {
                var strArray = BytesToString(data, 3).Split('*');
                IsHost = GetBoolValue(data[1]);
                IsMe = !GetBoolValue(data[2]);
                Username = strArray[0];
                LobbyPosition = strArray[1][0] - 1;
                LobbyIconId = strArray[1][1] - 1;
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
