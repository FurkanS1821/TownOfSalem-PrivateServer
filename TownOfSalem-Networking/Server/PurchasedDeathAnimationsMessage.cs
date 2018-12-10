using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class PurchasedDeathAnimationsMessage : BaseMessage
    {
        public int[] DeathAnimations;

        public PurchasedDeathAnimationsMessage(int[] deathAnimations) : base(MessageType.PurchasedDeathAnimations)
        {
            DeathAnimations = deathAnimations;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            for (var i = 0; i < DeathAnimations.Length; i++)
            {
                writer.Write(Encoding.UTF8.GetBytes(DeathAnimations[i].ToString()));

                if (i < DeathAnimations.Length - 1)
                {
                    writer.Write(',');
                }
            }
        }
    }
}
