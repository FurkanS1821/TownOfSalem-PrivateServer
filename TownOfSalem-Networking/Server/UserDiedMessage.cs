namespace TownOfSalem_Networking.Server
{
    public class UserDiedMessage : BaseMessage
    {
        public UserDiedMessage() : base(MessageType.UserDied)
        {
        }
    }
}