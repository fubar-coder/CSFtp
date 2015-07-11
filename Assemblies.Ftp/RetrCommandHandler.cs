using System;

namespace Assemblies.Ftp.FtpCommands
{
	/// <summary>
	/// Implements the RETR command
	/// </summary>
	class RetrCommandHandler : FtpCommandHandler
	{
		public RetrCommandHandler(FtpConnectionObject connectionObject)
			: base("RETR", connectionObject)
		{
			
		}

		protected override string OnProcess(string sMessage)
		{
			string sFilePath = GetPath(sMessage);
			
			if (!ConnectionObject.FileSystemObject.FileExists(sFilePath))
			{
				return GetMessage(550, "File doesn't exist");
			}

			FtpReplySocket replySocket = new FtpReplySocket(ConnectionObject);
			
			if (!replySocket.Loaded)
			{
				return GetMessage(550, "Unable to establish data connection");
			}

			Assemblies.General.SocketHelpers.Send(ConnectionObject.Socket, "150 Starting data transfer, please wait...\r\n");

			const int m_nBufferSize = 65536;

			FileSystem.IFile file = ConnectionObject.FileSystemObject.OpenFile(sFilePath, false);

			if (file == null)
			{
				return GetMessage(550, "Couldn't open file");
			}

			byte [] abBuffer = new byte[m_nBufferSize];

			int nRead = file.Read(abBuffer, m_nBufferSize);

			while (nRead > 0 && replySocket.Send(abBuffer, nRead))
			{
				nRead = file.Read(abBuffer, m_nBufferSize);
			}

			file.Close();			
			replySocket.Close();
					
			return GetMessage(226, "File download succeeded.");
		}

	}
}
