using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Client.Home
{
    public class SendCustomizationSettingsMessage : BaseMessage
    {
        public UserSelections Selections;

        public SendCustomizationSettingsMessage(UserSelections selections) : base(MessageType.SendCustomizationSettings)
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
