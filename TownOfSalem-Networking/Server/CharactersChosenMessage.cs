using System.Collections.Generic;
using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class CharactersChosenMessage : BaseMessage
    {
        public readonly Dictionary<int, int> Characters;

        public CharactersChosenMessage(Dictionary<int, int> characters) : base(MessageType.CharactersChosen)
        {
            Characters = characters;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            foreach (var character in Characters)
            {
                writer.Write((byte)(character.Key + 1));
                writer.Write((byte)(character.Value + 1));
            }
        }
    }
}