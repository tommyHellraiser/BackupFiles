using BackerUpperConfig;
using System.Diagnostics;

namespace BackupFiles
{
	public partial class HomeScreen : Form
	{
		public HomeScreen()
		{
			InitializeComponent();
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
			string path = "data/RunBackup.exe";
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
			Config.SaveToJson();
		}
	}
}
