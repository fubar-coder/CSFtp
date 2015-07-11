using System;
using System.IO;

namespace Assemblies.Ftp.FtpCommands
{
	/// <summary>
	/// Base class for all ftp command handlers.
	/// </summary>
	class FtpCommandHandler
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

		public void Process(string sMessage)
		{
			SendMessage(OnProcess(sMessage));
		}

		protected virtual string OnProcess(string sMessage)
		{
			System.Diagnostics.Debug.Assert(false, "FtpCommandHandler::OnProcess base called");
			return "";
		}

		protected string GetMessage(int nReturnCode, string sMessage)
		{
			return string.Format("{0} {1}\r\n", nReturnCode, sMessage);
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

		private void SendMessage(string sMessage)
		{
			if (sMessage.Length == 0)
			{
				return;
			}

			int nEndIndex = sMessage.IndexOf('\r');

			if (nEndIndex < 0)
			{
				FtpServerMessageHandler.SendMessage(m_theConnectionObject.Id, sMessage);
			}
			else
			{
				FtpServerMessageHandler.SendMessage(m_theConnectionObject.Id, sMessage.Substring(0, nEndIndex));
			}

			Assemblies.General.SocketHelpers.Send(ConnectionObject.Socket, sMessage);
		}

		#endregion
	}
}
