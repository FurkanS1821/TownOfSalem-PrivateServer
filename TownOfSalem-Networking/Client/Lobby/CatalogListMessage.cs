using System.IO;

namespace TownOfSalem_Networking.Client.Lobby
{
    public class CatalogListMessage : BaseMessage
    {
        public int CatalogIndex;

        public CatalogListMessage(int catalogIndex) : base(MessageType.CatalogList)
        {
            CatalogIndex = catalogIndex;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)CatalogIndex);
        }
    }
}
