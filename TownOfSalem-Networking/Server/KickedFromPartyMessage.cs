namespace TownOfSalem_Networking.Server
{
    public class KickedFromPartyMessage : BaseMessage
    {
        public KickedFromPartyMessage() : base(MessageType.KickedMeFromParty)
        {
        }
    }
}