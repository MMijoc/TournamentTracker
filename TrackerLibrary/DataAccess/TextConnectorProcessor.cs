using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary;
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
			List<MatchupModel> matchups = GlobalConfig.MatchupFile.FullFilePath().LoadFile().ConvertToMatchupModels();

			foreach (var line in lines)
			{
				string[] colums = line.Split(',');
				TournamentModel model = new TournamentModel();
				model.Id = int.Parse(colums[0]);
				model.TournamentName = colums[1];
				model.EntryFee = decimal.Parse(colums[2]);

				string[] teamIds = colums[3].Split('|');

				foreach (var id in teamIds)
				{
					model.EnteredTeams.Add(teams.Where(x => x.Id == int.Parse(id)).First());
				}

				if (colums[4].Length > 0)
				{
					string[] prizeIds = colums[4].Split('|');

					foreach (var id in prizeIds)
					{
						model.Prizes.Add(prizes.Where(x => x.Id == int.Parse(id)).FirstOrDefault());
					}
				}

				//Capture Rounds information
				string[] rounds = colums[5].Split('|');


				foreach (var round in rounds)
				{
					string[] matchupsText = round.Split('^');
					var ms = new List<MatchupModel>();

					foreach (var matchupModelTextId in matchupsText)
					{
						ms.Add(matchups.Where(x => x.Id == int.Parse(matchupModelTextId)).First()); //Using just First() causes an error: Sequence contains no elements?
					}
					model.Rounds.Add(ms);
				}

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

		public static void SaveRoundsToFile(this TournamentModel model, string MatchupFile, string MatchupEntryFile)
		{
			foreach (var round in model.Rounds)
			{
				foreach (var matchup in round)
				{
					matchup.SaveMatchupToFile(MatchupFile);
				}
			}
		}
		
		public static void SaveMatchupToFile(this MatchupModel matchup, string matchupFile)
		{
			var matchups = GlobalConfig.MatchupFile.FullFilePath().LoadFile().ConvertToMatchupModels();

			int currentId = 1;
			if (matchups.Count > 0)
			{
				currentId = matchups.OrderByDescending(x => x.Id).First().Id + 1;
			}
			matchup.Id = currentId;
			matchups.Add(matchup);

			foreach (var entry in matchup.Entries)
			{
				entry.SaveEntryToFile();
			}

			// save to file
			List<string> lines = new List<string>();
			foreach (MatchupModel m in matchups)
			{
				string winner = "";
				if (m.Winner != null)
				{
					winner = m.Winner.Id.ToString();
				}
				lines.Add($"{m.Id},{ConvertMatchupEntryListToString(m.Entries)},{winner},{m.MatchupRound}");
			}

			File.WriteAllLines(GlobalConfig.MatchupFile.FullFilePath(), lines);
		}

		public static void UpdateMatchupToFile(this MatchupModel matchup)
		{
			var matchups = GlobalConfig.MatchupFile.FullFilePath().LoadFile().ConvertToMatchupModels();
			MatchupModel oldMatchup = new MatchupModel();

			foreach (MatchupModel m in matchups)
			{
				if(m.Id == matchup.Id)
				{
					oldMatchup = m;
				}
			}
			matchups.Remove(oldMatchup);
			matchups.Add(matchup);

			foreach (var entry in matchup.Entries)
			{
				entry.UpdateEntryToFile();
			}

			// save to file
			List<string> lines = new List<string>();
			foreach (MatchupModel m in matchups)
			{
				string winner = "";
				if (m.Winner != null)
				{
					winner = m.Winner.Id.ToString();
				}
				lines.Add($"{m.Id},{ConvertMatchupEntryListToString(m.Entries)},{winner},{m.MatchupRound}");
			}

			File.WriteAllLines(GlobalConfig.MatchupFile.FullFilePath(), lines);
		}

		public static void UpdateEntryToFile(this MatchupEntryModel entry)
		{
			var entries = GlobalConfig.MatchupEntryFile.FullFilePath().LoadFile().ConvertToMatchupEntryModels();
			MatchupEntryModel oldEntry = new MatchupEntryModel();

			foreach (MatchupEntryModel e in entries)
			{
				if(e.Id == entry.Id)
				{
					oldEntry = e;
				}
			}

			entries.Remove(oldEntry);
			entries.Add(entry);

			var lines = new List<string>();
			foreach (var e in entries)
			{
				string parent = "";
				if (e.ParentMatchup != null)
				{
					parent = e.ParentMatchup.Id.ToString();
				}
				string teamCompeting = "";
				if (e.TeamCompeting != null)
				{
					teamCompeting = e.TeamCompeting.Id.ToString();
				}
				lines.Add($"{e.Id},{teamCompeting},{e.Score},{parent}");
			}

			File.WriteAllLines(GlobalConfig.MatchupEntryFile.FullFilePath(), lines);
		}

		public static void SaveEntryToFile(this MatchupEntryModel entry)
		{
			var entries = GlobalConfig.MatchupEntryFile.FullFilePath().LoadFile().ConvertToMatchupEntryModels();

			int currentId = 1;
			if (entries.Count > 0)
			{
				currentId = entries.OrderByDescending(x => x.Id).First().Id + 1;
			}
			entry.Id = currentId;
			entries.Add(entry);

			var lines = new List<string>();
			foreach (var e in entries)
			{
				string parent = "";
				if (e.ParentMatchup != null)
				{
					parent = e.ParentMatchup.Id.ToString();
				}
				string teamCompeting = "";
				if (e.TeamCompeting != null)
				{
					teamCompeting = e.TeamCompeting.Id.ToString();
				}
				lines.Add($"{e.Id},{teamCompeting},{e.Score},{parent}");
			}

			File.WriteAllLines(GlobalConfig.MatchupEntryFile.FullFilePath(), lines);
		}

		private static List<MatchupEntryModel> ConvertStringToMatchupEntryModes(string input)
		{
			string[] ids = input.Split('|');
			var output = new List<MatchupEntryModel>();
			List<string> entries = GlobalConfig.MatchupEntryFile.FullFilePath().LoadFile();
			List<string> matchingEntries = new List<string>();

			foreach (var id in ids)
			{
				foreach (string entry in entries)
				{
					string[] colums = entry.Split(',');

					if (colums[0] == id)
					{
						matchingEntries.Add(entry);
					}
				}
			}

			output = matchingEntries.ConvertToMatchupEntryModels();

			return output;
		}

		public static List<MatchupEntryModel> ConvertToMatchupEntryModels(this List<string> lines)
		{
			var output = new List<MatchupEntryModel>();

			foreach (var line in lines)
			{
				string[] colums = line.Split(',');

				var model = new MatchupEntryModel();
				model.Id = int.Parse(colums[0]);
				if (colums[1].Length == 0)
				{
					model.TeamCompeting = null;
				}
				else
				{
					model.TeamCompeting = LookupTeamById(int.Parse(colums[1]));
				}
				model.Score = double.Parse(colums[2]);

				if (int.TryParse(colums[3], out int parentId))
				{
					model.ParentMatchup = LookupMatchupById(parentId);
				}
				else
				{
					model.ParentMatchup = null;
				}

				output.Add(model);
			}

			return output;
		}
		private static TeamModel LookupTeamById(int id)
		{
			List<string> teams = GlobalConfig.TeamFile.FullFilePath().LoadFile();

			foreach (string team in teams)
			{
				string[] colums = team.Split(',');

				if (colums[0] == id.ToString())
				{
					List<string> matchingTeams = new List<string>();
					matchingTeams.Add(team);
					return matchingTeams.ConvertToTeamsModels(GlobalConfig.PeopleFile).First();
				}
			}

			return null;
		}
		private static MatchupModel LookupMatchupById(int id)
		{
			List<string> matchups = GlobalConfig.MatchupFile.FullFilePath().LoadFile();

			foreach (string matchup in matchups)
			{
				string[] colums = matchup.Split(',');

				if (colums[0] == id.ToString())
				{
					List<string> matchingMatchups = new List<string>();
					matchingMatchups.Add(matchup);
					return matchingMatchups.ConvertToMatchupModels().First();
				}
			}

			return null;
		}

		public static List<MatchupModel> ConvertToMatchupModels(this List<string> lines)
		{
			// Id = 0, Entries = 1(pipe delimited by Id), Winner = 2, MatchupRound = 3
			var output = new List<MatchupModel>();

			foreach (var line in lines)
			{
				string[] colums = line.Split(',');

				var model = new MatchupModel();
				model.Id = int.Parse(colums[0]);
				model.Entries = ConvertStringToMatchupEntryModes(colums[1]);

				if (colums[2].Length == 0)
				{
					model.Winner = null;
				}
				else
				{
					model.Winner = LookupTeamById(int.Parse(colums[2]));
				}

				model.MatchupRound = int.Parse(colums[3]);
	
				output.Add(model);
			}

			return output;
		}

		public static void SaveToTournamentFile(this List<TournamentModel> models, string fileName)
		{
			var lines = new List<string>();

			foreach (var model in models)
			{
				lines.Add($"{model.Id},{model.TournamentName},{model.EntryFee},{ConvertTeamListToString(model.EnteredTeams)},{ConvertPrizeListToString(model.Prizes)},{ConvertRoundListToString(model.Rounds)}");
			}

			File.WriteAllLines(fileName.FullFilePath(), lines);
		}

		/// <summary>
		/// Converts List of PersonModel to the string containing person's Id's delimited with '|' (pipe) character
		/// </summary>
		/// <param name="people"></param>
		/// <returns>String containing Id's delimited with '|' character</returns>
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

			foreach (List<MatchupModel> matchups in rounds)
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

		private static string ConvertMatchupEntryListToString(List<MatchupEntryModel> entries)
		{
			var output = "";

			if (entries.Count == 0)
			{
				return "";
			}

			foreach (var entry in entries)
			{
				output += $"{entry.Id}|";
			}
			output = output.Substring(0, output.Length - 1);

			return output;
		}


	}

}
