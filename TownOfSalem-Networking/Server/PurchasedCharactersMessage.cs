using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class PurchasedCharactersMessage : BaseMessage
    {
        public int[] Characters;

        public PurchasedCharactersMessage(int[] characters) : base(MessageType.PurchasedCharacters)
        {
            Characters = characters;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            for (var i = 0; i < Characters.Length; i++)
            {
                writer.Write(Encoding.UTF8.GetBytes(Characters[i].ToString()));

                if (i < Characters.Length - 1)
                {
                    writer.Write(',');
                }
            }
        }
    }
}
