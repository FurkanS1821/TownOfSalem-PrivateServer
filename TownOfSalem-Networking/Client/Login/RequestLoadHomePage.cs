using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Client.Login
{
    public class RequestLoadHomePage : BaseMessage
    {
        private LoginType _loginType;
        private string _username;
        private string _password;
        private int _flags;
        private int _buildId;
        private Platform _platform;

        public RequestLoadHomePage(string username, string password, LoginType loginType, byte flags, Platform platform,
            int buildId) : base(MessageType.RequestLoadHomepage)
        {
            _username = username;
            _password = password;
            _flags = flags;
            _buildId = buildId;
            _platform = platform;
            _loginType = loginType;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)_loginType);
            writer.Write((byte)(_flags + 1));
            writer.Write((byte)_platform);
            writer.Write(Encoding.UTF8.GetBytes(_buildId.ToString()));
            writer.Write((byte)30);
            writer.Write(Encoding.UTF8.GetBytes(_username));
            writer.Write((byte)30);
            writer.Write(Encoding.UTF8.GetBytes(Crypto.PublicKeyEncrypt(_password)));
        }
    }
}
