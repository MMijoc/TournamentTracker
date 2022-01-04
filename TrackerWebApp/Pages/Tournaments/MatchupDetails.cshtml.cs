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

	public MatchupEntryModel TeamOne { get; set; }
	public MatchupEntryModel TeamTwo { get; set; }

	public string TeamOneName { get; set; }
	public string TeamTwoName { get; set; }

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

		if (ModelState.IsValid)
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
			//GlobalConfig.Connection.UpdateMatchup(CurretnMatchup);

			TournamentLogic.UpdateTournamentResults(Tournament);
			return RedirectToPage("./Details", new { tournamentId = Tournament.Id });
		}
		else
		{
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

	//private string ValidateData()
	//{
	//	string output = "";

	//	bool scoreOneValid = double.TryParse(teamOneScoreValue.Text, out double teamOneScore);
	//	bool scoreTwoValid = double.TryParse(teamTwoScoreValue.Text, out double teamTwoScore);

	//	if (!scoreOneValid)
	//	{
	//		output = "The Score One value is not valid number.";
	//	}
	//	else if (!scoreTwoValid)
	//	{
	//		output = "The Score Two value is not valid number.";
	//	}
	//	else if (teamOneScore == 0 && teamTwoScore == 0)
	//	{
	//		output = "You did not enter a score for either team.";
	//	}
	//	else if (teamOneScore == teamTwoScore)
	//	{
	//		output = "We do not allow ties in this application.";
	//	}

	//	return output;
	//}
}