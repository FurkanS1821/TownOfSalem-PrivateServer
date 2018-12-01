namespace TownOfSalem_Networking.Structs
{
    public class PartyInvite
    {
        public string HostUsername = string.Empty;
        public int PartyId;
        public bool IsValid;

        public PartyInvite()
        {
        }

        public PartyInvite(int partyId, string hostUsername)
        {
            PartyId = partyId;
            HostUsername = hostUsername;
            IsValid = true;
        }
    }
}
