using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess;

public interface IDataConnection
{
	void CreatePrize(PrizeModel model);
	void CreatePerson(PersonModel model);
	void CreateTeam(TeamModel model);
	void CreateTournament(TournamentModel model);

	void UpdateMatchup(MatchupModel model);

	void CompleteTournament(TournamentModel model);

	List<TeamModel> GetTeam_All();
	List<PersonModel> GetPerson_All();
	List<TournamentModel> GetTournaments_All();
	TournamentModel GetTournament_ById(int id);
	TeamModel GetTeam_ById(int id);
	PersonModel GetPerson_ById(int id);
	List<PersonModel> GetTeamMembers_ByTeamId(int teamId);

}
