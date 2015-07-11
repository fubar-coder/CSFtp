using System;

namespace Assemblies.Ftp.FtpCommands
{
	class XRmdCommandHandler : RemoveDirectoryCommandHandlerBase
	{
		public XRmdCommandHandler(FtpConnectionObject connectionObject)
			: base("XRMD", connectionObject)
		{
			
		}
	}
}
