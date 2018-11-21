using System;

namespace TownOfSalem_Networking.Server
{
    public class JuggernautKillsMessage : BaseMessage
    {
        public readonly int Kills;

        public JuggernautKillsMessage(byte[] data) : base(data)
        {
            try
            {
                Kills = data[1] - 1;
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
