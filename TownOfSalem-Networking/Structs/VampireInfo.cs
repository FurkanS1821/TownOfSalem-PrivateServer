namespace TownOfSalem_Networking.Structs
{
    public struct VampireInfo
    {
        public int Position;
        public bool IsYoungest;

        public VampireInfo(int position, bool isYoungest)
        {
            Position = position;
            IsYoungest = isYoungest;
        }
    }
}