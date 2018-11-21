using System;

namespace TownOfSalem_Networking.Server
{
    public class ProductPurchaseResultMessage : BaseMessage
    {
        public readonly ProductPurchaseResult Result = new ProductPurchaseResult();

        public ProductPurchaseResultMessage(byte[] data) : base(data)
        {
            try
            {
                var strArray = BytesToString(data, 1).Split(',');
                int.TryParse(strArray[0], out Result.ProductId);
                int.TryParse(strArray[1], out Result.Quantity);
                Result.Source = (ProductPurchaseResult.ResultSource)int.Parse(strArray[2]);
                int.TryParse(strArray[3], out Result.SourceData);
                Result.Code = (ProductPurchaseResult.ResultCode)int.Parse(strArray[4]);
                Result.Category = (ProductPurchaseResult.ResultCategory)int.Parse(strArray[5]);
                if (Result.Code != ProductPurchaseResult.ResultCode.Eligible)
                {
                    return;
                }
                var index = 6;
                while (index < strArray.Length)
                {
                    Result.Items.Add(new ProductItem(
                        int.Parse(strArray[index]),
                        int.Parse(strArray[index + 1]),
                        int.Parse(strArray[index + 2])
                    ));

                    index += 3;
                }
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
