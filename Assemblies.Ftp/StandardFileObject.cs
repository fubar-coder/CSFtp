using System;

namespace Assemblies.Ftp.FileSystem
{
	class StandardFileObject : Assemblies.General.LoadedClass, IFile
	{
		private System.IO.FileStream m_theFile = null;
		
		public StandardFileObject(string sPath, bool fWrite)
		{
			try
			{
				m_theFile = new System.IO.FileStream(sPath, 
					(fWrite) ? System.IO.FileMode.OpenOrCreate : System.IO.FileMode.Open, 
					(fWrite) ? System.IO.FileAccess.Write : System.IO.FileAccess.Read);

				if (fWrite)
				{
					m_theFile.Seek(0, System.IO.SeekOrigin.End);
				}

				m_fLoaded = true;
			}
			catch (System.IO.IOException)
			{
				m_theFile = null;
			}
		}

		#region IFile Members

		public int Read(byte[] abData, int nDataSize)
		{
			if (m_theFile == null)
			{
				return 0;
			}

			try
			{
				return m_theFile.Read(abData, 0, nDataSize);
			}
			catch (System.IO.IOException)
			{
				return 0;
			}
		}

		public int Write(byte[] abData, int nDataSize)
		{
			if (m_theFile == null)
			{
				return 0;
			}

			try
			{
				m_theFile.Write(abData, 0, nDataSize);
			}
			catch (System.IO.IOException)
			{
				return 0;
			}

			return nDataSize;
		}

		public void Close()
		{
			if (m_theFile != null)
			{
				try
				{
					m_theFile.Close();
				}
				catch (System.IO.IOException)
				{
				}

				m_theFile = null;
			}
		}

		#endregion
	}
}
