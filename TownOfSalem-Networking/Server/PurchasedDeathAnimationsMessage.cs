using System;
using System.Collections.Generic;

namespace TownOfSalem_Networking.Server
{
    public class PurchasedDeathAnimationsMessage : BaseMessage
    {
        public List<int> DeathAnimations = new List<int>();

        public PurchasedDeathAnimationsMessage(byte[] data) : base(data)
        {
            try
            {
                var str = BytesToString(data, 1);
                foreach (var s in str.Split(','))
                {
                    DeathAnimations.Add(int.Parse(s));
                }
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
