using BackerUpperConfig;
using System.Diagnostics;
using Microsoft.Win32.TaskScheduler;
using BackerUpper;
using System.Reflection;
using System.Windows.Forms;

namespace BackupFiles
{
	public partial class HomeScreen : Form
	{
		public HomeScreen()
		{
			InitializeComponent();

			ToolTip change_origin_tip = new ToolTip();
			change_origin_tip.SetToolTip(btnChangeOrigin, "Change origin folder selection");

			ToolTip change_destination_tip = new ToolTip();
			change_destination_tip.SetToolTip(btnChangeDestination, "Change destination folder selection");

			ToolTip save_config_tip = new ToolTip();
			save_config_tip.SetToolTip(btnSaveConfiguration, "Save folders configuration in config file");

			ToolTip schedule_task_tip = new ToolTip();
			schedule_task_tip.SetToolTip(btnScheduleTask, "Create a new task in the Task Scheduler");

			ToolTip backup_tip = new ToolTip();
			backup_tip.SetToolTip(btnRunBackupNow, "Execute the backup using the folders saved in configurations");

			try
			{
				Config.LoadFromJson();
				lblShowOriginDirectory.Text = Path.GetFullPath(Config.origin_dir!);
				lblShowDestinationDirectory.Text = Path.GetFullPath(Config.backup_dir!);
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					$"Error loading config from json configuration:\n{ex.Message}",
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
			}
		}

		private void btnRunBackupNow_Click(object sender, EventArgs e)
		{
			#if DEBUG
			string path = "../../../data/RunBackup.exe";
			#else
			string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)! + "\\data\\RunBackup.exe";
			#endif
			//	Prep start process
			var proc = new Process
			{
				StartInfo = new ProcessStartInfo
				{
					FileName = path,
					UseShellExecute = false,
					RedirectStandardOutput = true,
					CreateNoWindow = true
				}
			};

			//	Run backup
			proc.Start();
			proc.WaitForExit();
			string msg = "";
			switch (proc.ExitCode)
			{
				case 0:
					msg = "Backup executed successully!";
					break;
				case -1:
					msg = "Origin directory was empty in config.json";
					break;
				case -2:
					msg = "Destination directory was empty in config.json";
					break;
				case -3:
					msg = "Origin directory does not exist";
					break;
				case -4:
					msg = "Failed to copy items";
					break;
				case -10:
					msg = "Origin directory does not exist";
					break;
				case -20:
					msg = "Destination directory does not exist";
					break;
				case -69:
					msg = "Couldn't load config.json file";
					break;
				default:
					msg = "Unknown error!";
					break;
			}

			MessageBox.Show(
				msg,
				"Info",
				MessageBoxButtons.OK,
				MessageBoxIcon.Information);
		}

		private void btnChangeOrigin_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog origin_dialog = new FolderBrowserDialog();
			origin_dialog.ShowDialog();

			if (origin_dialog.SelectedPath != "")
			{
				lblShowOriginDirectory.Text = origin_dialog.SelectedPath;
				Config.origin_dir = origin_dialog.SelectedPath;
			}
		}

		private void btnChangeDestination_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog destination_dialog = new FolderBrowserDialog();
			destination_dialog.ShowDialog();

			if (destination_dialog.SelectedPath != "")
			{
				lblShowDestinationDirectory.Text = destination_dialog.SelectedPath;
				Config.backup_dir = destination_dialog.SelectedPath;
			}
		}

		private void btnSaveConfiguration_Click(object sender, EventArgs e)
		{
			try
			{
				Config.SaveToJson();
				MessageBox.Show(
					"Configuration Saved!",
					"Info",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information
				);
			}
			catch
			{
				MessageBox.Show(
					"Error saving configuration",
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
			}
		}

		private void btnScheduleTask_Click(object sender, EventArgs e)
		{
			InputScheduledData new_task= new InputScheduledData();
			new_task.ShowDialog();

			if (new_task.task_name == null)
			{
				MessageBox.Show(
					"Cancelled task creation",
					"Info",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information
				);

				return;
			}

			// Get the service on the local machine
			using (TaskService ts = new TaskService())
			{
				// Create a new task definition and assign properties
				TaskDefinition td = ts.NewTask();
				td.RegistrationInfo.Description = new_task.task_name;

				// Create a trigger that will fire the task at this time every other day
				switch (new_task.trigger)
				{
					case TriggerType.Startup:
						td.Triggers.Add(new LogonTrigger());
						break;
					case TriggerType.Daily:
						td.Triggers.Add(new DailyTrigger { DaysInterval = (short)new_task.interval!, StartBoundary = (DateTime)new_task.time! });
						//td.Triggers.Add(new TimeTrigger((DateTime)new_task.time!));
						break;
					case TriggerType.Weekly:
						td.Triggers.Add(new WeeklyTrigger { WeeksInterval = (short)new_task.interval!, StartBoundary = (DateTime)new_task.time! });
						td.Triggers.Add(new TimeTrigger((DateTime)new_task.time!));
						break;
					case TriggerType.Monthly:
						//td.Triggers.Add(new MonthlyTrigger {  = (short)new_task.interval! });
						//td.Triggers.Add(new TimeTrigger((DateTime)new_task.time!));
						break;
					default:
						td.Triggers.Add(new LogonTrigger());
						break;
				}
				//td.Triggers.Add(new DailyTrigger { DaysInterval = 1 });
				//td.Triggers.Add(new TimeTrigger());

				// Create an action that will launch Notepad whenever the trigger fires
				#if DEBUG
				string path = "../../../data/RunBackup.exe";
				#else
				string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)! + "\\data\\RunBackup.exe";
				#endif
				td.Actions.Add(new ExecAction(Path.GetFullPath(path)));

				// Register the task in the root folder
				var task = ts.RootFolder.RegisterTaskDefinition(@new_task.task_name, td);
				if (task != null)
				{
					MessageBox.Show(
						"Task created successfully!",
						"Created",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information
					);
				}
				else
				{
					MessageBox.Show(
						"Error creating task!",
						"Warning",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning
					);
				}
			}
		}
	}
}
