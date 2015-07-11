using System;
using System.Threading.Tasks;

namespace Assemblies.Ftp.FtpCommands
{
	/// <summary>
	/// Base class for present current directory commands
	/// </summary>
	class PwdCommandHandlerBase : FtpCommandHandler
	{
		public PwdCommandHandlerBase(string sCommand, FtpConnectionObject connectionObject)
			: base(sCommand, connectionObject)
		{
			
		}

        protected override Task<string> OnProcess(string sMessage)
		{
			string sDirectory = ConnectionObject.CurrentDirectory;
			sDirectory = sDirectory.Replace('\\', '/');
			return GetMessage(257, string.Format("\"{0}\" PWD Successful.", sDirectory));
		}
	}
}
