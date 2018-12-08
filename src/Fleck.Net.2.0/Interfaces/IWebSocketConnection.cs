using Fleck.Abstractions;
using System;

namespace Fleck
{
	public interface IWebSocketConnection
    {
        Action OnOpen { get; set; }
        Action OnClose { get; set; }
        Action<string> OnMessage { get; set; }
        Action<byte[]> OnBinary { get; set; }
        Action<byte[]> OnPing { get; set; }
        Action<byte[]> OnPong { get; set; }
        Action<Exception> OnError { get; set; }

		void Close();
        IWebSocketConnectionInfo ConnectionInfo { get; }
        bool IsAvailable { get; }

		//Task Send(string message);
		//Task Send(byte[] message);
		//Task SendPing(byte[] message);
		//Task SendPong(byte[] message);
		void Send(string message);
		void Send(byte[] message);
		void SendPing(byte[] message);
		void SendPong(byte[] message);
	}
}
