using System;
using System.Threading.Tasks;

namespace Assemblies.Ftp.FtpCommands
{
	/// <summary>
	/// Implements the 'TYPE' command
	/// </summary>
	class TypeCommandHandler : FtpCommandHandler
	{
		public TypeCommandHandler(FtpConnectionObject connectionObject)
			: base("TYPE", connectionObject)
		{
			
		}

        protected override Task<string> OnProcess(string sMessage)
		{
			sMessage = sMessage.ToUpper();

			if (sMessage == "A")
			{
				ConnectionObject.BinaryMode = false;
				return GetMessage(200, "ASCII transfer mode active.");
			}
			else if (sMessage == "I")
			{
				ConnectionObject.BinaryMode = true;
				return GetMessage(200, "Binary transfer mode active.");
			}
			else
			{
				return GetMessage(550, string.Format("Error - unknown binary mode \"{0}\"", sMessage));
			}
		}
	}
}
