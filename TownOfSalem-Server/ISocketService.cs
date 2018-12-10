using System;
using TownOfSalem_Logic.Enums;

namespace TownOfSalem_Logic
{
    public abstract class ISocketService
    {
        public const int MESSAGE_BUFFER_MAX_SIZE = 524800;
        public const int RECEIVE_BUFFER_MAX_SIZE = 4096;

        public event Action<byte[]> OnMessageReceived = data => {};

        protected void RaiseOnMessageReceived(byte[] data)
        {
            OnMessageReceived(data);
        }

        public event Action OnConnected = () => {};

        protected void RaiseOnConnected()
        {
            OnConnected();
        }

        public event Action<DisconnectReason, string, string> OnDisconnected = (reason, description, trace) => {};

        protected void RaiseOnDisconnected(DisconnectReason reason, string description, string trace)
        {
            OnDisconnected(reason, description, trace);
        }

        public event Action<string> OnConnectionFailed = data => {};

        protected void RaiseOnConnectionFailed(string data)
        {
            OnConnectionFailed(data);
        }

        public abstract void Disconnect();

        public abstract void Send(byte[] data);

        public abstract void Poll();
    }
}
