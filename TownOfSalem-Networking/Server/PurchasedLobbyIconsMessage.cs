using System;
using System.Collections.Generic;

namespace TownOfSalem_Networking.Server
{
    public class PurchasedLobbyIconsMessage : BaseMessage
    {
        public readonly List<int> LobbyIcons = new List<int>();

        public PurchasedLobbyIconsMessage(byte[] data) : base(data)
        {
            try
            {
                var str = BytesToString(data, 1);
                foreach (var s in str.Split(','))
                {
                    LobbyIcons.Add(int.Parse(s));
                }
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
