using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Assemblies.General
{
	public sealed class SocketHelpers
	{
		private SocketHelpers()
		{
		}

		static public bool Send(TcpClient socket, byte [] abMessage)
		{
			return Send(socket, abMessage, 0, abMessage.Length);
		}

		static public bool Send(TcpClient socket, byte [] abMessage, int nStart)
		{
			return Send(socket, abMessage, nStart, abMessage.Length - nStart);
		}

		static public bool Send(TcpClient socket, byte [] abMessage, int nStart, int nLength)
		{
			bool fReturn = true;

			try
			{
				BinaryWriter writer = new BinaryWriter(socket.GetStream());
				writer.Write(abMessage, nStart, nLength);
				writer.Flush();
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

		static public bool Send(TcpClient socket, string sMessage)
		{
			byte [] abMessage = System.Text.Encoding.ASCII.GetBytes(sMessage);
			return Send(socket, abMessage);
		}

		static public void Close(TcpClient socket)
		{
			if (socket == null)
			{
				return;
			}

			try
			{
				if (socket.GetStream() != null)
				{
					try
					{
						socket.GetStream().Flush();
					}
					catch (SocketException)
					{
					}

					try
					{
						socket.GetStream().Close();
					}
					catch (SocketException)
					{
					}
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
