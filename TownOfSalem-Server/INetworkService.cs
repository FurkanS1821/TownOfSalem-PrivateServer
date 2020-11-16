using System;
using System.Collections.Generic;
using TownOfSalem_Logic.Enums;
using Client = TownOfSalem_Networking.Client;
using Server = TownOfSalem_Networking.Server;

namespace TownOfSalem_Logic
{
    public abstract class INetworkService
    {
        public Dictionary<Client.MessageType, Action<INetworkService, Client.BaseMessage>> OnMessage =
            new Dictionary<Client.MessageType, Action<INetworkService, Client.BaseMessage>>();

        public Action<Client.BaseMessage> OnAnyMessage = message => { };
        public event Action OnConnected = () => { };

        protected void RaiseOnConnected()
        {
            OnConnected();
        }

        public event Action<string> OnConnectionFailed = error => { };

        protected void RaiseOnConnectionFailed(string error)
        {
            OnConnectionFailed(error);
        }

        public event Action<DisconnectReason, string, string> OnDisconnected = (reason, description, trace) => { };

        protected void RaiseOnDisconnected(DisconnectReason reason, string description, string trace)
        {
            OnDisconnected(reason, description, trace);
        }

        public abstract void SendMessage(Server.BaseMessage msg);

        public abstract void SendMultipleMessages(params Server.BaseMessage[] messages);

        public abstract void Connect();

        public abstract void Disconnect();

        public abstract void Poll();

        public abstract List<Client.BaseMessage> GetReceivedMessages();

        public void RegisterCallback(Client.MessageType type, Action<INetworkService, Client.BaseMessage> callback)
        {
            if (OnMessage.ContainsKey(type))
            {
                OnMessage[type] += callback;
            }
        }

        public void UnregisterCallback(Client.MessageType type, Action<INetworkService, Client.BaseMessage> callback)
        {
            if (!OnMessage.ContainsKey(type))
            {
                return;
            }

            OnMessage[type] -= callback;
        }
    }
}
