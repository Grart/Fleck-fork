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

			//因为 server 默认是 string[0] 暂时不用
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
