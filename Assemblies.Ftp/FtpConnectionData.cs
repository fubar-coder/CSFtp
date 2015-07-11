using System;

namespace Assemblies.Ftp
{
	/// <summary>
	/// Contains all the data relating to a particular FTP connection
	/// </summary>
	class FtpConnectionData
	{
		#region Member Variables

		private System.Net.Sockets.TcpClient m_theSocket = null;
		private int m_nId = 0;
		private string m_sCurrentDirectory = "\\";
		private string m_sPortCommandSocketAddress = "";
		private int m_nPortCommandSocketPort = 20;
		private bool m_fBinary = false;
		private System.Net.Sockets.TcpClient m_socketPasv = null;
		private string m_sRenameFileOldName;
		private bool m_fRenameDirectory = false;
		private string m_sUser;
		private FileSystem.IFileSystem m_fileSystem = null;
		
		#endregion

		#region Construction
		
		public FtpConnectionData(int nId, System.Net.Sockets.TcpClient socket)
		{
			m_nId = nId;
			m_theSocket = socket;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Main connection socket
		/// </summary>
		public System.Net.Sockets.TcpClient Socket
		{
			get
			{
				return m_theSocket;
			}
		}

		public string User
		{
			get
			{
				return m_sUser;
			}

			set
			{
				m_sUser = value;
			}
		}

		/// <summary>
		/// This connection's current directory
		/// </summary>
		public string CurrentDirectory
		{
			get
			{
				return m_sCurrentDirectory;
			}

			set
			{
				m_sCurrentDirectory = value;
			}
		}

		/// <summary>
		/// This connection's Id
		/// </summary>
		public int Id
		{
			get
			{
				return m_nId;
			}
		}

		/// <summary>
		/// Socket address from PORT command.
		/// See FtpReplySocket class.
		/// </summary>
		public string PortCommandSocketAddress
		{
			get
			{
				return m_sPortCommandSocketAddress;
			}

			set
			{
				m_sPortCommandSocketAddress = value;
			}
		}

		/// <summary>
		/// Port from PORT command.
		/// See FtpReplySocket class.
		/// </summary>
		public int PortCommandSocketPort
		{
			get
			{
				return m_nPortCommandSocketPort;
			}

			set
			{
				m_nPortCommandSocketPort = value;
			}
		}

		/// <summary>
		/// Whether the connection is in binary or ASCII transfer mode.
		/// </summary>
		public bool BinaryMode
		{
			get
			{
				return m_fBinary;
			}

			set
			{
				m_fBinary = value;
			}
		}

		/// <summary>
		/// If this is non-null the last command was a PASV and should therefore use this socket.
		/// If this is null the last command was a PORT command and should therefore use that mechanism instead.
		/// </summary>
		public System.Net.Sockets.TcpClient PasvSocket
		{
			get
			{
				return m_socketPasv;
			}

			set
			{
				m_socketPasv = value;
			}
		}

		/// <summary>
		/// Rename takes place with 2 commands - we store the old name here
		/// </summary>
		public string FileToRename
		{
			get
			{
				return m_sRenameFileOldName;
			}

			set
			{
				m_sRenameFileOldName = value;
			}
		}

		/// <summary>
		/// This is true if the file to rename is a directory
		/// </summary>
		public bool RenameDirectory
		{
			get
			{
				return m_fRenameDirectory;
			}

			set
			{
				m_fRenameDirectory = value;
			}
		}

		public FileSystem.IFileSystem FileSystemObject
		{
			get
			{
				return m_fileSystem;
			}
		}

		protected void SetFileSystemObject(FileSystem.IFileSystem fileSystem)
		{
			m_fileSystem = fileSystem;
		}

		#endregion
	}
}
