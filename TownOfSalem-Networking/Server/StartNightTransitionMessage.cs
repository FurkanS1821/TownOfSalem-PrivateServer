namespace TownOfSalem_Networking.Server
{
    public class StartNightTransitionMessage : BaseMessage
    {
        public StartNightTransitionMessage() : base(MessageType.StartNightTransition)
        {
        }
    }
}