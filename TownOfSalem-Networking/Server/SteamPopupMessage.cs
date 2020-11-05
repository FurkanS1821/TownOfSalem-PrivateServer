using System;

namespace TownOfSalem_Networking.Server
{
    [Obsolete("This message is no longer used, deprecated on server.")]
    public class SteamPopupMessage : BaseMessage
    {
        public SteamPopupMessage() : base(MessageType.SteamLoginAccountLinked)
        {
        }
    }
}