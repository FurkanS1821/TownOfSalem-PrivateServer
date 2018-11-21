namespace TownOfSalem_Networking.Client.Game
{
    public class VoteInnocentMessage : BaseMessage
    {
        public VoteInnocentMessage()
            : base(MessageType.VoteInnocent)
        {
        }
    }
}
