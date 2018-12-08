using Fleck.Abstractions;
using System;
using System.IO;
using System.Net;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

namespace Fleck
{
	public interface ISocket
    {
        bool Connected { get; }
        string RemoteIpAddress { get; }
        int RemotePort { get; }
        Stream Stream { get; }
        bool NoDelay { get; set; }
        EndPoint LocalEndPoint { get; }

		//Task<ISocket> Accept(Action<ISocket> callback, Action<Exception> error);
		void Accept(Action<ISocket> callback, Action<Exception> error);
		//Task Send(byte[] buffer, Action callback, Action<Exception> error);
		void Send(byte[] buffer, Action<int> callback, Action<Exception> error);
		//Task<int> Receive(byte[] buffer, Action<int> callback, Action<Exception> error, int offset = 0);
		void Receive(byte[] buffer, Action<int> callback, Action<Exception> error, int offset = 0);

		//Task Authenticate(
		void Authenticate(
				X509Certificate2 certificate, 
				SslProtocols enabledSslProtocols, 
				Action callback, 
				Action<Exception> error
			);

        void Dispose();
        void Close();

        void Bind(EndPoint ipLocal);
        void Listen(int backlog);
    }
}
