using System;

namespace Assemblies.Ftp.FtpCommands
{
	class MakeDirectoryCommandHandler : MakeDirectoryCommandHandlerBase
	{
		public MakeDirectoryCommandHandler(FtpConnectionObject connectionObject)
			: base("MKD", connectionObject)
		{
			
		}
	}
}
