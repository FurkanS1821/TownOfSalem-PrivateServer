using System;

namespace TownOfSalem_Networking.Server
{
    public class SelectionSettingsMessage : BaseMessage
    {
        public UserSelections Selections;

        public SelectionSettingsMessage(byte[] data) : base(data)
        {
            try
            {
                var strArray = BytesToString(data, 1).Split(',');
                Selections = new UserSelections();
                int.TryParse(strArray[0], out Selections.Character);
                int.TryParse(strArray[1], out Selections.House);
                int.TryParse(strArray[2], out Selections.Background);
                int.TryParse(strArray[3], out Selections.Pet);
                int.TryParse(strArray[4], out Selections.LobbyIcon);
                int.TryParse(strArray[5], out Selections.DeathAnimation);
                Selections.Scrolls[0] = int.Parse(strArray[6]);
                Selections.Scrolls[1] = int.Parse(strArray[7]);
                Selections.Scrolls[2] = int.Parse(strArray[8]);
                Selections.InGameName = strArray[9];
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
