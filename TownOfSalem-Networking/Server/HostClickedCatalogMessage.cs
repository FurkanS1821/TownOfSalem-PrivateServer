using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class HostClickedCatalogMessage : BaseMessage
    {
        public readonly int Selected;

        public HostClickedCatalogMessage(int selected) : base(MessageType.HostClickedCatalog)
        {
            Selected = selected;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)Selected);
        }
    }
}
