using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace CSFtp
{
	/// <summary>
	/// The main form of the application
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		#region Member Variables

		private System.Windows.Forms.MainMenu m_mainMenu;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.ListBox m_listBoxMessages;
		private System.Windows.Forms.MenuItem m_menuItemFile;
		private System.Windows.Forms.MenuItem m_menuItemUsers;
		private System.Windows.Forms.MenuItem m_menuItemExit;
		private System.Windows.Forms.MenuItem m_menuItemHelp;
		private System.Windows.Forms.MenuItem m_menuItemAbout;
		private System.Windows.Forms.TabControl m_tabControlConnections;
		private System.Windows.Forms.TabPage m_tabPageAll;
		private Assemblies.Ftp.FtpServer m_theFtpServer = null;

		private System.ComponentModel.Container components = null;

		#endregion

		#region Construction

		public MainForm()
		{
			InitializeComponent();

			Assemblies.Ftp.FtpServerMessageHandler.Message += new Assemblies.Ftp.FtpServerMessageHandler.MessageEventHandler(MessageHandler_Message);

			m_theFtpServer= new Assemblies.Ftp.FtpServer(new Assemblies.Ftp.FileSystem.StandardFileSystemClassFactory());
			m_theFtpServer.Start();
			m_theFtpServer.ConnectionClosed += new Assemblies.Ftp.FtpServer.ConnectionHandler(m_theFtpServer_ConnectionClosed);
			m_theFtpServer.NewConnection += new Assemblies.Ftp.FtpServer.ConnectionHandler(m_theFtpServer_NewConnection);
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainForm));
			this.m_mainMenu = new System.Windows.Forms.MainMenu();
			this.m_menuItemFile = new System.Windows.Forms.MenuItem();
			this.m_menuItemUsers = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.m_menuItemExit = new System.Windows.Forms.MenuItem();
			this.m_menuItemHelp = new System.Windows.Forms.MenuItem();
			this.m_menuItemAbout = new System.Windows.Forms.MenuItem();
			this.m_listBoxMessages = new System.Windows.Forms.ListBox();
			this.m_tabControlConnections = new System.Windows.Forms.TabControl();
			this.m_tabPageAll = new System.Windows.Forms.TabPage();
			this.m_tabControlConnections.SuspendLayout();
			this.m_tabPageAll.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_mainMenu
			// 
			this.m_mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.m_menuItemFile,
																					   this.m_menuItemHelp});
			// 
			// m_menuItemFile
			// 
			this.m_menuItemFile.Index = 0;
			this.m_menuItemFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						   this.m_menuItemUsers,
																						   this.menuItem4,
																						   this.m_menuItemExit});
			this.m_menuItemFile.Text = "&File";
			// 
			// m_menuItemUsers
			// 
			this.m_menuItemUsers.Index = 0;
			this.m_menuItemUsers.Text = "&Users...";
			this.m_menuItemUsers.Click += new System.EventHandler(this.m_menuItemUsers_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 1;
			this.menuItem4.Text = "-";
			// 
			// m_menuItemExit
			// 
			this.m_menuItemExit.Index = 2;
			this.m_menuItemExit.Text = "&Exit";
			this.m_menuItemExit.Click += new System.EventHandler(this.m_menuItemExit_Click);
			// 
			// m_menuItemHelp
			// 
			this.m_menuItemHelp.Index = 1;
			this.m_menuItemHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						   this.m_menuItemAbout});
			this.m_menuItemHelp.Text = "&Help";
			// 
			// m_menuItemAbout
			// 
			this.m_menuItemAbout.Index = 0;
			this.m_menuItemAbout.Text = "&About...";
			this.m_menuItemAbout.Click += new System.EventHandler(this.m_menuItemAbout_Click);
			// 
			// m_listBoxMessages
			// 
			this.m_listBoxMessages.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_listBoxMessages.IntegralHeight = false;
			this.m_listBoxMessages.Location = new System.Drawing.Point(0, 0);
			this.m_listBoxMessages.Name = "m_listBoxMessages";
			this.m_listBoxMessages.Size = new System.Drawing.Size(472, 228);
			this.m_listBoxMessages.TabIndex = 0;
			// 
			// m_tabControlConnections
			// 
			this.m_tabControlConnections.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
			this.m_tabControlConnections.Controls.Add(this.m_tabPageAll);
			this.m_tabControlConnections.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_tabControlConnections.Location = new System.Drawing.Point(0, 0);
			this.m_tabControlConnections.Name = "m_tabControlConnections";
			this.m_tabControlConnections.SelectedIndex = 0;
			this.m_tabControlConnections.Size = new System.Drawing.Size(480, 257);
			this.m_tabControlConnections.TabIndex = 1;
			// 
			// m_tabPageAll
			// 
			this.m_tabPageAll.Controls.Add(this.m_listBoxMessages);
			this.m_tabPageAll.Location = new System.Drawing.Point(4, 25);
			this.m_tabPageAll.Name = "m_tabPageAll";
			this.m_tabPageAll.Size = new System.Drawing.Size(472, 228);
			this.m_tabPageAll.TabIndex = 0;
			this.m_tabPageAll.Text = "All";
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(480, 257);
			this.Controls.Add(this.m_tabControlConnections);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Menu = this.m_mainMenu;
			this.Name = "MainForm";
			this.Text = "FTP Server";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
			this.m_tabControlConnections.ResumeLayout(false);
			this.m_tabPageAll.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#endregion

		#region Main

		[STAThread]
		static void Main() 
		{
			Assemblies.Ftp.UserData.Get().Load();
			Application.Run(new MainForm());
			Assemblies.Ftp.UserData.Get().Save();
		}

		#endregion

		#region Event Handlers

		private void m_menuItemExit_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			m_theFtpServer.Stop();
		}

		private void MessageHandler_Message(int nId, string sMessage)
		{
			m_listBoxMessages.BeginUpdate();

			int nItem = m_listBoxMessages.Items.Add(string.Format("({0}) <{1}> {2}", nId, System.DateTime.Now, sMessage));

			if (m_listBoxMessages.Items.Count > 5000)
			{
				m_listBoxMessages.Items.RemoveAt(0);
			}

			if (m_listBoxMessages.SelectedIndex < 0)
			{
				m_listBoxMessages.TopIndex = nItem;
			}
			else if (m_listBoxMessages.SelectedIndex == nItem - 1)
			{
				m_listBoxMessages.SelectedIndex = nItem;
			}

			m_listBoxMessages.EndUpdate();
		}

		private void m_theFtpServer_ConnectionClosed(int nId)
		{

		}

		private void m_theFtpServer_NewConnection(int nId)
		{

		}

		private void m_menuItemUsers_Click(object sender, System.EventArgs e)
		{
			UsersForm form = new UsersForm();
			form.ShowDialog();
		}

		private void m_menuItemAbout_Click(object sender, System.EventArgs e)
		{
			AboutForm form = new AboutForm();
			form.ShowDialog();
		}

		#endregion

		
	}
}
