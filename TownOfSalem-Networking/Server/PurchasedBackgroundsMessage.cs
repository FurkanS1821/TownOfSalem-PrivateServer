using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class PurchasedBackgroundsMessage : BaseMessage
    {
        public List<int> Backgrounds;

        public PurchasedBackgroundsMessage(List<int> backgrounds) : base(MessageType.PurchasedBackgrounds)
        {
            Backgrounds = backgrounds;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(string.Join(",", Backgrounds)));
        }
    }
}