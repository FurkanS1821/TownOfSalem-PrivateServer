namespace TownOfSalem_Networking.Client.Game
{
    public class VoteGuiltyMessage : BaseMessage
    {
        public VoteGuiltyMessage()
            : base(MessageType.VoteGuilty)
        {
        }
    }
}
