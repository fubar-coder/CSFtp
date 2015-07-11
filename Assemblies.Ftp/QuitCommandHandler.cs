using System;

namespace Assemblies.Ftp.FtpCommands
{
	class QuitCommandHandler : FtpCommandHandler
	{
		public QuitCommandHandler(FtpConnectionObject connectionObject)
			: base("QUIT", connectionObject)
		{
			
		}

		protected override string OnProcess(string sMessage)
		{
			return GetMessage(220, "Goodbye");
		}
	}
}
