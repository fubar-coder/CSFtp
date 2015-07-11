using System;
using System.Threading.Tasks;

namespace Assemblies.Ftp.FtpCommands
{
	class QuitCommandHandler : FtpCommandHandler
	{
		public QuitCommandHandler(FtpConnectionObject connectionObject)
			: base("QUIT", connectionObject)
		{
			
		}

        protected override Task<string> OnProcess(string sMessage)
		{
			return GetMessage(220, "Goodbye");
		}
	}
}
