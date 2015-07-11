using System;

namespace Assemblies.Ftp.FtpCommands
{
	/// <summary>
	/// Present working directory command handler
	/// </summary>
	class XPwdCommandHandler : PwdCommandHandlerBase
	{
		public XPwdCommandHandler(FtpConnectionObject connectionObject)
			: base("XPWD", connectionObject)
		{
			
		}
	}
}
