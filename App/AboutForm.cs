using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace CSFtp
{
	/// <summary>
	/// Summary description for AboutForm.
	/// </summary>
	public class AboutForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button m_buttonCancel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AboutForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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
			this.m_buttonCancel = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// m_buttonCancel
			// 
			this.m_buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.m_buttonCancel.Location = new System.Drawing.Point(106, 120);
			this.m_buttonCancel.Name = "m_buttonCancel";
			this.m_buttonCancel.TabIndex = 0;
			this.m_buttonCancel.Text = "Cancel";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(10, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(272, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "C# FTP Server";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(10, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(272, 24);
			this.label2.TabIndex = 1;
			this.label2.Text = "Author : David McClarnon";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(10, 80);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(272, 24);
			this.label3.TabIndex = 1;
			this.label3.Text = "Email : dmcclarnon@ntlworld.com";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// AboutForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.m_buttonCancel;
			this.ClientSize = new System.Drawing.Size(292, 152);
			this.ControlBox = false;
			this.Controls.Add(this.label1);
			this.Controls.Add(this.m_buttonCancel);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "AboutForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "About C# FTP Server";
			this.ResumeLayout(false);

		}
		#endregion
	}
}
