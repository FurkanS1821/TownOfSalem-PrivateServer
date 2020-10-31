namespace TownOfSalem_Networking.Server
{
    public class LeavePartyMessage : BaseMessage
    {
        public LeavePartyMessage() : base(MessageType.LeaveParty)
        {
        }
    }
}