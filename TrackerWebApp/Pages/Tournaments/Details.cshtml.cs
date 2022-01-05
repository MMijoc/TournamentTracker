using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerWebApp.Pages.Tournaments;

public class DetailsModel : PageModel
{
	public TournamentModel Tournament { get; set; }
	public List<MatchupModel>[] MatchupsPerRounds { get; set; }
	public string WinnerName { get; set; }
	public TeamModel TournamentWinner { get; set; }
	public bool HasWinner { get; set; }


	public IActionResult OnGet(int tournamentId)
	{
		Tournament = GlobalConfig.Connection.GetTournament_ById(tournamentId);
		if (Tournament == null)
		{
			return RedirectToPage("./NotFound");
		}

		MatchupsPerRounds = new List<MatchupModel>[Tournament.Rounds.Count];

		for (int i = 0; i < Tournament.Rounds.Count; i++)
		{
			MatchupsPerRounds[i] = new List<MatchupModel>();
			LoadMatchups(i + 1);
		}

		if (MatchupsPerRounds[Tournament.Rounds.Count - 1].First().Winner != null)
		{
			TournamentWinner = MatchupsPerRounds[Tournament.Rounds.Count - 1].First().Winner;
			WinnerName = MatchupsPerRounds[Tournament.Rounds.Count - 1].First().Winner.TeamName;
			HasWinner = true;
		}
		else
		{
			TournamentWinner = null;
			WinnerName = "Winner not yet determined";
			HasWinner = false;
		}

		return Page();
	}


	private void LoadMatchups(int round)
	{
		foreach (List<MatchupModel> matchups in Tournament.Rounds)
		{
			if (matchups.First().MatchupRound == round)
			{
				foreach (MatchupModel m in matchups)
				{
					MatchupsPerRounds[round - 1].Add(m);
				}
			}
		}
	}
}
