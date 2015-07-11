using System;
using System.Threading.Tasks;

namespace Assemblies.Ftp.FtpCommands
{
	class StoreCommandHandler : FtpCommandHandler
	{
		private const int m_nBufferSize = 65536;

		public StoreCommandHandler(FtpConnectionObject connectionObject)
			: base("STOR", connectionObject)
		{
			
		}

        protected override async Task<string> OnProcess(string sMessage)
		{
			string sFile = GetPath(sMessage);
			
			if (ConnectionObject.FileSystemObject.FileExists(sFile))
			{
				return await GetMessage(553, "File already exists.");
			}

			FileSystem.IFile file = ConnectionObject.FileSystemObject.OpenFile(sFile, true);

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
				file.Write(abData, nReceived);
				nReceived = socketReply.Receive(abData);
			}

			file.Close();
			socketReply.Close();

			return await GetMessage(226, "Uploaded file successfully.");
		}
	}
}
