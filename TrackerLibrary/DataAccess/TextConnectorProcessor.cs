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

		public static List<TournamentModel> ConvertToTournamentModels(
			this List<string> lines,
			string teamFileName,
			string peopleFileName,
			string prizeFileName)
		{
			//id, TorunamentName, EntryFee,(id|id|... - Entered Teams), (id|id|... Prizes), (id^id^...|id^id^...|.... - Rounds)
			List<TournamentModel> output = new List<TournamentModel>();
			List<TeamModel> teams = teamFileName.FullFilePath().LoadFile().ConvertToTeamsModels(peopleFileName);
			List<PrizeModel> prizes = prizeFileName.FullFilePath().LoadFile().ConvertToPrizeModels();

			foreach (var line in lines)
			{
				string[] colums = line.Split(',');
				TournamentModel model = new TournamentModel();
				model.Id = int.Parse(colums[0]);
				model.TournnamentName = colums[1];
				model.EntryFee = decimal.Parse(colums[2]);

				string[] teamIds = colums[3].Split('|');

				foreach (var id in teamIds)
				{
					model.EnteredTeams.Add(teams.Where(x => x.Id == int.Parse(id)).First());
				}

				string[] prizeIds = colums[4].Split('|');

				foreach (var id in prizeIds)
				{
					model.Prizes.Add(prizes.Where(x => x.Id == int.Parse(id)).First());
				}

				// TODO - Capture Rounds infomratio
				output.Add(model);
			}

			return output; ;
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

		public static void SaveToTournamentFile(this List<TournamentModel> models, string fileName)
		{
			var lines = new List<string>();

			foreach (var model in models)
			{
				lines.Add($@"
					{model.Id},
					{model.TournnamentName},
					{model.EntryFee},
					{ConvertTeamListToString(model.EnteredTeams)},
					{ConvertPrizeListToString(model.Prizes)},
					{ConvertRoundListToString(model.Rounds)}");
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

		private static string ConvertTeamListToString(List<TeamModel> teams)
		{
			var output = "";

			if (teams.Count == 0)
			{
				return "";
			}

			foreach (var team in teams)
			{
				output += $"{team.Id}|";
			}
			output = output.Substring(0, output.Length - 1);

			return output;
		}

		private static string ConvertPrizeListToString(List<PrizeModel> prizes)
		{
			var output = "";

			if (prizes.Count == 0)
			{
				return "";
			}

			foreach (var prize in prizes)
			{
				output += $"{prize.Id}|";
			}
			output = output.Substring(0, output.Length - 1);

			return output;
		}

		private static string ConvertRoundListToString(List<List<MatchupModel>> rounds)
		{
			var output = "";

			if (rounds.Count == 0)
			{
				return "";
			}

			foreach (var matchups in rounds)
			{
				output += $"{ConvertMatchupListToString(matchups)}|";
			}
			output = output.Substring(0, output.Length - 1);

			return output;
		}

		private static string ConvertMatchupListToString(List<MatchupModel> matchups)
		{
			var output = "";

			if (matchups.Count == 0)
			{
				return "";
			}

			foreach (var matchup in matchups)
			{
				output += $"{matchup.Id}^";
			}
			output = output.Substring(0, output.Length - 1);

			return output;
		}



	}

}
