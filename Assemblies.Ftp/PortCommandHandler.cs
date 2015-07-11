using System;
using System.Threading.Tasks;

namespace Assemblies.Ftp.FtpCommands
{
	class PortCommandHandler : FtpCommandHandler
	{
		public PortCommandHandler(FtpConnectionObject connectionObject)
			: base("PORT", connectionObject)
		{
			
		}

        protected override Task<string> OnProcess(string sMessage)
		{
			string [] asData = sMessage.Split(new char [] { ',' });

			if (asData.Length != 6)
			{
				return GetMessage(550, "Error in setting up data connection");
			}

			int nSocketPort = int.Parse(asData[4]) * 256 + int.Parse(asData[5]);

			ConnectionObject.PortCommandSocketPort = nSocketPort;
			ConnectionObject.PortCommandSocketAddress = string.Join(".", asData, 0, 4);
			
			return GetMessage(200, string.Format("{0} command succeeded", Command));
		}
	}
}
