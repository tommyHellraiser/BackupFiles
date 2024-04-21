namespace BackupFiles
{
	partial class HomeScreen
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeScreen));
			lblOriginDirectory = new Label();
			lblShowOriginDirectory = new Label();
			btnChangeOrigin = new Button();
			btnChangeDestination = new Button();
			lblShowDestinationDirectory = new Label();
			lblDestinationDirectory = new Label();
			btnRunBackupNow = new Button();
			btnScheduleTask = new Button();
			btnSaveConfiguration = new Button();
			folderBrowserDialog1 = new FolderBrowserDialog();
			SuspendLayout();
			// 
			// lblOriginDirectory
			// 
			lblOriginDirectory.AutoSize = true;
			lblOriginDirectory.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblOriginDirectory.Location = new Point(29, 26);
			lblOriginDirectory.Name = "lblOriginDirectory";
			lblOriginDirectory.Size = new Size(184, 32);
			lblOriginDirectory.TabIndex = 0;
			lblOriginDirectory.Text = "Origin Directory";
			// 
			// lblShowOriginDirectory
			// 
			lblShowOriginDirectory.BackColor = SystemColors.ButtonFace;
			lblShowOriginDirectory.BorderStyle = BorderStyle.Fixed3D;
			lblShowOriginDirectory.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblShowOriginDirectory.Location = new Point(29, 58);
			lblShowOriginDirectory.Name = "lblShowOriginDirectory";
			lblShowOriginDirectory.Size = new Size(378, 32);
			lblShowOriginDirectory.TabIndex = 1;
			lblShowOriginDirectory.Text = "Example";
			// 
			// btnChangeOrigin
			// 
			btnChangeOrigin.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnChangeOrigin.Location = new Point(29, 93);
			btnChangeOrigin.Name = "btnChangeOrigin";
			btnChangeOrigin.Size = new Size(175, 36);
			btnChangeOrigin.TabIndex = 2;
			btnChangeOrigin.Text = "Change folder";
			btnChangeOrigin.UseVisualStyleBackColor = true;
			btnChangeOrigin.Click += btnChangeOrigin_Click;
			// 
			// btnChangeDestination
			// 
			btnChangeDestination.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnChangeDestination.Location = new Point(29, 231);
			btnChangeDestination.Name = "btnChangeDestination";
			btnChangeDestination.Size = new Size(175, 36);
			btnChangeDestination.TabIndex = 5;
			btnChangeDestination.Text = "Change folder";
			btnChangeDestination.UseVisualStyleBackColor = true;
			btnChangeDestination.Click += btnChangeDestination_Click;
			// 
			// lblShowDestinationDirectory
			// 
			lblShowDestinationDirectory.BackColor = SystemColors.ButtonFace;
			lblShowDestinationDirectory.BorderStyle = BorderStyle.Fixed3D;
			lblShowDestinationDirectory.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblShowDestinationDirectory.Location = new Point(29, 196);
			lblShowDestinationDirectory.Name = "lblShowDestinationDirectory";
			lblShowDestinationDirectory.Size = new Size(378, 32);
			lblShowDestinationDirectory.TabIndex = 4;
			lblShowDestinationDirectory.Text = "Example";
			// 
			// lblDestinationDirectory
			// 
			lblDestinationDirectory.AutoSize = true;
			lblDestinationDirectory.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblDestinationDirectory.Location = new Point(29, 164);
			lblDestinationDirectory.Name = "lblDestinationDirectory";
			lblDestinationDirectory.Size = new Size(240, 32);
			lblDestinationDirectory.TabIndex = 3;
			lblDestinationDirectory.Text = "Destination Directory";
			// 
			// btnRunBackupNow
			// 
			btnRunBackupNow.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnRunBackupNow.Location = new Point(29, 404);
			btnRunBackupNow.Name = "btnRunBackupNow";
			btnRunBackupNow.Size = new Size(207, 48);
			btnRunBackupNow.TabIndex = 6;
			btnRunBackupNow.Text = "Backup now!";
			btnRunBackupNow.UseVisualStyleBackColor = true;
			btnRunBackupNow.Click += btnRunBackupNow_Click;
			// 
			// btnScheduleTask
			// 
			btnScheduleTask.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnScheduleTask.Location = new Point(29, 350);
			btnScheduleTask.Name = "btnScheduleTask";
			btnScheduleTask.Size = new Size(207, 48);
			btnScheduleTask.TabIndex = 7;
			btnScheduleTask.Text = "Schedule task";
			btnScheduleTask.UseVisualStyleBackColor = true;
			btnScheduleTask.Click += btnScheduleTask_Click;
			// 
			// btnSaveConfiguration
			// 
			btnSaveConfiguration.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnSaveConfiguration.Location = new Point(29, 296);
			btnSaveConfiguration.Name = "btnSaveConfiguration";
			btnSaveConfiguration.Size = new Size(207, 48);
			btnSaveConfiguration.TabIndex = 8;
			btnSaveConfiguration.Text = "Save configuration";
			btnSaveConfiguration.UseVisualStyleBackColor = true;
			btnSaveConfiguration.Click += btnSaveConfiguration_Click;
			// 
			// HomeScreen
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.ActiveCaption;
			ClientSize = new Size(444, 475);
			Controls.Add(btnSaveConfiguration);
			Controls.Add(btnScheduleTask);
			Controls.Add(btnRunBackupNow);
			Controls.Add(btnChangeDestination);
			Controls.Add(lblShowDestinationDirectory);
			Controls.Add(lblDestinationDirectory);
			Controls.Add(btnChangeOrigin);
			Controls.Add(lblShowOriginDirectory);
			Controls.Add(lblOriginDirectory);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Icon = (Icon)resources.GetObject("$this.Icon");
			MaximizeBox = false;
			Name = "HomeScreen";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Backer Upper";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label lblOriginDirectory;
		private Label lblShowOriginDirectory;
		private Button btnChangeOrigin;
		private Button btnChangeDestination;
		private Label lblShowDestinationDirectory;
		private Label lblDestinationDirectory;
		private Button btnRunBackupNow;
		private Button btnScheduleTask;
		private Button btnSaveConfiguration;
		private FolderBrowserDialog folderBrowserDialog1;
	}
}
