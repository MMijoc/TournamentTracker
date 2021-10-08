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

		public static List<PersonModel> ConvertToPersonModels(this List<string> lines)
		{
			var output = new List<PersonModel>();

			foreach (var line in lines)
			{
				string[] colums = line.Split(',');

				var model = new PersonModel();
				model.Id = int.Parse(colums[0]);
				model.FirstName = colums[1];
				model.LastName = colums[2];
				model.EmailAddress = colums[3];
				model.CellphoneNumber = colums[4];
				output.Add(model);
			}

			return output;
		}

		public static List<TeamModel> ConvertToTeamsModels(this List<string> lines, string peopleFileName)
		{
			var output = new List<TeamModel>();
			List<PersonModel> people = peopleFileName.FullFilePath().LoadFile().ConvertToPersonModels();

			foreach (var line in lines)
			{
				string[] colums = line.Split(',');

				var model = new TeamModel();
				model.Id = int.Parse(colums[0]);
				model.TeamName = colums[1];

				string[] perosnIds = colums[2].Split('|');
				foreach (var id in perosnIds)
				{
					model.TeamMembers.Add(people.Where(x => x.Id == int.Parse(id)).First());
				}
				output.Add(model);
			}

			return output;
		}

		public static List<TournamentModel> ConvertToTournamentModels(this List<string> lines)
		{

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

		public static void SaveToPeopleFile(this List<PersonModel> models, string fileName)
		{
			var lines = new List<string>();

			foreach (var model in models)
			{
				lines.Add($"{model.Id},{model.FirstName},{model.LastName},{model.EmailAddress},{model.CellphoneNumber}");
			}

			File.WriteAllLines(fileName.FullFilePath(), lines);
		}

		public static void SaveToTeamFile(this List<TeamModel> models, string fileName)
		{
			var lines = new List<string>();

			foreach (var model in models)
			{
				lines.Add($"{model.Id},{model.TeamName},{ConvertPeopleListToString(model.TeamMembers)}");
			}

			File.WriteAllLines(fileName.FullFilePath(), lines);
		}

		/// <summary>
		/// Converts List of PersonModel to the string containig preosn's Id's delimited with '|' (pipe) character
		/// </summary>
		/// <param name="people"></param>
		/// <returns>String containig Id's delimited with '|' character</returns>
		private static string ConvertPeopleListToString(List<PersonModel> people)
		{
			var output = "";

			if (people.Count == 0)
			{
				return "";
			}

			foreach (var person in people)
			{
				output += $"{person.Id}|";
			}
			output = output.Substring(0, output.Length - 1);

			return output;
		}
	}
}
