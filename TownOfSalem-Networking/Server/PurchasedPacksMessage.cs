using System;
using System.Collections.Generic;

namespace TownOfSalem_Networking.Server
{
    public class PurchasedPacksMessage : BaseMessage
    {
        public readonly List<int> Packs = new List<int>();

        public PurchasedPacksMessage(byte[] data) : base(data)
        {
            try
            {
                var str = BytesToString(data, 1);
                foreach (var s in str.Split(','))
                {
                    Packs.Add(int.Parse(s));
                }
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
