namespace TownOfSalem_Networking.Client.Home
{
    public class RankedQueueAcceptMessage : BaseMessage
    {
        public RankedQueueAcceptMessage()
            : base(MessageType.RankedQueueAccept)
        {
        }
    }
}
