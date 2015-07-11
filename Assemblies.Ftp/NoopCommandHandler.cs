using System;
using System.Threading.Tasks;

namespace Assemblies.Ftp.FtpCommands
{
	class NoopCommandHandler : FtpCommandHandler
	{
		public NoopCommandHandler(FtpConnectionObject connectionObject)
			: base("NOOP", connectionObject)
		{
			
		}

        protected override Task<string> OnProcess(string sMessage)
		{
			return GetMessage(200, "");
		}
	}
}
