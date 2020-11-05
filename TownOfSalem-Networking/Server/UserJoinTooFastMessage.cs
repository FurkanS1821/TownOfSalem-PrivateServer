namespace TownOfSalem_Networking.Server
{
    public class UserJoinTooFastMessage : BaseMessage
    {
        public UserJoinTooFastMessage() : base(MessageType.UserRejoinedLobbyTooQuickly)
        {
        }
    }
}