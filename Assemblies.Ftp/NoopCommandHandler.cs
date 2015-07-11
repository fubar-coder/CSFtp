using System;

namespace Assemblies.Ftp.FtpCommands
{
	class NoopCommandHandler : FtpCommandHandler
	{
		public NoopCommandHandler(FtpConnectionObject connectionObject)
			: base("NOOP", connectionObject)
		{
			
		}

		protected override string OnProcess(string sMessage)
		{
			return GetMessage(200, "");
		}
	}
}
