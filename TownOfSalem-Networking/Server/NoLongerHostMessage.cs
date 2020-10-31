namespace TownOfSalem_Networking.Server
{
    public class NoLongerHostMessage : BaseMessage
    {
        public NoLongerHostMessage() : base(MessageType.NoLongerHost)
        {
        }
    }
}