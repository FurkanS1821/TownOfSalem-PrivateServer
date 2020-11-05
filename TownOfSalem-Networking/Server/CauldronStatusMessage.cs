using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TownOfSalem_Networking.Structs;

namespace TownOfSalem_Networking.Server
{
    public class CauldronStatusMessage : BaseMessage
    {
        public readonly List<int> AvailablePotions;
        public readonly List<ProductItem> Awards;
        public readonly int CauldronType;
        public readonly int Progress;
        public readonly int ProgressTarget;
        public readonly bool IsCompleted;
        public readonly int CooldownSeconds;

        public CauldronStatusMessage(List<int> availablePotions, List<ProductItem> awards, int cauldronType,
            int progress, int progressTarget, bool isCompleted, int cooldownSeconds) : base(MessageType.CauldronStatus)
        {
            AvailablePotions = availablePotions;
            Awards = awards;
            CauldronType = cauldronType;
            Progress = progress;
            ProgressTarget = progressTarget;
            IsCompleted = isCompleted;
            CooldownSeconds = cooldownSeconds;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            var packetContent = $"{CauldronType},{Progress},{ProgressTarget},{(IsCompleted ? 2 : 1)},{CooldownSeconds},";
            packetContent += string.Join("*", AvailablePotions) + ",";

            var awardList = Awards.Select(x => $"{x.Type}|{x.Id}|{x.Quantity}");

            packetContent += string.Join("*", awardList);
            writer.Write(Encoding.UTF8.GetBytes(packetContent));
        }
    }
}