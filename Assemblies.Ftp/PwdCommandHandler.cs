using System;

namespace Assemblies.Ftp.FtpCommands
{
	/// <summary>
	/// Present working directory command handler
	/// </summary>
	class PwdCommandHandler : PwdCommandHandlerBase
	{
		public PwdCommandHandler(FtpConnectionObject connectionObject)
			: base("PWD", connectionObject)
		{
			
		}
	}
}
