using System;
using System.Threading.Tasks;

namespace Assemblies.Ftp.FtpCommands
{
	class AppendCommandHandler : FtpCommandHandler
	{
		private const int m_nBufferSize = 65536;

		public AppendCommandHandler(FtpConnectionObject connectionObject)
			: base("APPE", connectionObject)
		{
			
		}

        protected override async Task<string> OnProcess(string sMessage)
		{
			string sFile = GetPath(sMessage);

			FileSystem.IFile file = ConnectionObject.FileSystemObject.OpenFile(sFile, true);

			if (file == null)
			{
				return await GetMessage(425, "Couldn't open file");
			}
			
			FtpReplySocket socketReply = new FtpReplySocket(ConnectionObject);

			if (!socketReply.Loaded)
			{
				return await GetMessage(425, "Error in establishing data connection.");
			}

			byte [] abData = new byte[m_nBufferSize];

			await Assemblies.General.SocketHelpers.Send(ConnectionObject.Socket, await GetMessage(150, "Opening connection for data transfer."));

			int nReceived = socketReply.Receive(abData);

			while (nReceived > 0)
			{
				nReceived = socketReply.Receive(abData);
				file.Write(abData, nReceived);
			}

			file.Close();
			socketReply.Close();
			
			return await GetMessage(226, string.Format("Appended file successfully. ({0})", sFile));
		}
	}
}
