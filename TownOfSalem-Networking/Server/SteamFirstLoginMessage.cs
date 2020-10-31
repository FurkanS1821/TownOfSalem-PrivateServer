using System;

namespace TownOfSalem_Networking.Server
{
    [Obsolete("This message is no longer used by the client, although it still gets sent by the server.")]
    public class SteamFirstLoginMessage : BaseMessage
    {
        public SteamFirstLoginMessage() : base(MessageType.SteamFirstLogin)
        {
        }
    }
}