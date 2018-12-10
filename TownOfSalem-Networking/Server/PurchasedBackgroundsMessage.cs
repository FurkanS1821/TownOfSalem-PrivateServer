using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class PurchasedBackgroundsMessage : BaseMessage
    {
        public int[] Backgrounds;

        public PurchasedBackgroundsMessage(int[] backgrounds) : base(MessageType.PurchasedBackgrounds)
        {
            Backgrounds = backgrounds;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            for (var i = 0; i < Backgrounds.Length; i++)
            {
                writer.Write(Encoding.UTF8.GetBytes(Backgrounds[i].ToString()));

                if (i < Backgrounds.Length - 1)
                {
                    writer.Write(',');
                }
            }
        }
    }
}
