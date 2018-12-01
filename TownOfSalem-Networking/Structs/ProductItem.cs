namespace TownOfSalem_Networking.Structs
{
    public struct ProductItem
    {
        public int Type;
        public int Id;
        public int Quantity;

        public ProductItem(int type, int id, int quantity)
        {
            Type = type;
            Id = id;
            Quantity = quantity;
        }

        public enum ItemType
        {
            Default = 0,
            Character = 1,
            House = 2,
            Background = 3,
            Pet = 4,
            Pack = 5,
            LobbyIcon = 8,
            DeathAnimation = 9,
            Scroll = 16, // 0x00000010
            AccountItem = 23, // 0x00000017
            Currency = 24, // 0x00000018
            Taunt = 25, // 0x00000019
            Potion = 26, // 0x0000001A
            Promotion = 98, // 0x00000062
            AccountFeature = 99 // 0x00000063
        }
    }
}
