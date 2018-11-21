using System;
using System.Collections.Generic;

namespace TownOfSalem_Networking.Server
{
    public class PurchasedPetsMessage : BaseMessage
    {
        public List<int> Pets = new List<int>();

        public PurchasedPetsMessage(byte[] data) : base(data)
        {
            try
            {
                var str = BytesToString(data, 1);
                foreach (var s in str.Split(','))
                {
                    Pets.Add(int.Parse(s));
                }
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
