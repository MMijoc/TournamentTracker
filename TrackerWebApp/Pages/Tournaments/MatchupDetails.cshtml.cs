using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerWebApp.Pages.Tournaments;

public class MatchupDetailsModel : PageModel
{
	public TournamentModel Tournament { get; set; }
	public MatchupModel CurretnMatchup { get; set; }
	public bool IsBye { get; set; }
	public string TeamOneName { get; set; }
	public string TeamTwoName { get; set; }
	public string ErrorMessage { get; set; }

	[BindProperty]
	public double TeamOneScore { get; set; }

	[BindProperty]
	public double TeamTwoScore { get; set; }


	public void OnGet(int tournamentId, int matchupId)
	{
		Tournament = GlobalConfig.Connection.GetTournament_ById(tournamentId);
		foreach (var matchups in Tournament.Rounds)
		{
			foreach (var matchup in matchups)
			{
				if (matchup.Id == matchupId)
				{
					CurretnMatchup = matchup;
				}
			}
		}

		LoadMatchup(CurretnMatchup);

		if (CurretnMatchup.Entries.Count < 2)
		{
			IsBye = true;
		}
	}

	public IActionResult OnPost(int tournamentId, int matchupId)
	{

		if (ValidateMatchupModel())
		{
			Tournament = GlobalConfig.Connection.GetTournament_ById(tournamentId);
			foreach (var matchups in Tournament.Rounds)
			{
				foreach (var matchup in matchups)
				{
					if (matchup.Id == matchupId)
					{
						CurretnMatchup = matchup;
						CurretnMatchup.Entries[0].Score = TeamOneScore;
						CurretnMatchup.Entries[1].Score = TeamTwoScore;
					}
				}
			}

			TournamentLogic.UpdateTournamentResults(Tournament);
			return RedirectToPage("./Details", new { tournamentId = Tournament.Id });
		}
		else
		{
			OnGet(tournamentId, matchupId);
			return Page();
		}
	}


	private void LoadMatchup(MatchupModel m)
	{
		if (m == null)
		{
			return;
		}

		for (int i = 0; i < m.Entries.Count; i++)
		{
			if (i == 0)
			{
				if (m.Entries[0].TeamCompeting != null)
				{
					TeamOneName = CurretnMatchup.Entries[0].TeamCompeting.TeamName;
					TeamOneScore = CurretnMatchup.Entries[0].Score;

					TeamTwoName = "<BYE>";
					TeamTwoScore = 0;
				}
				else
				{
					TeamOneName = "Not yet set!";
					TeamOneScore = 0;
				}
			}

			if (i == 1)
			{
				if (m.Entries[1].TeamCompeting != null)
				{
					TeamTwoName = CurretnMatchup.Entries[1].TeamCompeting.TeamName;
					TeamTwoScore = CurretnMatchup.Entries[1].Score;
				}
				else
				{
					TeamTwoName = "Not yet set!";
					TeamTwoScore = 0;
				}
			}
		}
	}

	private bool ValidateMatchupModel()
	{
		var output = true;

		if (!ModelState.IsValid)
		{
			output = false;
		}

		if (TeamOneScore == TeamTwoScore)
		{
			ErrorMessage = "This application does not allow ties!";
			output = false;
		}

		return output;
	}
}
