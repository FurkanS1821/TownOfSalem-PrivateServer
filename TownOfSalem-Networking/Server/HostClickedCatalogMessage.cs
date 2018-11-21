using System;

namespace TownOfSalem_Networking.Server
{
    public class HostClickedCatalogMessage : BaseMessage
    {
        public readonly int Selected;

        public HostClickedCatalogMessage(byte[] data) : base(data)
        {
            try
            {
                Selected = data[1];
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
