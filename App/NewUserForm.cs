using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace CSFtp
{
	public class NewUserForm : System.Windows.Forms.Form
	{
		#region Member Variables

		private System.Windows.Forms.TextBox m_textBoxUserName;
		private System.Windows.Forms.Button m_buttonOK;
		private System.Windows.Forms.Button m_buttonCancel;
		private System.Windows.Forms.Label m_labelName;
		private System.ComponentModel.Container components = null;

		#endregion

		#region Construction

		public NewUserForm()
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
			this.m_labelName = new System.Windows.Forms.Label();
			this.m_textBoxUserName = new System.Windows.Forms.TextBox();
			this.m_buttonOK = new System.Windows.Forms.Button();
			this.m_buttonCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// m_labelName
			// 
			this.m_labelName.Location = new System.Drawing.Point(8, 10);
			this.m_labelName.Name = "m_labelName";
			this.m_labelName.Size = new System.Drawing.Size(48, 16);
			this.m_labelName.TabIndex = 0;
			this.m_labelName.Text = "&Name:";
			// 
			// m_textBoxUserName
			// 
			this.m_textBoxUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_textBoxUserName.Location = new System.Drawing.Point(64, 8);
			this.m_textBoxUserName.Name = "m_textBoxUserName";
			this.m_textBoxUserName.Size = new System.Drawing.Size(192, 20);
			this.m_textBoxUserName.TabIndex = 1;
			this.m_textBoxUserName.Text = "";
			// 
			// m_buttonOK
			// 
			this.m_buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.m_buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.m_buttonOK.Location = new System.Drawing.Point(104, 40);
			this.m_buttonOK.Name = "m_buttonOK";
			this.m_buttonOK.TabIndex = 2;
			this.m_buttonOK.Text = "OK";
			// 
			// m_buttonCancel
			// 
			this.m_buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.m_buttonCancel.Location = new System.Drawing.Point(184, 40);
			this.m_buttonCancel.Name = "m_buttonCancel";
			this.m_buttonCancel.Size = new System.Drawing.Size(72, 23);
			this.m_buttonCancel.TabIndex = 3;
			this.m_buttonCancel.Text = "Cancel";
			// 
			// NewUserForm
			// 
			this.AcceptButton = this.m_buttonOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.m_buttonCancel;
			this.ClientSize = new System.Drawing.Size(266, 72);
			this.ControlBox = false;
			this.Controls.Add(this.m_buttonCancel);
			this.Controls.Add(this.m_buttonOK);
			this.Controls.Add(this.m_textBoxUserName);
			this.Controls.Add(this.m_labelName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "NewUserForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "New User";
			this.ResumeLayout(false);

		}
		#endregion

		#endregion

		#region Properties

		public string UserName
		{
			get
			{
				return m_textBoxUserName.Text;
			}
		}

		#endregion
	}
}
