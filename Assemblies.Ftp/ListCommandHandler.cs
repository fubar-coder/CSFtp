using System;

namespace Assemblies.Ftp.FtpCommands
{
	class ListCommandHandler : ListCommandHandlerBase
	{
		public ListCommandHandler(FtpConnectionObject connectionObject)
			: base("LIST", connectionObject)
		{
			
		}

		protected override string BuildReply(string sMessage, string[] asFiles)
		{
			return BuildLongReply(asFiles);
		}
	}
}
