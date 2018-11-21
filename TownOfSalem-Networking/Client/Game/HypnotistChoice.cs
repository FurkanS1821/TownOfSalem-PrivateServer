using System.IO;

namespace TownOfSalem_Networking.Client.Game
{
    public class HypnotistChoiceMessage : BaseMessage
    {
        public int Choice;

        public HypnotistChoiceMessage(int choice) : base(MessageType.HypnotistChoice)
        {
            Choice = choice;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Choice.ToString());
        }
    }
}
