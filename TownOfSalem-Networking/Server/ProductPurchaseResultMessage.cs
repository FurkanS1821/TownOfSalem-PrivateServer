using System.IO;
using System.Linq;
using System.Text;
using TownOfSalem_Networking.Structs;

namespace TownOfSalem_Networking.Server
{
    public class ProductPurchaseResultMessage : BaseMessage
    {
        public readonly ProductPurchaseResult Result;

        public ProductPurchaseResultMessage(ProductPurchaseResult result) : base(MessageType.ProductPurchaseResult)
        {
            Result = result;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            var data = $"{Result.ProductId},{Result.Quantity},{(byte)Result.Source},{Result.SourceData},";
            data += $"{(byte)Result.Code},{(byte)Result.Category}";
            if (Result.Code == ProductPurchaseResult.ResultCode.Eligible)
            {
                data += "," + string.Join(",", Result.Items.Select(x => $"{x.Type},{x.Id},{x.Quantity}"));
            }

            writer.Write(Encoding.UTF8.GetBytes(data));
        }
    }
}