using Fleck;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppNet20
{
	class Program
	{
		static void Main()
		{
			FleckLog.Level = LogLevel.Debug;
			var allSockets = new List<IWebSocketConnection>();
			var server = new WebSocketServer("ws://0.0.0.0:8181");
			server.Start(
				socket =>
				{
					socket.OnOpen = () =>
					{
						Console.WriteLine("Open!");
						allSockets.Add(socket);
					};
					socket.OnClose = () =>
					{
						Console.WriteLine("Close!");
						allSockets.Remove(socket);
					};
					socket.OnMessage = message =>
					{
						Console.WriteLine(message);
						var _lis = new List<IWebSocketConnection>(allSockets.ToArray());
						_lis.ForEach(s => s.Send("Echo: " + message));
					};
				}
			);


			var input = Console.ReadLine();
			while (input != "exit")
			{
				var _lis = new List<IWebSocketConnection>(allSockets.ToArray());
				foreach (var socket in _lis)
				{
					socket.Send(input);
				}
				input = Console.ReadLine();
			}

		}
	}
}
