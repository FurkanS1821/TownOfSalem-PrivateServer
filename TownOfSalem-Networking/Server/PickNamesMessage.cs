using System;

namespace TownOfSalem_Networking.Server
{
    public class PickNamesMessage : BaseMessage
    {
        public readonly int PlayerCount;
        public readonly int GameMode;

        public PickNamesMessage(byte[] data) : base(data)
        {
            try
            {
                PlayerCount = data[1] - 1;
                GameMode = data[2] - 1;
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
