namespace TownOfSalem_Networking.Structs
{
    public struct SpecialEvent
    {
        public int Type;
        public string Data;
        public int StartTime;
        public int EndTime;

        public SpecialEvent(int type, string data, int startTime, int endTime)
        {
            Type = type;
            Data = data;
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}
