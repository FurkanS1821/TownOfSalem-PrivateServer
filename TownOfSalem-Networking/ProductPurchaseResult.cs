using System.Collections.Generic;

namespace TownOfSalem_Networking
{
    public class ProductPurchaseResult
    {
        public List<ProductItem> Items = new List<ProductItem>();
        public int ProductId;
        public int Quantity;
        public ResultSource Source;
        public int SourceData;
        public ResultCode Code;
        public ResultCategory Category;

        public enum ResultCode
        {
            AlreadyOwned = 1,
            UnknownProduct = 2,
            _UNUSED_InvalidPrice = 3,
            InsufficientFunds = 4,
            Eligible = 5,
            MaxQuantity = 6,
            NotAvailable = 7,
        }

        public enum ResultSource
        {
            Shop = 1,
            Promo = 2,
            Redeem = 3,
            Gift = 4,
        }

        public enum ResultCategory
        {
            Item = 1,
            Pack = 2,
            Currency = 3,
            Promotion = 4,
            Potion = 5,
        }
    }
}
