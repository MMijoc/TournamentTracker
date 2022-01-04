using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrackerLibrary.DataAccess;
using TrackerLibrary.Models;

namespace TrackerWebApp.Pages.Tournaments;

public class DetailsModel : PageModel
{
	private readonly IDataConnection _dataConnection;

	public TournamentModel Tournament { get; set; }

	public List<MatchupModel>[] MatchupsPerRounds { get; set; }

	public string WinnerName { get; set; }

	public DetailsModel(IDataConnection dataConnection)
	{
		_dataConnection = dataConnection;
	}

	private void LoadMatchups(int round)
	{
		foreach (List<MatchupModel> matchups in Tournament.Rounds)
		{
			if (matchups.First().MatchupRound == round)
			{
				foreach (MatchupModel m in matchups)
				{
					//if (m.Winner == null /*|| !unplayedOnlyCheckbox.Checked*/)
					//{
					MatchupsPerRounds[round - 1].Add(m);
					//}
				}
			}
		}
	}

	public IActionResult OnGet(int tournamentId)
	{
		Tournament = _dataConnection.GetTournament_ById(tournamentId);
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

		//var tmp = MatchupsPerRounds[Tournament.Rounds.Count - 1].First().Winner;
		if (MatchupsPerRounds[Tournament.Rounds.Count - 1].First().Winner != null)
		{
			WinnerName = MatchupsPerRounds[Tournament.Rounds.Count - 1].First().Winner.TeamName;
		}
		else
		{
			WinnerName = "Winner not yet determined";
		}

		return Page();
	}





}
