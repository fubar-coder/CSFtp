using System;
using System.IO;
using System.Threading.Tasks;

namespace Assemblies.Ftp.FtpCommands
{
	/// <summary>
	/// Base class for all ftp command handlers.
	/// </summary>
	public abstract class FtpCommandHandler
	{
		#region Member Variables

		private string m_sCommand;
		private FtpConnectionObject m_theConnectionObject = null;

		#endregion

		#region Construction
		
		protected FtpCommandHandler(string sCommand, FtpConnectionObject connectionObject)
		{
			m_sCommand = sCommand;
			m_theConnectionObject = connectionObject;
		}

		#endregion

		#region Properties

		public string Command
		{
			get
			{
				return m_sCommand;
			}
		}

		public FtpConnectionObject ConnectionObject
		{
			get
			{
				return m_theConnectionObject;
			}
		}

		#endregion

		#region Methods

		public async Task Process(string sMessage)
		{
			await SendMessage(await OnProcess(sMessage));
		}

	    protected abstract Task<string> OnProcess(string sMessage);

		protected Task<string> GetMessage(int nReturnCode, string sMessage)
		{
			return Task.FromResult(string.Format("{0} {1}\r\n", nReturnCode, sMessage));
		}

		protected string GetPath(string sPath)
		{
			if (sPath.Length == 0)
			{
				return m_theConnectionObject.CurrentDirectory;
			}

			sPath = sPath.Replace('/', '\\');

			return Path.Combine(m_theConnectionObject.CurrentDirectory, sPath);
		}

		protected async Task SendMessage(string sMessage)
		{
		    if (string.IsNullOrEmpty(sMessage))
		        return;

		    int nEndIndex = sMessage.IndexOf('\r');

			if (nEndIndex < 0)
			{
				FtpServerMessageHandler.SendMessage(m_theConnectionObject.Id, sMessage);
			}
			else
			{
				FtpServerMessageHandler.SendMessage(m_theConnectionObject.Id, sMessage.Substring(0, nEndIndex));
			}

            await Assemblies.General.SocketHelpers.Send(ConnectionObject.Socket, sMessage);
		}

		#endregion
	}
}
