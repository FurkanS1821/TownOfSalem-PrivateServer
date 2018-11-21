namespace TownOfSalem_Networking
{
    public class RoleLotInfo
    {
        public int RoleId;
        public int TotalLots;
        public int Lots;

        public RoleLotInfo(int roleId, int totalLots, int lots)
        {
            RoleId = roleId;
            TotalLots = totalLots;
            Lots = lots;
        }
    }
}
