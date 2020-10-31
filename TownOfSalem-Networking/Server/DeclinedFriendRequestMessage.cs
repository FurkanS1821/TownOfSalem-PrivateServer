namespace TownOfSalem_Networking.Server
{
    public class DeclinedFriendRequestMessage : BaseMessage
    {
        public DeclinedFriendRequestMessage() : base(MessageType.DeclinedFriendRequest)
        {
        }
    }
}