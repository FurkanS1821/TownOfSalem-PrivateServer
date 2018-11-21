using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Client.Global
{
    public class SystemCommandMessage : BaseMessage
    {
        protected int _command;
        protected byte[] _arguments;

        public SystemCommandMessage(int command, string args = "") : base(MessageType.SystemCommand)
        {
            _command = command;
            _arguments = Encoding.UTF8.GetBytes(args);
        }

        public SystemCommandMessage(int command, byte[] args) : base(MessageType.SystemCommand)
        {
            _command = command;
            _arguments = args;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)_command);
            writer.Write(_arguments);
        }
    }
}
