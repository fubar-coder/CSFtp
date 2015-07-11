using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace CSFtp
{
	public class UsersForm : System.Windows.Forms.Form
	{
		#region Member Variables

		private System.Windows.Forms.ColumnHeader m_columnHeaderUser;
		private System.Windows.Forms.ColumnHeader m_columnHeaderDirectory;
		private System.Windows.Forms.Button m_buttonAddUser;
		private System.Windows.Forms.GroupBox m_groupBoxUsers;
		private System.Windows.Forms.Button m_buttonRemoveUser;
		private System.Windows.Forms.Button m_buttonPassword;
		private System.Windows.Forms.Button m_buttonStartDirectory;
		private System.Windows.Forms.Button m_buttonOK;
		private System.Windows.Forms.ListView m_listViewUsers;
	
		private System.ComponentModel.Container components = null;

		#endregion

		#region Construction

		public UsersForm()
		{
			InitializeComponent();

			LoadUsers();
		}

		private void LoadUsers()
		{
			string [] asUsers = Assemblies.Ftp.UserData.Get().Users;
			string [] asRow = new string[2];

			for (int nUser = 0; nUser < asUsers.Length; nUser++)
			{
				asRow[0] = asUsers[nUser];
				asRow[1] = Assemblies.Ftp.UserData.Get().GetUserStartingDirectory(asUsers[nUser]);

				m_listViewUsers.Items.Add(new ListViewItem(asRow));
			}
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
			this.m_listViewUsers = new System.Windows.Forms.ListView();
			this.m_columnHeaderUser = new System.Windows.Forms.ColumnHeader();
			this.m_columnHeaderDirectory = new System.Windows.Forms.ColumnHeader();
			this.m_buttonAddUser = new System.Windows.Forms.Button();
			this.m_groupBoxUsers = new System.Windows.Forms.GroupBox();
			this.m_buttonStartDirectory = new System.Windows.Forms.Button();
			this.m_buttonPassword = new System.Windows.Forms.Button();
			this.m_buttonRemoveUser = new System.Windows.Forms.Button();
			this.m_buttonOK = new System.Windows.Forms.Button();
			this.m_groupBoxUsers.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_listViewUsers
			// 
			this.m_listViewUsers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_listViewUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							  this.m_columnHeaderUser,
																							  this.m_columnHeaderDirectory});
			this.m_listViewUsers.FullRowSelect = true;
			this.m_listViewUsers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.m_listViewUsers.HideSelection = false;
			this.m_listViewUsers.Location = new System.Drawing.Point(8, 16);
			this.m_listViewUsers.MultiSelect = false;
			this.m_listViewUsers.Name = "m_listViewUsers";
			this.m_listViewUsers.Size = new System.Drawing.Size(448, 208);
			this.m_listViewUsers.TabIndex = 0;
			this.m_listViewUsers.View = System.Windows.Forms.View.Details;
			// 
			// m_columnHeaderUser
			// 
			this.m_columnHeaderUser.Text = "User";
			this.m_columnHeaderUser.Width = 94;
			// 
			// m_columnHeaderDirectory
			// 
			this.m_columnHeaderDirectory.Text = "Start Directory";
			this.m_columnHeaderDirectory.Width = 347;
			// 
			// m_buttonAddUser
			// 
			this.m_buttonAddUser.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.m_buttonAddUser.Location = new System.Drawing.Point(8, 232);
			this.m_buttonAddUser.Name = "m_buttonAddUser";
			this.m_buttonAddUser.TabIndex = 1;
			this.m_buttonAddUser.Text = "&Add...";
			this.m_buttonAddUser.Click += new System.EventHandler(this.m_buttonAddUser_Click);
			// 
			// m_groupBoxUsers
			// 
			this.m_groupBoxUsers.Controls.Add(this.m_buttonStartDirectory);
			this.m_groupBoxUsers.Controls.Add(this.m_buttonPassword);
			this.m_groupBoxUsers.Controls.Add(this.m_buttonRemoveUser);
			this.m_groupBoxUsers.Controls.Add(this.m_listViewUsers);
			this.m_groupBoxUsers.Controls.Add(this.m_buttonAddUser);
			this.m_groupBoxUsers.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.m_groupBoxUsers.Location = new System.Drawing.Point(8, 8);
			this.m_groupBoxUsers.Name = "m_groupBoxUsers";
			this.m_groupBoxUsers.Size = new System.Drawing.Size(464, 264);
			this.m_groupBoxUsers.TabIndex = 0;
			this.m_groupBoxUsers.TabStop = false;
			this.m_groupBoxUsers.Text = "&Users";
			// 
			// m_buttonStartDirectory
			// 
			this.m_buttonStartDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.m_buttonStartDirectory.Location = new System.Drawing.Point(376, 232);
			this.m_buttonStartDirectory.Name = "m_buttonStartDirectory";
			this.m_buttonStartDirectory.TabIndex = 4;
			this.m_buttonStartDirectory.Text = "Directory...";
			this.m_buttonStartDirectory.Click += new System.EventHandler(this.m_buttonStartDirectory_Click);
			// 
			// m_buttonPassword
			// 
			this.m_buttonPassword.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.m_buttonPassword.Location = new System.Drawing.Point(296, 232);
			this.m_buttonPassword.Name = "m_buttonPassword";
			this.m_buttonPassword.TabIndex = 3;
			this.m_buttonPassword.Text = "&Password...";
			this.m_buttonPassword.Click += new System.EventHandler(this.m_buttonPassword_Click);
			// 
			// m_buttonRemoveUser
			// 
			this.m_buttonRemoveUser.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.m_buttonRemoveUser.Location = new System.Drawing.Point(88, 232);
			this.m_buttonRemoveUser.Name = "m_buttonRemoveUser";
			this.m_buttonRemoveUser.Size = new System.Drawing.Size(75, 24);
			this.m_buttonRemoveUser.TabIndex = 2;
			this.m_buttonRemoveUser.Text = "Remove";
			this.m_buttonRemoveUser.Click += new System.EventHandler(this.m_buttonRemoveUser_Click);
			// 
			// m_buttonOK
			// 
			this.m_buttonOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.m_buttonOK.Location = new System.Drawing.Point(384, 280);
			this.m_buttonOK.Name = "m_buttonOK";
			this.m_buttonOK.TabIndex = 1;
			this.m_buttonOK.Text = "Close";
			// 
			// UsersForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.m_buttonOK;
			this.ClientSize = new System.Drawing.Size(480, 310);
			this.ControlBox = false;
			this.Controls.Add(this.m_buttonOK);
			this.Controls.Add(this.m_groupBoxUsers);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "UsersForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "UsersForm";
			this.m_groupBoxUsers.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#endregion

		#region Event Handlers

		private void m_buttonAddUser_Click(object sender, System.EventArgs e)
		{
			NewUserForm form = new NewUserForm();

			if (form.ShowDialog() == DialogResult.OK)
			{
				if (form.UserName.Length == 0)
				{
					MessageBox.Show("User name was blank", "CSFtp", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}

				if (Assemblies.Ftp.UserData.Get().HasUser(form.UserName))
				{
					MessageBox.Show("User already exists", "CSFtp", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}

				Assemblies.Ftp.UserData.Get().AddUser(form.UserName);

				string [] asRow = new string[2];
				asRow[0] = form.UserName;
				asRow[1] = "C:\\";
				ListViewItem itemNew = m_listViewUsers.Items.Add(new System.Windows.Forms.ListViewItem(asRow));
				m_listViewUsers.SelectedItems.Clear();
				itemNew.Selected = true;
			}
		}

		private void m_buttonRemoveUser_Click(object sender, System.EventArgs e)
		{
			for (int nIndex = 0 ; nIndex < m_listViewUsers.SelectedItems.Count ; nIndex++)
			{
				ListViewItem item = m_listViewUsers.SelectedItems[nIndex];

				string sUser = item.SubItems[0].Text;
				Assemblies.Ftp.UserData.Get().RemoveUser(sUser);
				m_listViewUsers.Items.Remove(item);
			}
			
			if (m_listViewUsers.SelectedItems.Count == 0)
			{
				MessageBox.Show("Please select a user in the list", "CSFtp");
			}
		}

		private void m_buttonPassword_Click(object sender, System.EventArgs e)
		{
			if (m_listViewUsers.SelectedItems.Count == 1)
			{
				ListViewItem itemSelected = m_listViewUsers.SelectedItems[0];
				UserPasswordForm form = new UserPasswordForm();

				if (form.ShowDialog() == DialogResult.OK)
				{
					Assemblies.Ftp.UserData.Get().SetUserPassword(itemSelected.SubItems[0].Text, form.Password);
				}
			}
			else
			{
				MessageBox.Show("Please select a user in the list", "CSFtp");
			}
		}

		private void m_buttonStartDirectory_Click(object sender, System.EventArgs e)
		{
			if (m_listViewUsers.SelectedItems.Count == 1)
			{
				ListViewItem itemSelected = m_listViewUsers.SelectedItems[0];

				string sUser = itemSelected.SubItems[0].Text;
				string sDirectory = itemSelected.SubItems[1].Text;

				System.Windows.Forms.FolderBrowserDialog formBrowse = new FolderBrowserDialog();
				formBrowse.SelectedPath = sDirectory;
				formBrowse.Description = "Select the folder which this user will log in to";
				formBrowse.ShowNewFolderButton = false;
				
				if (formBrowse.ShowDialog() == DialogResult.OK)
				{
					itemSelected.SubItems[1].Text = formBrowse.SelectedPath;
					Assemblies.Ftp.UserData.Get().SetUserStartingDirectory(sUser, formBrowse.SelectedPath);
				}
			}
			else
			{
				MessageBox.Show("Please select a user in the list", "CSFtp");
			}
		}
		
		#endregion
	}
}
