using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BackerUpperConfig
{
	internal static class Config
	{
		internal static string? origin_dir;
		internal static string? backup_dir;

		public class Rootobject
		{
			public string? origin_dir { get; set; }
			public string? backup_dir { get; set; }
		}

		internal static void LoadFromJson()
		{
			#if DEBUG
			string json_dir = "../../../../RunBackup/config.json";
			#else
			string json_dir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)! + "\\data\\config.json";
			#endif

			using (StreamReader reader = new StreamReader(json_dir))
			{
				string? json = reader.ReadToEnd();
				if (json == null)
				{
					throw new NullReferenceException("No config.json was found in specified directory");
				}
				Rootobject? configuration = JsonSerializer.Deserialize<Rootobject>(json);
				if (configuration == null)
				{
					throw new NullReferenceException("Couldn't load configuration from config.json file");
				}

				if (configuration.origin_dir == null || configuration.origin_dir == "" || configuration.backup_dir == null || configuration.backup_dir == "")
				{
					throw new ArgumentNullException("Configuration parameters cannot be empty!");
				}

				origin_dir = configuration.origin_dir;
				backup_dir = configuration.backup_dir;
			}
		}

		internal static void SaveToJson()
		{
			#if DEBUG
			string json_dir = "../../../../RunBackup/config.json";
			#else
			string json_dir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)! + "\\data\\config.json";
			#endif
			Rootobject json_obj = new Rootobject {
				origin_dir = Config.origin_dir,
				backup_dir = Config.backup_dir
			};
			var options = new JsonSerializerOptions { WriteIndented = true };
			string json = JsonSerializer.Serialize(json_obj, options);
			StreamWriter writer = new StreamWriter(json_dir);
			writer.Write(json);
			writer.Close();
		}
	}
}
