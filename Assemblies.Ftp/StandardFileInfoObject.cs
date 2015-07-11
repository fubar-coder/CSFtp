using System;

namespace Assemblies.Ftp.FileSystem
{
	class StandardFileInfoObject : Assemblies.General.LoadedClass, IFileInfo
	{
		#region Member Variables

		private System.IO.FileInfo m_theInfo = null;

		#endregion

		#region Construction

		public StandardFileInfoObject(string sPath)
		{
			try
			{
				m_theInfo = new System.IO.FileInfo(sPath);
				m_fLoaded = true;
			}
			catch (System.IO.IOException)
			{
				m_theInfo = null;
			}
		}

		#endregion

		#region IFileInfo Members

		public bool IsDirectory()
		{
			return (m_theInfo.Attributes & System.IO.FileAttributes.Directory) != 0;
		}

		public DateTime GetModifiedTime()
		{
			return m_theInfo.LastWriteTime;
		}

		public long GetSize()
		{
			return m_theInfo.Length;
		}

		public string GetAttributeString()
		{
			bool fDirectory = (m_theInfo.Attributes & System.IO.FileAttributes.Directory) != 0;
			bool fReadOnly = (m_theInfo.Attributes & System.IO.FileAttributes.ReadOnly) != 0;

			System.Text.StringBuilder builder = new System.Text.StringBuilder();
			
			if (fDirectory)
			{
				builder.Append("d");
			}
			else
			{
				builder.Append("-");
			}

			builder.Append("r");
			
			if (fReadOnly)
			{
				builder.Append("-");
			}
			else
			{
				builder.Append("w");
			}

			if (fDirectory)
			{
				builder.Append("x");
			}
			else
			{
				builder.Append("-");
			}

			if (fDirectory)
			{
				builder.Append("r-xr-x");
			}
			else
			{
				builder.Append("r--r--");
			}

			return builder.ToString();
		}

		#endregion
	}
}
