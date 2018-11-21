using System;
using System.Collections.Generic;

namespace TownOfSalem_Networking.Server
{
    public class PurchasedCharactersMessage : BaseMessage
    {
        public List<int> Characters = new List<int>();

        public PurchasedCharactersMessage(byte[] data) : base(data)
        {
            try
            {
                var str = BytesToString(data, 1);
                foreach (var s in str.Split(','))
                {
                    Characters.Add(int.Parse(s));
                }
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
