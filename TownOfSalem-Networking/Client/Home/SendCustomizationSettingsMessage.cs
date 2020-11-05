using System;
using TownOfSalem_Networking.Structs;

namespace TownOfSalem_Networking.Client.Home
{
    public class SendCustomizationSettingsMessage : BaseMessage
    {
        public UserSelections Selections;

        public SendCustomizationSettingsMessage(byte[] data) : base(data)
        {
            try
            {
                var packet = BytesToString(data, 1).Split(',');
                Selections = new UserSelections
                {
                    Character = Convert.ToInt32(packet[0]),
                    House = Convert.ToInt32(packet[1]),
                    Background = Convert.ToInt32(packet[2]),
                    Pet = Convert.ToInt32(packet[3]),
                    LobbyIcon = Convert.ToInt32(packet[4]),
                    DeathAnimation = Convert.ToInt32(packet[5]),
                    Scrolls = new[]{Convert.ToInt32(packet[6]), Convert.ToInt32(packet[7]), Convert.ToInt32(packet[8])},
                    InGameName = packet[9]
                };
            }
            catch (Exception e)
            {
                ThrowNetworkMessageFormatException(e);
            }
        }
    }
}