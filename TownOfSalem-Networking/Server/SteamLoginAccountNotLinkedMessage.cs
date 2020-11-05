namespace TownOfSalem_Networking.Server
{
    public class SteamLoginAccountNotLinkedMessage : BaseMessage
    {
        public SteamLoginAccountNotLinkedMessage() : base(MessageType.SteamLoginAccountNotLinked)
        {
        }
    }
}