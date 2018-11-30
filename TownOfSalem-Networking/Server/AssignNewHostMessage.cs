using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class AssignNewHostMessage : BaseMessage
    {
        public readonly int NewHostPosition;

        public AssignNewHostMessage(int newHostPosition) : base(MessageType.AssignNewHost)
        {
            NewHostPosition = newHostPosition;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(NewHostPosition + 1));
        }
    }
}
