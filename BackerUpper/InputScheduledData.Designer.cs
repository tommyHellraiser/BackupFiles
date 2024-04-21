namespace BackerUpper
{
	partial class InputScheduledData
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
			lblTaskName = new Label();
			txtTaskName = new TextBox();
			lblTrigger = new Label();
			cboTrigger = new ComboBox();
			txtInterval = new TextBox();
			lblInterval = new Label();
			dtmRunAt = new DateTimePicker();
			lblRunAt = new Label();
			btnCreate = new Button();
			SuspendLayout();
			// 
			// lblTaskName
			// 
			lblTaskName.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblTaskName.Location = new Point(33, 18);
			lblTaskName.Name = "lblTaskName";
			lblTaskName.Size = new Size(200, 31);
			lblTaskName.TabIndex = 0;
			lblTaskName.Text = "Task name";
			// 
			// txtTaskName
			// 
			txtTaskName.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			txtTaskName.ForeColor = SystemColors.WindowText;
			txtTaskName.Location = new Point(33, 52);
			txtTaskName.Name = "txtTaskName";
			txtTaskName.Size = new Size(234, 35);
			txtTaskName.TabIndex = 1;
			// 
			// lblTrigger
			// 
			lblTrigger.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblTrigger.Location = new Point(33, 90);
			lblTrigger.Name = "lblTrigger";
			lblTrigger.Size = new Size(200, 31);
			lblTrigger.TabIndex = 2;
			lblTrigger.Text = "Trigger";
			// 
			// cboTrigger
			// 
			cboTrigger.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			cboTrigger.FormattingEnabled = true;
			cboTrigger.Items.AddRange(new object[] { "On Startup", "Daily", "Weekly" });
			cboTrigger.Location = new Point(33, 124);
			cboTrigger.Name = "cboTrigger";
			cboTrigger.Size = new Size(234, 38);
			cboTrigger.TabIndex = 4;
			cboTrigger.SelectedIndexChanged += cboTrigger_SelectedIndexChanged;
			// 
			// txtInterval
			// 
			txtInterval.Enabled = false;
			txtInterval.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			txtInterval.ForeColor = SystemColors.WindowText;
			txtInterval.Location = new Point(33, 199);
			txtInterval.Name = "txtInterval";
			txtInterval.Size = new Size(234, 35);
			txtInterval.TabIndex = 6;
			// 
			// lblInterval
			// 
			lblInterval.Enabled = false;
			lblInterval.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblInterval.Location = new Point(33, 165);
			lblInterval.Name = "lblInterval";
			lblInterval.Size = new Size(200, 31);
			lblInterval.TabIndex = 5;
			lblInterval.Text = "Interval";
			// 
			// dtmRunAt
			// 
			dtmRunAt.Enabled = false;
			dtmRunAt.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			dtmRunAt.Format = DateTimePickerFormat.Time;
			dtmRunAt.Location = new Point(33, 271);
			dtmRunAt.Name = "dtmRunAt";
			dtmRunAt.ShowUpDown = true;
			dtmRunAt.Size = new Size(234, 35);
			dtmRunAt.TabIndex = 7;
			// 
			// lblRunAt
			// 
			lblRunAt.Enabled = false;
			lblRunAt.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblRunAt.Location = new Point(33, 237);
			lblRunAt.Name = "lblRunAt";
			lblRunAt.Size = new Size(200, 31);
			lblRunAt.TabIndex = 8;
			lblRunAt.Text = "Run at";
			// 
			// btnCreate
			// 
			btnCreate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnCreate.Location = new Point(33, 321);
			btnCreate.Name = "btnCreate";
			btnCreate.Size = new Size(234, 49);
			btnCreate.TabIndex = 9;
			btnCreate.Text = "Create!";
			btnCreate.UseVisualStyleBackColor = true;
			btnCreate.Click += btnCreate_Click;
			// 
			// InputScheduledData
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.ActiveCaption;
			ClientSize = new Size(296, 400);
			Controls.Add(btnCreate);
			Controls.Add(lblRunAt);
			Controls.Add(dtmRunAt);
			Controls.Add(txtInterval);
			Controls.Add(lblInterval);
			Controls.Add(cboTrigger);
			Controls.Add(lblTrigger);
			Controls.Add(txtTaskName);
			Controls.Add(lblTaskName);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			MdiChildrenMinimizedAnchorBottom = false;
			Name = "InputScheduledData";
			ShowIcon = false;
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Create Task";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label lblTaskName;
		private TextBox txtTaskName;
		private Label lblTrigger;
		private ComboBox cboTrigger;
		private TextBox txtInterval;
		private Label lblInterval;
		private DateTimePicker dtmRunAt;
		private Label lblRunAt;
		private Button btnCreate;
	}
}