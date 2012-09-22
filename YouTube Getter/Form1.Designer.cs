//INSTANT C# NOTE: Formerly VB project-level imports:
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;

namespace YouTube_Getter
{
	[Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
	public partial class Form1 : System.Windows.Forms.Form
	{

		//Form overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]
		protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && components != null)
				{
					components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;

		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.  
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.oldOutLink = new System.Windows.Forms.TextBox();
            this.oldButton1GetInfo = new System.Windows.Forms.Button();
            this.oldTextBox1 = new System.Windows.Forms.TextBox();
            this.oldLinkText = new System.Windows.Forms.TextBox();
            this.oldtxtData = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.oldprogressBar1 = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbProgress = new System.Windows.Forms.Label();
            this.oldbtnDownload = new System.Windows.Forms.Button();
            this.oldbutton2Save = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.saveDiag1 = new System.Windows.Forms.SaveFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBox1title = new System.Windows.Forms.TextBox();
            this.textBox1artist = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // oldOutLink
            // 
            this.oldOutLink.Location = new System.Drawing.Point(12, 72);
            this.oldOutLink.Name = "oldOutLink";
            this.oldOutLink.Size = new System.Drawing.Size(260, 20);
            this.oldOutLink.TabIndex = 0;
            this.oldOutLink.Visible = false;
            // 
            // oldButton1GetInfo
            // 
            this.oldButton1GetInfo.BackColor = System.Drawing.SystemColors.Control;
            this.oldButton1GetInfo.Location = new System.Drawing.Point(79, 74);
            this.oldButton1GetInfo.Name = "oldButton1GetInfo";
            this.oldButton1GetInfo.Size = new System.Drawing.Size(75, 23);
            this.oldButton1GetInfo.TabIndex = 1;
            this.oldButton1GetInfo.Text = "Get Info";
            this.oldButton1GetInfo.UseVisualStyleBackColor = false;
            this.oldButton1GetInfo.Visible = false;
            this.oldButton1GetInfo.Click += new System.EventHandler(this.Button1_Click);
            // 
            // oldTextBox1
            // 
            this.oldTextBox1.Location = new System.Drawing.Point(144, 5);
            this.oldTextBox1.Name = "oldTextBox1";
            this.oldTextBox1.Size = new System.Drawing.Size(423, 20);
            this.oldTextBox1.TabIndex = 2;
            this.oldTextBox1.Visible = false;
            // 
            // oldLinkText
            // 
            this.oldLinkText.Location = new System.Drawing.Point(173, 132);
            this.oldLinkText.Name = "oldLinkText";
            this.oldLinkText.Size = new System.Drawing.Size(240, 20);
            this.oldLinkText.TabIndex = 4;
            this.oldLinkText.Visible = false;
            // 
            // oldtxtData
            // 
            this.oldtxtData.BackColor = System.Drawing.SystemColors.Control;
            this.oldtxtData.Location = new System.Drawing.Point(123, 116);
            this.oldtxtData.Name = "oldtxtData";
            this.oldtxtData.Size = new System.Drawing.Size(444, 20);
            this.oldtxtData.TabIndex = 12;
            this.oldtxtData.Text = "0";
            this.oldtxtData.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Gold;
            this.label4.Location = new System.Drawing.Point(58, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Paste YouTube Url Here";
            this.label4.Visible = false;
            // 
            // oldprogressBar1
            // 
            this.oldprogressBar1.BackColor = System.Drawing.SystemColors.Control;
            this.oldprogressBar1.ForeColor = System.Drawing.Color.LawnGreen;
            this.oldprogressBar1.Location = new System.Drawing.Point(11, 158);
            this.oldprogressBar1.Name = "oldprogressBar1";
            this.oldprogressBar1.Size = new System.Drawing.Size(522, 23);
            this.oldprogressBar1.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Gold;
            this.label5.Location = new System.Drawing.Point(43, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "PROGRESS";
            this.label5.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Gold;
            this.label6.Location = new System.Drawing.Point(9, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "DATA IN MEMORY";
            this.label6.Visible = false;
            // 
            // lbProgress
            // 
            this.lbProgress.AutoSize = true;
            this.lbProgress.Location = new System.Drawing.Point(352, 139);
            this.lbProgress.Name = "lbProgress";
            this.lbProgress.Size = new System.Drawing.Size(24, 13);
            this.lbProgress.TabIndex = 17;
            this.lbProgress.Text = "0/0";
            this.lbProgress.Visible = false;
            // 
            // oldbtnDownload
            // 
            this.oldbtnDownload.BackColor = System.Drawing.SystemColors.Control;
            this.oldbtnDownload.Location = new System.Drawing.Point(315, 69);
            this.oldbtnDownload.Name = "oldbtnDownload";
            this.oldbtnDownload.Size = new System.Drawing.Size(119, 23);
            this.oldbtnDownload.TabIndex = 18;
            this.oldbtnDownload.Text = "DOWNLOAD NOW";
            this.oldbtnDownload.UseVisualStyleBackColor = false;
            this.oldbtnDownload.Visible = false;
            this.oldbtnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // oldbutton2Save
            // 
            this.oldbutton2Save.BackColor = System.Drawing.SystemColors.Control;
            this.oldbutton2Save.Location = new System.Drawing.Point(462, 69);
            this.oldbutton2Save.Name = "oldbutton2Save";
            this.oldbutton2Save.Size = new System.Drawing.Size(105, 23);
            this.oldbutton2Save.TabIndex = 19;
            this.oldbutton2Save.Text = "SAVE TO FILE";
            this.oldbutton2Save.UseVisualStyleBackColor = false;
            this.oldbutton2Save.Visible = false;
            this.oldbutton2Save.Click += new System.EventHandler(this.button2_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Gold;
            this.label7.Location = new System.Drawing.Point(12, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "STEP 1";
            this.label7.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "No URL Chosen";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(26, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Drop URL (mp3)";
            // 
            // listBox1
            // 
            this.listBox1.AllowDrop = true;
            this.listBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(11, 57);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(261, 82);
            this.listBox1.TabIndex = 22;
            this.listBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox1_DragDrop);
            this.listBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox1_DragEnter);
            // 
            // textBox1title
            // 
            this.textBox1title.Location = new System.Drawing.Point(45, 6);
            this.textBox1title.MaxLength = 30;
            this.textBox1title.Name = "textBox1title";
            this.textBox1title.Size = new System.Drawing.Size(492, 20);
            this.textBox1title.TabIndex = 0;
            // 
            // textBox1artist
            // 
            this.textBox1artist.Location = new System.Drawing.Point(45, 28);
            this.textBox1artist.MaxLength = 30;
            this.textBox1artist.Name = "textBox1artist";
            this.textBox1artist.Size = new System.Drawing.Size(492, 20);
            this.textBox1artist.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Title:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Artist:";
            // 
            // listBox2
            // 
            this.listBox2.AllowDrop = true;
            this.listBox2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(276, 57);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(261, 82);
            this.listBox2.TabIndex = 26;
            this.listBox2.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox2_DragDrop);
            this.listBox2.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox2_DragEnter);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label9.Enabled = false;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(278, 83);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(250, 33);
            this.label9.TabIndex = 27;
            this.label9.Text = " Drop URL (video)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(434, 142);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(105, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "Clay Schubiner 2010";
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(545, 190);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1artist);
            this.Controls.Add(this.textBox1title);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.oldbutton2Save);
            this.Controls.Add(this.oldbtnDownload);
            this.Controls.Add(this.lbProgress);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.oldprogressBar1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.oldtxtData);
            this.Controls.Add(this.oldLinkText);
            this.Controls.Add(this.oldTextBox1);
            this.Controls.Add(this.oldButton1GetInfo);
            this.Controls.Add(this.oldOutLink);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "YouTube Downloader";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		internal System.Windows.Forms.TextBox oldOutLink;
		internal System.Windows.Forms.Button oldButton1GetInfo;
        internal System.Windows.Forms.TextBox oldTextBox1;
        internal System.Windows.Forms.TextBox oldLinkText;
		internal System.Windows.Forms.TextBox oldtxtData;
        private Label label4;
        private ProgressBar oldprogressBar1;
        private Label label5;
        private Label label6;
        private Label lbProgress;
        private Button oldbtnDownload;
        private Button oldbutton2Save;
        private Label label7;
        private SaveFileDialog saveDiag1;
        private Label label1;
        private ListBox listBox1;
        private Label label2;
        private TextBox textBox1title;
        private TextBox textBox1artist;
        private Label label3;
        private Label label8;
        private ListBox listBox2;
        private Label label9;
        private Label label10;

	}

} //end of root namespace