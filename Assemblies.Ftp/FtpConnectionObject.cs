using System;
using System.Threading.Tasks;

namespace Assemblies.Ftp
{
	/// <summary>
	/// Processes incoming messages and passes the data on to the relevant handler class.
	/// </summary>
	public class FtpConnectionObject : FtpConnectionData
	{
		#region Member Variables

		private System.Collections.Hashtable m_theCommandHashTable = null;
		private FileSystem.IFileSystemClassFactory m_fileSystemClassFactory = null;
		
		#endregion

		#region Construction

		public FtpConnectionObject(FileSystem.IFileSystemClassFactory fileSystemClassFactory, int nId, System.Net.Sockets.TcpClient socket)
			: base(nId, socket)
		{
			m_theCommandHashTable = new System.Collections.Hashtable();
			m_fileSystemClassFactory = fileSystemClassFactory;
			
			LoadCommands();
		}

		#endregion

		#region Methods

		public bool Login(string sPassword)
		{
			FileSystem.IFileSystem fileSystem = m_fileSystemClassFactory.Create(this.User, sPassword);

			if (fileSystem == null)
			{
				return false;
			}

			SetFileSystemObject(fileSystem);
			return true;
		}

		private void LoadCommands()
		{
			AddCommand(new FtpCommands.UserCommandHandler(this));
			AddCommand(new FtpCommands.PasswordCommandHandler(this));
			AddCommand(new FtpCommands.QuitCommandHandler(this));
			AddCommand(new FtpCommands.CwdCommandHandler(this));
			AddCommand(new FtpCommands.PortCommandHandler(this));
			AddCommand(new FtpCommands.PasvCommandHandler(this));
			AddCommand(new FtpCommands.ListCommandHandler(this));
			AddCommand(new FtpCommands.NlstCommandHandler(this));
			AddCommand(new FtpCommands.PwdCommandHandler(this));
			AddCommand(new FtpCommands.XPwdCommandHandler(this));
			AddCommand(new FtpCommands.TypeCommandHandler(this));
			AddCommand(new FtpCommands.RetrCommandHandler(this));
			AddCommand(new FtpCommands.NoopCommandHandler(this));
			AddCommand(new FtpCommands.SizeCommandHandler(this));
			AddCommand(new FtpCommands.DeleCommandHandler(this));
			AddCommand(new FtpCommands.AlloCommandHandler(this));
			AddCommand(new FtpCommands.StoreCommandHandler(this));
			AddCommand(new FtpCommands.MakeDirectoryCommandHandler(this));
			AddCommand(new FtpCommands.RemoveDirectoryCommandHandler(this));
			AddCommand(new FtpCommands.AppendCommandHandler(this));
			AddCommand(new FtpCommands.RenameStartCommandHandler(this));
			AddCommand(new FtpCommands.RenameCompleteCommandHandler(this));
			AddCommand(new FtpCommands.XMkdCommandHandler(this));
			AddCommand(new FtpCommands.XRmdCommandHandler(this));
		}

		private void AddCommand(FtpCommands.FtpCommandHandler handler)
		{
			m_theCommandHashTable.Add(handler.Command, handler);
		}

		public async Task Process(Byte [] abData)
		{
			string sMessage = System.Text.Encoding.ASCII.GetString(abData);
			sMessage = sMessage.Substring(0, sMessage.IndexOf('\r'));

			FtpServerMessageHandler.SendMessage(Id, sMessage);

			string sCommand;
			string sValue;

			int nSpaceIndex = sMessage.IndexOf(' ');

			if (nSpaceIndex < 0)
			{
				sCommand = sMessage.ToUpper();
				sValue = "";
			}
			else
			{
				sCommand = sMessage.Substring(0, nSpaceIndex).ToUpper();
				sValue = sMessage.Substring(sCommand.Length + 1);
			}

			FtpCommands.FtpCommandHandler handler = m_theCommandHashTable[sCommand] as FtpCommands.FtpCommandHandler;

			if (handler == null)
			{
				FtpServerMessageHandler.SendMessage(Id, string.Format("\"{0}\" : Unknown command", sCommand));
				await Assemblies.General.SocketHelpers.Send(Socket, "550 Unknown command\r\n");
			}
			else
			{
				await handler.Process(sValue);
			}
		}

		#endregion
	}
}
