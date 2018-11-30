using System;

namespace TownOfSalem_Networking.Client.Lobby
{
    public class CatalogListMessage : BaseMessage
    {
        public int CatalogIndex;

        public CatalogListMessage(byte[] data) : base(data)
        {
            try
            {
                CatalogIndex = data[1];
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
