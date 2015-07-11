using System;

namespace Assemblies.Ftp.FtpCommands
{
	class RemoveDirectoryCommandHandler : RemoveDirectoryCommandHandlerBase
	{
		public RemoveDirectoryCommandHandler(FtpConnectionObject connectionObject)
			: base("RMD", connectionObject)
		{
			
		}
	}
}
