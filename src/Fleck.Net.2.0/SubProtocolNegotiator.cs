using System;
using System.Collections.Generic;

namespace Fleck
{
	public static class SubProtocolNegotiator
    {
        public static string Negotiate(
				string[] server,//IEnumerable<string> server,
				string[] client//IEnumerable<string> client
			)
        {
			//if (!server.Any() || !client.Any())
			//{
			//	return null;
			//}
			if (null == server
				|| 0 == server.Length
				|| null == client
				|| 0 == client.Length)
			{
				return null;
			}

			//��Ϊ server Ĭ���� string[0] ��ʱ����
			//var matches = client.Intersect(server);
			//if (!matches.Any())
			//{
			//	throw new SubProtocolNegotiationFailureException("Unable to negotiate a subprotocol");
			//}
			//return matches.First();
			return string.Empty;
		}
    }
}
