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
            writer.Write(Encoding.UTF8.GetBytes(Selections.Character.ToString()));
            writer.Write(',');
            writer.Write(Encoding.UTF8.GetBytes(Selections.House.ToString()));
            writer.Write(',');
            writer.Write(Encoding.UTF8.GetBytes(Selections.Background.ToString()));
            writer.Write(',');
            writer.Write(Encoding.UTF8.GetBytes(Selections.Pet.ToString()));
            writer.Write(',');
            writer.Write(Encoding.UTF8.GetBytes(Selections.LobbyIcon.ToString()));
            writer.Write(',');
            writer.Write(Encoding.UTF8.GetBytes(Selections.DeathAnimation.ToString()));
            writer.Write(',');

            for (var i = 0; i < 3; i++)
            {
                writer.Write(Encoding.UTF8.GetBytes(Selections.Scrolls[i].ToString()));
                writer.Write(',');
            }

            writer.Write(Encoding.UTF8.GetBytes(Selections.InGameName));
        }
    }
}
