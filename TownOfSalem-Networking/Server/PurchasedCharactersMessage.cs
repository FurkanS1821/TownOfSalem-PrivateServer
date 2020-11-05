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
            writer.Write(Encoding.UTF8.GetBytes(string.Join(",", Characters)));
        }
    }
}