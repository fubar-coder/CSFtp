using System;
using System.Diagnostics;

namespace Assemblies.Ftp
{
	/// <summary>
	/// Contains the socket read functionality. Works on its own thread since all socket operation is blocking.
	/// </summary>
	class FtpSocketHandler
	{
		#region Member Variables

		private System.Net.Sockets.TcpClient m_theSocket = null;
		private System.Threading.Thread m_theThread = null;
		private int m_nId = 0;
		private const int m_nBufferSize = 65536;
		private FtpConnectionObject m_theCommands = null;
		private FileSystem.IFileSystemClassFactory m_fileSystemClassFactory = null;

		#endregion

		#region Events
		
		public delegate void CloseHandler(FtpSocketHandler handler);
		public event CloseHandler Closed;

		#endregion

		#region Construction
		
		public FtpSocketHandler(FileSystem.IFileSystemClassFactory fileSystemClassFactory, int nId)
		{
			m_nId = nId;
			m_fileSystemClassFactory = fileSystemClassFactory;
		}

		#endregion

		#region Methods

		public void Start(System.Net.Sockets.TcpClient socket)
		{
			m_theSocket = socket;

			m_theCommands = new Assemblies.Ftp.FtpConnectionObject(m_fileSystemClassFactory, m_nId, socket);
			m_theThread = new System.Threading.Thread(new System.Threading.ThreadStart(this.ThreadRun));
			m_theThread.Start();
		}

		public void Stop()
		{
			Assemblies.General.SocketHelpers.Close(m_theSocket);
			m_theThread.Join();
		}

		private void ThreadRun()
		{
			Byte [] abData = new Byte[m_nBufferSize];

			try
			{
				int nReceived = m_theSocket.GetStream().Read(abData, 0, m_nBufferSize);

				while (nReceived > 0)
				{
					m_theCommands.Process(abData);

					nReceived = m_theSocket.GetStream().Read(abData, 0, m_nBufferSize);
				}
			}
			catch (System.Net.Sockets.SocketException)
			{
			}
			catch (System.IO.IOException)
			{
			}

			FtpServerMessageHandler.SendMessage(m_nId, "Connection closed");

			if (Closed != null)
			{
				Closed(this);
			}

			m_theSocket.Close();
		}

		#endregion

		#region Properties
	
		public int Id
		{
			get
			{
				return m_nId;
			}
		}

		#endregion
	}
}
