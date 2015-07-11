using System;
using System.IO;
using System.Threading.Tasks;

namespace Assemblies.Ftp.FtpCommands
{
	class CwdCommandHandler : FtpCommandHandler
	{
		public CwdCommandHandler(FtpConnectionObject connectionObject)
			: base("CWD", connectionObject)
		{
			
		}

        protected override Task<string> OnProcess(string sMessage)
		{
			sMessage = sMessage.Replace('/', '\\');

			if (!General.FileNameHelpers.IsValid(sMessage))
			{
				return GetMessage(550, "Not a valid directory string.");
			}

			string sDirectory = GetPath(sMessage);

			if (!ConnectionObject.FileSystemObject.DirectoryExists(sDirectory))
			{
				return GetMessage(550, "Not a valid directory.");
			}
			
			ConnectionObject.CurrentDirectory = Path.Combine(ConnectionObject.CurrentDirectory, sMessage);
			return GetMessage(250, string.Format("CWD Successful ({0})", ConnectionObject.CurrentDirectory.Replace("\\", "/")));
		}
	}
}
