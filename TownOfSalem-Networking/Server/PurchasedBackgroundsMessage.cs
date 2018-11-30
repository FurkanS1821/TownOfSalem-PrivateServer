using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class PurchasedBackgroundsMessage : BaseMessage
    {
        public List<int> Backgrounds = new List<int>();

        public PurchasedBackgroundsMessage(List<int> backgrounds) : base(MessageType.PurchasedBackgrounds)
        {
            Backgrounds = backgrounds;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            for (var i = 0; i < Backgrounds.Count; i++)
            {
                writer.Write(Encoding.UTF8.GetBytes(Backgrounds[i].ToString()));

                if (i < Backgrounds.Count - 1)
                {
                    writer.Write(',');
                }
            }
        }
    }
}
