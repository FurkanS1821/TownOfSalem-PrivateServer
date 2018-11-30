using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class HostClickedRemoveMessage : BaseMessage
    {
        public readonly int Index;

        public HostClickedRemoveMessage(int index) : base(MessageType.HostClickedRemove)
        {
            Index = index;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Index + 1));
        }
    }
}
