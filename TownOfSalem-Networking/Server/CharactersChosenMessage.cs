using System;
using System.Collections.Generic;

namespace TownOfSalem_Networking.Server
{
    public class CharactersChosenMessage : BaseMessage
    {
        public readonly Dictionary<int, int> Characters = new Dictionary<int, int>();

        public CharactersChosenMessage(byte[] data) : base(data)
        {
            try
            {
                var index = 1;
                while (index < data.Length)
                {
                    Characters.Add(data[index] - 1, data[index + 1] - 1);
                    index += 2;
                }
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
