using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess;

class TextConnector : IDataConnection
{
	public void CreatePerson(PersonModel model)
	{
		List<PersonModel> people = GlobalConfig.PeopleFile.FullFilePath().LoadFile().ConvertToPersonModels();

		var currentId = 1;
		if (people.Count > 0)
		{
			currentId = people.OrderByDescending(x => x.Id).First().Id + 1;
		}
		model.Id = currentId;

		people.Add(model);

		people.SaveToPeopleFile();
	}
	public void CreatePrize(PrizeModel model)
	{
		List<PrizeModel> prizes = GlobalConfig.PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModels();

		var currentId = 1;
		if (prizes.Count > 0)
		{
			currentId = prizes.OrderByDescending(x => x.Id).First().Id + 1;
		}
		model.Id = currentId;

		prizes.Add(model);

		prizes.SaveToPrizeFile();
	}
	public void CreateTeam(TeamModel model)
	{
		List<TeamModel> teams = GlobalConfig.TeamFile.FullFilePath().LoadFile().ConvertToTeamsModels();

		var currentId = 1;
		if (teams.Count > 0)
		{
			currentId = teams.OrderByDescending(x => x.Id).First().Id + 1;
		}
		model.Id = currentId;

		teams.Add(model);
		teams.SaveToTeamFile();
	}
	public void CreateTournament(TournamentModel model)
	{
		List<TournamentModel> tournaments = GlobalConfig.TournamentFile
			.FullFilePath()
			.LoadFile()
			.ConvertToTournamentModels();

		int currentId = 1;

		if (tournaments.Count > 0)
		{
			currentId = tournaments.OrderByDescending(x => x.Id).First().Id + 1;
		}

		model.Id = currentId;

		model.SaveRoundsToFile();
		tournaments.Add(model);
		tournaments.SaveToTournamentFile();

		TournamentLogic.UpdateTournamentResults(model);
	}

	public List<PersonModel> GetPerson_All()
	{
		return GlobalConfig.PeopleFile.FullFilePath().LoadFile().ConvertToPersonModels();
	}
	public List<TeamModel> GetTeam_All()
	{
		return GlobalConfig.TeamFile.FullFilePath().LoadFile().ConvertToTeamsModels();
	}
	public List<TournamentModel> GetTournaments_All()
	{
		return GlobalConfig.TournamentFile
			.FullFilePath()
			.LoadFile()
			.ConvertToTournamentModels();
	}

	public void UpdateMatchup(MatchupModel model)
	{
		model.UpdateMatchupToFile();
	}

	public void CompleteTournament(TournamentModel model)
	{
		List<TournamentModel> tournaments = GlobalConfig.TournamentFile
			.FullFilePath()
			.LoadFile()
			.ConvertToTournamentModels();

		tournaments.Remove(model);

		tournaments.SaveToTournamentFile();

		TournamentLogic.UpdateTournamentResults(model);
	}

	// TODO - Implement new TextConnector methods 
	public TournamentModel GetTournament_ById(int id)
	{
		throw new NotImplementedException();
	}

	public TeamModel GetTeam_ById(int id)
	{
		throw new NotImplementedException();
	}

	public PersonModel GetPerson_ById(int id)
	{
		throw new NotImplementedException();
	}

	public List<PersonModel> GetTeamMembers_ByTeamId(int teamId)
	{
		throw new NotImplementedException();
	}
}
