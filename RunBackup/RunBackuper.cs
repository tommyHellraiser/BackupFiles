using RunBackupConfig;

try
{
	Config.LoadFromJson();
}
catch
{
	Environment.Exit(-69);	//	Error loading json configuration file
}

//	Validating origin directory
if (Config.origin_dir == null || Config.origin_dir == "")
{
	Environment.Exit(-1);	//	Origin directory value is empty or null
}

//	Validating backup directory
if (Config.backup_dir == null || Config.backup_dir == "")
{
	Environment.Exit(-2);	//	Backup (destination) value directory is empty or null
}

try
{
	CopyDirectory(Config.origin_dir, Config.backup_dir);
}
catch
{
	Environment.Exit(-4);	//	Failed to perform the copy operation
}

//	If no exceptions were thrown, then every file and folder was copied ok
Environment.Exit(0);


/// Copies files from origin dir to destination dir and calls itself recursively in case 
/// there's any folder inside the origin dir
void CopyDirectory(string origin, string destination)
{
	//	Get origin directory object
	DirectoryInfo origin_dir = new DirectoryInfo(origin);
	if (!origin_dir.Exists)
	{
		Environment.Exit(-3);   //	Origin directory does not exist
	}

	//	Create backup directory if it doesn't exist
	if (!Directory.Exists(destination))
	{
		Directory.CreateDirectory(destination);
	}

	//	Get all files in origin dir ad copy them
	FileInfo[] files = origin_dir.GetFiles();
	foreach (FileInfo file in files)
	{
		file.CopyTo(Path.Combine(destination, file.Name), true);
	}

	//	Get all directories in origin dir and copy them
	DirectoryInfo[] dirs = origin_dir.GetDirectories();
	foreach (DirectoryInfo dir in dirs)
	{
		string subdir = Path.Combine(destination, dir.Name);
		CopyDirectory(dir.FullName, subdir);
	}
}