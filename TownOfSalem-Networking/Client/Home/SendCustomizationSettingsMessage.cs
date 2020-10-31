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
                var lines = BytesToString(data, 1).Split(',');
                Selections = new UserSelections
                {
                    Character = Convert.ToInt32(lines[0]),
                    House = Convert.ToInt32(lines[1]),
                    Background = Convert.ToInt32(lines[2]),
                    Pet = Convert.ToInt32(lines[3]),
                    LobbyIcon = Convert.ToInt32(lines[4]),
                    DeathAnimation = Convert.ToInt32(lines[5]),
                    InGameName = lines[9]
                };

                for (var i = 0; i < 3; i++)
                {
                    Selections.Scrolls[i] = Convert.ToInt32(lines[6 + i]);
                }
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
