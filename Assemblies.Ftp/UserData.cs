using System;
using System.IO;

namespace Assemblies.Ftp
{
	[Serializable]
	class UserDataItem
	{
		private string m_sPassword = "";
		private string m_sStartingDirectory = "C:\\";

		public UserDataItem()
		{
		}

		public string Password
		{
			get
			{
				return m_sPassword;
			}

			set
			{
				m_sPassword = value;
			}
		}

		public string StartingDirectory
		{
			get
			{
				return m_sStartingDirectory;
			}

			set
			{
				m_sStartingDirectory = value;
			}
		}
	}

	public class UserData
	{
		#region Member Variables

		private System.Collections.Hashtable m_mapUserToData = null;

		static private UserData m_theObject = null;

		#endregion

		#region Construction
		
		protected UserData()
		{
			m_mapUserToData = new System.Collections.Hashtable();
		}

		#endregion

		#region Properties

		static public UserData Get()
		{
			if (m_theObject == null)
			{
				m_theObject = new UserData();
			}

			return m_theObject;
		}

		public string [] Users
		{
			get
			{
				System.Collections.ICollection collectionUsers = m_mapUserToData.Keys;
				string [] asUsers = new string[collectionUsers.Count];

				int nIndex = 0;
				
				foreach (string sUser in collectionUsers)
				{
					asUsers[nIndex] = sUser;
					nIndex++;
				}

				return asUsers;
			}
		}

		public int UserCount
		{
			get
			{
				return m_mapUserToData.Count;
			}
		}

		#endregion

		#region Methods

		private UserDataItem GetUserItem(string sUser)
		{
			return m_mapUserToData[sUser] as UserDataItem;
		}

		public void AddUser(string sUser)
		{
			m_mapUserToData.Add(sUser, new UserDataItem());
		}

		public void RemoveUser(string sUser)
		{
			m_mapUserToData.Remove(sUser);
		}

		public string GetUserPassword(string sUser)
		{
			UserDataItem item = GetUserItem(sUser);

			if (item != null)
			{
				return item.Password;
			}
			else
			{
				return "";
			}
		}

		public void SetUserPassword(string sUser, string sPassword)
		{
			UserDataItem item = GetUserItem(sUser);

			if (item != null)
			{
				item.Password = sPassword;
			}
		}

		public string GetUserStartingDirectory(string sUser)
		{
			UserDataItem item = GetUserItem(sUser);

			if (item != null)
			{
				return item.StartingDirectory;
			}
			else
			{
				return "C:\\";
			}
		}

		public void SetUserStartingDirectory(string sUser, string sDirectory)
		{
			UserDataItem item = GetUserItem(sUser);

			if (item != null)
			{
				item.StartingDirectory = sDirectory;
			}
		}

		public bool HasUser(string sUser)
		{
			UserDataItem item = GetUserItem(sUser);
			return item != null;
		}

		public bool Save(string sFileName)
		{
			try
			{
				System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
				System.IO.FileStream fileStream = new System.IO.FileStream(sFileName, System.IO.FileMode.Create);
				formatter.Serialize(fileStream, m_mapUserToData);
				fileStream.Close();
			}
			catch (System.IO.IOException)
			{
				return false;
			}

			return true;
		}

		public bool Load(string sFileName)
		{
			if (!System.IO.File.Exists(sFileName))
			{
				return true;
			}

			try
			{
				System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
				System.IO.FileStream fileStream = new System.IO.FileStream(sFileName, System.IO.FileMode.Open);
				m_mapUserToData = formatter.Deserialize(fileStream) as System.Collections.Hashtable;
			}
			catch (System.IO.IOException)
			{
				return false;
			}

			return true;
		}

		private string GetDefaultPath()
		{
			return Path.Combine(System.Windows.Forms.Application.StartupPath, "Users.dat");
		}

		public bool Save()
		{
			return Save(GetDefaultPath());
		}

		public bool Load()
		{
			return Load(GetDefaultPath());
		}

		#endregion
	}
}
