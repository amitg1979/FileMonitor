namespace FileWatcherDemo
{
	partial class Form1Ex
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.buttonDone = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lstFolderToWatch = new System.Windows.Forms.ListView();
            this.columnFolderPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBoxFolderToWatch = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBrowse.Location = new System.Drawing.Point(411, 16);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(123, 27);
            this.buttonBrowse.TabIndex = 16;
            this.buttonBrowse.Text = "Select Folder";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // buttonDone
            // 
            this.buttonDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDone.Location = new System.Drawing.Point(507, 214);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(87, 27);
            this.buttonDone.TabIndex = 14;
            this.buttonDone.Text = "Done";
            this.buttonDone.UseVisualStyleBackColor = true;
            this.buttonDone.Click += new System.EventHandler(this.buttonDone_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStop.Location = new System.Drawing.Point(323, 214);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(87, 27);
            this.buttonStop.TabIndex = 13;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStart.Location = new System.Drawing.Point(156, 214);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(87, 27);
            this.buttonStart.TabIndex = 12;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Folder to watch";
            // 
            // lstFolderToWatch
            // 
            this.lstFolderToWatch.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnFolderPath,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lstFolderToWatch.FullRowSelect = true;
            this.lstFolderToWatch.GridLines = true;
            this.lstFolderToWatch.LabelWrap = false;
            this.lstFolderToWatch.Location = new System.Drawing.Point(123, 61);
            this.lstFolderToWatch.MultiSelect = false;
            this.lstFolderToWatch.Name = "lstFolderToWatch";
            this.lstFolderToWatch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lstFolderToWatch.Size = new System.Drawing.Size(584, 139);
            this.lstFolderToWatch.TabIndex = 21;
            this.lstFolderToWatch.UseCompatibleStateImageBehavior = false;
            this.lstFolderToWatch.View = System.Windows.Forms.View.List;
            // 
            // columnFolderPath
            // 
            this.columnFolderPath.Text = "Folders to Watch";
            this.columnFolderPath.Width = 200;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Time Interval(ms)";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Include Subfolder";
            this.columnHeader2.Width = 130;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Search Criteria";
            this.columnHeader3.Width = 100;
            // 
            // textBoxFolderToWatch
            // 
            this.textBoxFolderToWatch.Location = new System.Drawing.Point(123, 16);
            this.textBoxFolderToWatch.Name = "textBoxFolderToWatch";
            this.textBoxFolderToWatch.Size = new System.Drawing.Size(250, 21);
            this.textBoxFolderToWatch.TabIndex = 22;
            // 
            // Form1Ex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(728, 270);
            this.Controls.Add(this.textBoxFolderToWatch);
            this.Controls.Add(this.lstFolderToWatch);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.buttonDone);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1Ex";
            this.Text = "Batch  File Monitor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1Ex_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.Button buttonBrowse;
		private System.Windows.Forms.Button buttonDone;
		private System.Windows.Forms.Button buttonStop;
		private System.Windows.Forms.Button buttonStart;
		private System.Windows.Forms.Label label1;
        //private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ListView lstFolderToWatch;
        private System.Windows.Forms.TextBox textBoxFolderToWatch;
        private System.Windows.Forms.ColumnHeader columnFolderPath;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
	}
}