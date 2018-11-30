using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class PurchasedCharactersMessage : BaseMessage
    {
        public List<int> Characters;

        public PurchasedCharactersMessage(List<int> characters) : base(MessageType.PurchasedCharacters)
        {
            Characters = characters;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            for (var i = 0; i < Characters.Count; i++)
            {
                writer.Write(Encoding.UTF8.GetBytes(Characters[i].ToString()));

                if (i < Characters.Count - 1)
                {
                    writer.Write(',');
                }
            }
        }
    }
}
