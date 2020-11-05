using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class DaysLeftToFindTraitorMessage : BaseMessage
    {
        public readonly int DaysLeft;

        public DaysLeftToFindTraitorMessage(int daysLeft) : base(MessageType.DaysLeftToFindTraitor)
        {
            DaysLeft = daysLeft;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)DaysLeft);
        }
    }
}