using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace CSFtp
{
	public class UserPasswordForm : System.Windows.Forms.Form
	{
		#region Member Variables

		private System.Windows.Forms.Label m_labelPassword;
		private System.Windows.Forms.TextBox m_textBoxPassword;
		private System.Windows.Forms.Button m_buttonOK;
		private System.Windows.Forms.Button m_buttonCancel;
		private System.ComponentModel.Container components = null;

		#endregion

		#region Construction

		public UserPasswordForm()
		{
			InitializeComponent();
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
			this.m_labelPassword = new System.Windows.Forms.Label();
			this.m_textBoxPassword = new System.Windows.Forms.TextBox();
			this.m_buttonOK = new System.Windows.Forms.Button();
			this.m_buttonCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// m_labelPassword
			// 
			this.m_labelPassword.Location = new System.Drawing.Point(8, 10);
			this.m_labelPassword.Name = "m_labelPassword";
			this.m_labelPassword.Size = new System.Drawing.Size(64, 16);
			this.m_labelPassword.TabIndex = 0;
			this.m_labelPassword.Text = "&Password:";
			// 
			// m_textBoxPassword
			// 
			this.m_textBoxPassword.Location = new System.Drawing.Point(80, 8);
			this.m_textBoxPassword.Name = "m_textBoxPassword";
			this.m_textBoxPassword.PasswordChar = '*';
			this.m_textBoxPassword.Size = new System.Drawing.Size(104, 20);
			this.m_textBoxPassword.TabIndex = 1;
			this.m_textBoxPassword.Text = "";
			// 
			// m_buttonOK
			// 
			this.m_buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.m_buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.m_buttonOK.Location = new System.Drawing.Point(32, 40);
			this.m_buttonOK.Name = "m_buttonOK";
			this.m_buttonOK.TabIndex = 2;
			this.m_buttonOK.Text = "OK";
			// 
			// m_buttonCancel
			// 
			this.m_buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.m_buttonCancel.Location = new System.Drawing.Point(112, 40);
			this.m_buttonCancel.Name = "m_buttonCancel";
			this.m_buttonCancel.TabIndex = 3;
			this.m_buttonCancel.Text = "Cancel";
			// 
			// UserPasswordForm
			// 
			this.AcceptButton = this.m_buttonOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.m_buttonCancel;
			this.ClientSize = new System.Drawing.Size(194, 72);
			this.ControlBox = false;
			this.Controls.Add(this.m_buttonCancel);
			this.Controls.Add(this.m_buttonOK);
			this.Controls.Add(this.m_textBoxPassword);
			this.Controls.Add(this.m_labelPassword);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "UserPasswordForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Set User Password";
			this.ResumeLayout(false);

		}
		#endregion

		#endregion

		#region Properties

		public string Password
		{
			get
			{
				return m_textBoxPassword.Text;
			}
		}

		#endregion
	}
}
