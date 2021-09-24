using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibraryFrame.DataAccess.TextHelpers
{
	public static class TextConnectorProcessor
	{
		public static string FullFilePath(this string fileName)
		{
			return $"{ConfigurationManager.AppSettings["filePath"] }\\{fileName}";
		}

		public static List<string> LoadFile(this string file)
		{
			if (!File.Exists(file))
			{
				return new List<string>();
			}

			return File.ReadAllLines(file).ToList();
		}

		public static List<PrizeModel> ConvertToPrizeModels(this List<string> lines)
		{
			var output = new List<PrizeModel>();

			foreach (var line in lines)
			{
				string[] colums = line.Split(',');

				var model = new PrizeModel();
				model.Id = int.Parse(colums[0]);
				model.PlaceNumber = int.Parse(colums[1]);
				model.PlaceName = colums[2];
				model.PrizeAmount = decimal.Parse(colums[3]);
				model.PrizePercentage = double.Parse(colums[4]);
				output.Add(model);
			}

			return output;
		}

		public static void SaveToPrizeFile(this List<PrizeModel> models, string fileName)
		{
			var lines = new List<string>();

			foreach (PrizeModel model in models)
			{
				lines.Add($"{model.Id},{model.PlaceNumber},{model.PlaceName},{model.PrizeAmount},{model.PrizePercentage}");
			}

			File.WriteAllLines(fileName.FullFilePath(), lines);
		}
	}
}
