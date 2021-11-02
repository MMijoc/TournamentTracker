using TrackerLibrary.Models;
using TrackerLibraryFrame.DataAccess.TextHelpers;
using System.Linq;
using System.Collections.Generic;

namespace TrackerLibrary.DataAccess
{
	class TextConnector : IDataConnection
	{
		// TODO - Refactor file names 
		private const string PrizesFile = "PrizeModels.csv";
		private const string PeopleFile = "PersonModels.csv";
		private const string TeamFile = "TeamModels.csv";
		private const string TournamentFile = "TournamentModels.csv";
		private const string MatchupFile = "MatchupModels.csv";
		private const string MatchupEntryFile = "MatchupEntryModels.csv";

		public PersonModel CreatePerson(PersonModel model)
		{
			List<PersonModel> people = PeopleFile.FullFilePath().LoadFile().ConvertToPersonModels();

			var currentId = 1;
			if (people.Count > 0)
			{
				currentId = people.OrderByDescending(x => x.Id).First().Id + 1;
			}
			model.Id = currentId;

			people.Add(model);

			people.SaveToPeopleFile(PeopleFile);

			return model;
		}

		public PrizeModel CreatePrize(PrizeModel model)
		{
			List<PrizeModel> prizes = PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModels();

			var currentId = 1;
			if (prizes.Count > 0)
			{
				currentId = prizes.OrderByDescending(x => x.Id).First().Id + 1;
			}
			model.Id = currentId;

			prizes.Add(model);

			prizes.SaveToPrizeFile(PrizesFile);

			return model;
		}

		public TeamModel CreateTeam(TeamModel model)
		{
			List<TeamModel> teams = TeamFile.FullFilePath().LoadFile().ConvertToTeamsModels(PeopleFile);

			var currentId = 1;
			if (teams.Count > 0)
			{
				currentId = teams.OrderByDescending(x => x.Id).First().Id + 1;
			}
			model.Id = currentId;

			teams.Add(model);
			teams.SaveToTeamFile(TeamFile);
			return null;
		}

		public void CreateTournament(TournamentModel model)
		{
			List<TournamentModel> tournaments = TournamentFile
				.FullFilePath()
				.LoadFile().
				ConvertToTournamentModels(TeamFile, PeopleFile, PrizesFile);

			int currentId = 1;

			if (tournaments.Count > 0)
			{
				currentId = tournaments.OrderByDescending(x => x.Id).First().Id + 1;
			}

			model.Id = currentId;

			model.SaveRoundsToFile(MatchupFile, MatchupEntryFile);

			tournaments.Add(model);
			tournaments.SaveToTournamentFile(TournamentFile);
		}

		public List<PersonModel> GetPerson_All()
		{
			return PeopleFile.FullFilePath().LoadFile().ConvertToPersonModels();
		}

		public List<TeamModel> GetTeam_All()
		{
			return TeamFile.FullFilePath().LoadFile().ConvertToTeamsModels(PeopleFile);
		}

		public List<TournamentModel> GetTournaments_All()
		{
			return TournamentFile
				.FullFilePath()
				.LoadFile().
				ConvertToTournamentModels(TeamFile, PeopleFile, PrizesFile);
		}
	}
}
