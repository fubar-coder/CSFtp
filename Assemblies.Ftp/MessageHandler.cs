using System;

namespace Assemblies.Ftp
{
	/// <summary>
	/// Gives a mechanism for classes to pass messages to the main form for display 
	/// in the messages list box
	/// </summary>
	public class FtpServerMessageHandler
	{
		public delegate void MessageEventHandler(int nId, string sMessage);
		static public event MessageEventHandler Message;

		protected FtpServerMessageHandler()
		{
		}

		public static void SendMessage(int nId, string sMessage)
		{
			if (Message != null)
			{
				Message(nId, sMessage);
			}
		}
	}
}
