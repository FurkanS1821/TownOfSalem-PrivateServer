namespace TownOfSalem_Networking.Server
{
    public class SteamFirstLoginMessage : BaseMessage
    {
        public SteamFirstLoginMessage() : base(MessageType.SteamFirstLogin)
        {
        }
    }
}
