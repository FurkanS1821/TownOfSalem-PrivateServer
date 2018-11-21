using System;

namespace TownOfSalem_Networking.Server
{
    public class HowManyPlayersAndGamesMessage : BaseMessage
    {
        public readonly int PlayerCount;
        public readonly int GameCount;

        public HowManyPlayersAndGamesMessage(byte[] data) : base(data)
        {
            try
            {
                var strArray = BytesToString(data, 1).Split('*');
                PlayerCount = int.Parse(strArray[0]);
                GameCount = int.Parse(strArray[1]);
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
