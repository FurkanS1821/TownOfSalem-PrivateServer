namespace TownOfSalem_Networking.Client.Lobby
{
    public class PartyLeave : BaseMessage
    {
        public PartyLeave()
            : base(MessageType.PartyLeave)
        {
        }
    }
}
