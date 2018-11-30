using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class ProductPurchaseResultMessage : BaseMessage
    {
        public readonly ProductPurchaseResult Result = new ProductPurchaseResult();

        public ProductPurchaseResultMessage(ProductPurchaseResult result) : base(MessageType.ProductPurchaseResult)
        {
            Result = result;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(Result.ProductId.ToString()));
            writer.Write(',');
            writer.Write(Encoding.UTF8.GetBytes(Result.Quantity.ToString()));
            writer.Write(',');
            writer.Write((byte)Result.Source);
            writer.Write(',');
            writer.Write(Encoding.UTF8.GetBytes(Result.SourceData.ToString()));
            writer.Write(',');
            writer.Write((byte)Result.Code);
            writer.Write(',');
            writer.Write((byte)Result.Category);

            if (Result.Code != ProductPurchaseResult.ResultCode.Eligible)
            {
                return;
            }

            writer.Write(',');

            for (var i = 0; i < Result.Items.Count; i++)
            {
                var item = Result.Items[i];

                writer.Write((byte)item.Type);
                writer.Write(',');
                writer.Write((byte)item.Id);
                writer.Write(',');
                writer.Write((byte)item.Quantity);

                if (i < Result.Items.Count - 1)
                {
                    writer.Write(',');
                }
            }
        }
    }
}
