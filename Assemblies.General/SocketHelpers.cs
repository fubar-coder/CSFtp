using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Assemblies.General
{
	public static class SocketHelpers
	{
		static public async Task<bool> Send(TcpClient socket, byte [] abMessage)
		{
			return await Send(socket, abMessage, 0, abMessage.Length);
		}

		static public async Task<bool> Send(TcpClient socket, byte [] abMessage, int nStart)
		{
			return await Send(socket, abMessage, nStart, abMessage.Length - nStart);
		}

		static public async Task<bool> Send(TcpClient socket, byte [] abMessage, int nStart, int nLength)
		{
			bool fReturn = true;

			try
			{
			    var stream = socket.GetStream();
			    await stream.WriteAsync(abMessage, nStart, nLength);
			    await stream.FlushAsync();
			}
			catch (IOException)
			{
				fReturn = false;
			}
			catch (SocketException)
			{
				fReturn = false;
			}

			return fReturn;
		}

		static public async Task<bool> Send(TcpClient socket, string sMessage)
		{
			byte [] abMessage = System.Text.Encoding.ASCII.GetBytes(sMessage);
			return await Send(socket, abMessage);
		}

		static public void Close(TcpClient socket)
		{
		    if (socket == null)
		        return;

		    try
			{
                var stream = socket.GetStream();
                try
				{
				    stream.Flush();
				}
				catch (SocketException)
				{
				}

				try
				{
					stream.Close();
				}
				catch (SocketException)
				{
				}
			}
			catch (SocketException)
			{
			}
			catch (InvalidOperationException)
			{
			}

			try
			{
				socket.Close();
			}
			catch (SocketException)
			{
			}
		}

		static public TcpClient CreateTcpClient(string sAddress, int nPort)
		{
			TcpClient client = null;

			try
			{
				client = new TcpClient(sAddress, nPort);
			}
			catch (SocketException)
			{
				client = null;
			}

			return client;
		}

		static public TcpListener CreateTcpListener(int nPort)
		{
			TcpListener listener = null;

			try
			{
				listener = new TcpListener(IPAddress.Any, nPort);
			}
			catch (SocketException)
			{
				listener = null;
			}

			return listener;
		}

		static public IPAddress GetLocalAddress()
		{
            var hostEntry = Dns.GetHostEntry(Dns.GetHostName());

			if (hostEntry == null || hostEntry.AddressList.Length == 0)
			{
				return null;
			}

			return hostEntry.AddressList[0];
		}
	}
}
