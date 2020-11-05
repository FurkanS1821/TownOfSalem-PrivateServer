using System.IO;
using System.Text;
using TownOfSalem_Networking.Structs;

namespace TownOfSalem_Networking.Server
{
    public class SelectionSettingsMessage : BaseMessage
    {
        public UserSelections Selections;

        public SelectionSettingsMessage(UserSelections selections) : base(MessageType.SelectionSettings)
        {
            Selections = selections;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            var data = $"{Selections.Character},{Selections.House},{Selections.Background},{Selections.Pet},";
            data += $"{Selections.LobbyIcon},{Selections.DeathAnimation},{string.Join(",", Selections.Scrolls)},";
            data += Selections.InGameName;

            writer.Write(Encoding.UTF8.GetBytes(data));
        }
    }
}