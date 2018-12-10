using System.Collections.Generic;
using System.IO;
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
            writer.Write(Encoding.UTF8.GetBytes(CauldronType.ToString()));
            writer.Write(',');
            writer.Write(Encoding.UTF8.GetBytes(Progress.ToString()));
            writer.Write(',');
            writer.Write(Encoding.UTF8.GetBytes(ProgressTarget.ToString()));
            writer.Write(',');
            writer.Write(Encoding.UTF8.GetBytes(IsCompleted ? "1" : "0"));
            writer.Write(',');
            writer.Write(Encoding.UTF8.GetBytes(CooldownSeconds.ToString()));
            writer.Write(',');

            for (var i = 0; i < AvailablePotions.Count; i++)
            {
                writer.Write(Encoding.UTF8.GetBytes(AvailablePotions[i].ToString()));

                if (i < AvailablePotions.Count - 1)
                {
                    writer.Write('*');
                }
            }

            writer.Write(',');

            for (var i = 0; i < Awards.Count; i++)
            {
                var award = Awards[i];

                writer.Write(Encoding.UTF8.GetBytes(award.Type.ToString()));
                writer.Write('|');
                writer.Write(Encoding.UTF8.GetBytes(award.Id.ToString()));
                writer.Write('|');
                writer.Write(Encoding.UTF8.GetBytes(award.Quantity.ToString()));

                if (i < Awards.Count - 1)
                {
                    writer.Write('*');
                }
            }
        }
    }
}
