using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackerUpper
{
	public partial class InputScheduledData : Form
	{
		internal string? task_name;
		internal TriggerType trigger;
		internal int? interval;
		internal DateTime? time;

		public InputScheduledData()
		{
			InitializeComponent();
		}

		private void cboTrigger_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (cboTrigger.SelectedIndex)
			{
				case 0:
					lblInterval.Enabled = false;
					txtInterval.Enabled = false;
					lblRunAt.Enabled = false;
					dtmRunAt.Enabled = false;
					break;
				default:
					lblInterval.Enabled = true;
					txtInterval.Enabled = true;
					lblRunAt.Enabled = true;
					dtmRunAt.Enabled = true;
					break;
			}
		}

		private void btnCreate_Click(object sender, EventArgs e)
		{
			bool errors = false;

			//	Validate necessary input
			if (txtTaskName.Text == null || txtTaskName.Text == "")
			{
				lblTaskName.ForeColor = Color.Red;
				errors = true;
			}
			else
			{
				lblTaskName.ForeColor = Color.Black;
			}

			switch (cboTrigger.SelectedIndex)
			{
				case 0:
					lblTrigger.ForeColor = Color.Black;
					break;

				case 1: case 2:
					lblTrigger.ForeColor = Color.Black;

					if (txtInterval.Text == null || txtInterval.Text == "")
					{
						lblInterval.ForeColor = Color.Red;
						errors = true;
					}
					else
					{
						lblInterval.ForeColor = Color.Black;
					}

					break;

				default:
					lblTrigger.ForeColor = Color.Red;
					errors = true;
					break;
			}

			if (errors)
			{
				MessageBox.Show(
					"Invalid mandatory fields",
					"Warning",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning
				);

				return;
			}

			//	If no errors, continue
			this.task_name = txtTaskName.Text;
			this.trigger = (TriggerType)cboTrigger.SelectedIndex;
			switch (cboTrigger.SelectedIndex)
			{
				case 1: case 2:
					//	Parse interval only if not backing up on startup
					if (cboTrigger.SelectedIndex != 0)
					{
						//	Try parse interval
						try
						{
							int.Parse(txtInterval.Text!);
						}
						catch
						{
							lblInterval.ForeColor = Color.Red;
							MessageBox.Show(
								"Invalid interval",
								"Warning",
								MessageBoxButtons.OK,
								MessageBoxIcon.Warning
							);

							return;
						}
					}

					this.interval = int.Parse(txtInterval.Text!);
					this.time = dtmRunAt.Value;

					break;

				default:
					
					break;
			}
			
			//	No errors, return
			this.Close();
		}
	}

	internal enum TriggerType
	{
		Startup = 0,
		Daily = 1,
		Weekly = 2,
		Monthly = 3
	}
}
