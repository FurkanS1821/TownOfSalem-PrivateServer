using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class HostClickedPossibleRolesMessage : BaseMessage
    {
        public readonly int Selected;

        public HostClickedPossibleRolesMessage(int selected) : base(MessageType.HostClickedPossibleRoles)
        {
            Selected = selected;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)Selected);
        }
    }
}