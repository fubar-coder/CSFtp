using System;
using System.Linq;
using System.Net;
using System.Text;

namespace Assemblies.Ftp.FtpCommands
{
	class PasvCommandHandler : FtpCommandHandler
	{
		const int m_nPort = 0;

		public PasvCommandHandler(FtpConnectionObject connectionObject)
			: base("PASV", connectionObject)
		{
			
		}

		protected override string OnProcess(string sMessage)
		{
			if (ConnectionObject.PasvSocket == null)
			{			
				System.Net.Sockets.TcpListener listener = Assemblies.General.SocketHelpers.CreateTcpListener(m_nPort);

				if (listener == null)
				{
					return GetMessage(550, string.Format("Couldn't start listener on port {0}", m_nPort));
				}

                listener.Start();

			    var port = ((IPEndPoint)listener.LocalEndpoint).Port;

				SendPasvReply(port);

				ConnectionObject.PasvSocket = listener.AcceptTcpClient();
				
				listener.Stop();
				return "";
			}
			else
			{
			    var port = ((IPEndPoint)ConnectionObject.PasvSocket.Client.LocalEndPoint).Port;
				SendPasvReply(port);
				return "";
			}
		}

		private void SendPasvReply(int port)
		{
            var sIpAddress = new StringBuilder();
		    sIpAddress.Append(Assemblies.General.SocketHelpers.GetLocalAddress().ToString().Replace('.', ','));
		    var portBytes = BitConverter.GetBytes((ushort)port);
		    if (BitConverter.IsLittleEndian)
		        portBytes = portBytes.Reverse().ToArray();
		    sIpAddress.AppendFormat(",{0},{1}", portBytes[0], portBytes[1]);
			Assemblies.General.SocketHelpers.Send(ConnectionObject.Socket, string.Format("227 ={0}\r\n", sIpAddress));
		}
	}
}
