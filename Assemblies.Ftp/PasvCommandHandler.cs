using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assemblies.Ftp.FtpCommands
{
	class PasvCommandHandler : FtpCommandHandler
	{
		private const int m_nPort = 0;
        private readonly TimeSpan m_acceptTimeout = TimeSpan.FromSeconds(5);

		public PasvCommandHandler(FtpConnectionObject connectionObject)
			: base("PASV", connectionObject)
		{
			
		}

        protected override async Task<string> OnProcess(string sMessage)
		{
		    if (ConnectionObject.PasvSocket == null)
		    {
		        var listener = Assemblies.General.SocketHelpers.CreateTcpListener(m_nPort);

		        if (listener == null)
		        {
		            return await GetMessage(550, string.Format("Couldn't start listener on port {0}", m_nPort));
		        }

                listener.Start();

                var port = ((IPEndPoint)listener.LocalEndpoint).Port;

		        await SendMessage(await GetPasvReply(port));

		        var timePassed = new TimeSpan();
		        var threadSleepTimeout = TimeSpan.FromMilliseconds(50);
		        while (!listener.Pending() && timePassed < m_acceptTimeout)
		        {
		            Thread.Sleep(threadSleepTimeout);
		            timePassed += threadSleepTimeout;
		        }

		        if (listener.Pending())
		        {
		            var pasvClient = await listener.AcceptTcpClientAsync();
		            ConnectionObject.PasvSocket = pasvClient;
		        }
		        listener.Stop();

		        return null;
		    }
		    else
		    {
		        var port = ((IPEndPoint)ConnectionObject.PasvSocket.Client.LocalEndPoint).Port;
		        return await GetPasvReply(port);
		    }
		}

        private Task<string> GetPasvReply(int port)
        {
            var sIpAddress = new StringBuilder();
            var endPoint = ((IPEndPoint)ConnectionObject.Socket.Client.LocalEndPoint);
            sIpAddress.Append(endPoint.Address.ToString().Replace('.', ','));
            var portBytes = BitConverter.GetBytes((ushort)port);
            if (BitConverter.IsLittleEndian)
                portBytes = portBytes.Reverse().ToArray();
            sIpAddress.AppendFormat(",{0},{1}", portBytes[0], portBytes[1]);
            return GetMessage(227, string.Format("Entering Passive Mode ({0}).", sIpAddress));
        }
    }
}
