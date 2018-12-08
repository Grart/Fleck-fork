using System;
using System.Collections.Generic;
using System.Text;

namespace Fleck.Abstractions
{
	public delegate void Action();
	//public delegate void Action<T1>(T1 t1); System.Action<T>
	public delegate void Action<T1, T2>(T1 t1, T2 t2);
	public delegate void Action<T1, T2, T3>(T1 t1, T2 t2, T3 t3);
	public delegate void Action<T1, T2, T3, T4>(T1 t1, T2 t2, T3 t3, T4 t4);


	public delegate T1 Func<T1>();
	public delegate T2 Func<T1, T2>(T1 t1);
	public delegate T3 Func<T1, T2, T3>(T1 t1, T2 t2);
	public delegate T4 Func<T1, T2, T3, T4>(T1 t1, T2 t2, T3 t3);

	internal class OSPlatform
	{
		internal static string Windows { get; set; } = "Window";
	}

	internal class RuntimeInformation
	{
		internal static bool IsOSPlatform(string platform)
		{
			return "Window" == platform;
		}
	}

	internal static class LinqExtensions
	{
		internal static byte[] SkipTakeToArray(
				byte[] binary,
				int index
			)
		{
			var _len = binary.Length - index;
			return SkipTakeToArray(
					binary,
					index,
					_len,
					null
				);
		}
		internal static byte[] SkipTakeToArray(
				byte[] binary,
				int index,
				int len,
				Func<byte, int, byte> func = null
			)
		{
			//binary.Skip(index).Take(len).ToArray();
			byte[] _binary = new byte[len];
			if (null != func)
			{
				for (int _i1 = 0, _i2 = index; _i1 < len; _i1++, _i2++)
				{
					_binary[_i1] = func(binary[_i2], _i1);
				}
			}
			else
			{
				Array.Copy(binary, index, _binary, 0, len);
			}
			return _binary;
		}

		internal static int CountSpaceChar(string str)
		{
			if(null== str
				||0== str.Length)
			{
				return 0;
			}
			int _sCnt = 0;
			for (int _i = 0, _iCnt = str.Length; _i < _iCnt; _i++)
			{
				if (str[_i] == ' ')
				{
					_sCnt++;
				}
			}
			return _sCnt;
		}


		internal static char[] WhereToArray(
				string str,
				Func<char, bool> func
			)
		{
			if (null == str
				|| 0 == str.Length)
			{
				return new char[] { };
			}
			var _cLis = new List<char>();
			for (int _i = 0, _iCnt = str.Length; _i < _iCnt; _i++)
			{
				var _char = str[_i];
				if (func(_char))
				{
					_cLis.Add(_char);
				}
			}
			return _cLis.ToArray();
		}
	}

	internal class CancellationTokenSource
	{
		public bool IsCancellationRequested { get; set; }
		internal void Cancel()
		{
			IsCancellationRequested = true;
		}
	}
}
