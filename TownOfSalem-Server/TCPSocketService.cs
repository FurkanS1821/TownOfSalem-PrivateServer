using System;
using System.Net.Sockets;
using TownOfSalem_Logic.Enums;

namespace TownOfSalem_Logic
{
    public class TCPSocketService : ISocketService
    {
        private byte[] _messageBuffer = new byte[524800];
        private byte[] _receiveBuffer = new byte[4096];
        private Socket _socket;
        private int _messageBufferSize;

        public TCPSocketService(Socket socket)
        {
            _socket = socket;
        }

        public override void Disconnect()
        {
            if (_socket == null)
            {
                return;
            }

            _socket.Disconnect(false);
            _socket = null;
        }

        public override void Poll()
        {
            try
            {
                if (_socket == null || _socket.Available <= 0)
                {
                    return;
                }

                var count1 = _socket.Receive(_receiveBuffer, Math.Min(4096, _socket.Available), SocketFlags.None);
                if (_messageBufferSize + count1 < 524800)
                {
                    Buffer.BlockCopy(_receiveBuffer, 0, _messageBuffer, _messageBufferSize, count1);
                    _messageBufferSize += count1;
                    var srcOffset = 0;
                    var num = 0;
                    for (var index = 0; index < _messageBufferSize; ++index)
                    {
                        if (_messageBuffer[index] == 0)
                        {
                            num = index;
                            var data = new byte[index - srcOffset];
                            Buffer.BlockCopy(_messageBuffer, srcOffset, data, 0, index - srcOffset);
                            srcOffset = index + 1;
                            if (data.Length > 0)
                            {
                                RaiseOnMessageReceived(data);
                            }
                        }
                    }

                    if (num <= 0)
                    {
                        return;
                    }

                    var count2 = _messageBufferSize - (num + 1);
                    Buffer.BlockCopy(_messageBuffer, num + 1, _messageBuffer, 0, count2);
                    _messageBufferSize = count2;
                }
            }
            catch (SocketException ex)
            {
                Disconnect();
                var trace = $"Poll() Socket Exception - {ex.StackTrace}";
                RaiseOnDisconnected(DisconnectReason.NetworkError, ex.Message, trace);
            }
            catch (ObjectDisposedException ex)
            {
                Disconnect();
                var trace = $"Poll() ODE Exception - {ex.StackTrace}";
                RaiseOnDisconnected(DisconnectReason.UnexpectedError, ex.Message, trace);
            }
            catch (Exception ex)
            {
                Disconnect();
                string message;
                string trace;
                if (ex.InnerException != null)
                {
                    message = ex.InnerException.Message;
                    trace = $"Poll() Exception with Inner Exception - {PrepareTrace(ex.StackTrace, ex.InnerException.StackTrace)}";
                }
                else
                {
                    message = ex.Message;
                    trace = $"Poll() Exception - {ex.StackTrace}";
                }

                RaiseOnDisconnected(DisconnectReason.UnexpectedError, message, trace);
            }
        }

        public override void Send(byte[] data)
        {
            try
            {
                _socket.Send(data);
            }
            catch (SocketException ex)
            {
                Disconnect();
                var trace = $"Send() Socket Exception - {ex.StackTrace}";
                RaiseOnDisconnected(DisconnectReason.NetworkError, ex.Message, trace);
            }
            catch (ObjectDisposedException ex)
            {
                Disconnect();
                var trace = $"Send() ODE Exception - {ex.StackTrace}";
                RaiseOnDisconnected(DisconnectReason.UnexpectedError, ex.Message, trace);
            }
            catch (Exception ex)
            {
                Disconnect();
                string trace;
                if (ex.InnerException != null)
                {
                    trace = $"Send() Exception with Inner Exception - {PrepareTrace(ex.StackTrace, ex.InnerException.StackTrace)}";
                }
                else
                {
                    trace = $"Send() Exception - {ex.StackTrace}";
                }

                RaiseOnDisconnected(DisconnectReason.UnexpectedError, ex.Message, trace);
            }
        }

        private string PrepareTrace(params string[] args)
        {
            return string.Join("\n        =================\n", args);
        }
    }
}
