using System.IO;

namespace TownOfSalem_Networking.Client.Game
{
    public class PirateDuelSelectionMessage : BaseMessage
    {
        public int Selection;

        public PirateDuelSelectionMessage(int selection) : base(MessageType.PirateDuelSelection)
        {
            Selection = selection;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)Selection);
        }
    }
}
