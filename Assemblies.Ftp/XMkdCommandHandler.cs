using System;

namespace Assemblies.Ftp.FtpCommands
{
	class XMkdCommandHandler : MakeDirectoryCommandHandlerBase
	{
		public XMkdCommandHandler(FtpConnectionObject connectionObject)
			: base("XMKD", connectionObject)
		{
			
		}
	}
}
