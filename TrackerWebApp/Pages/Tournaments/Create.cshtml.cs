using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerWebApp.Pages.Tournaments;

public class CreateModel : PageModel
{
	public List<TeamModel> Teams { get; set; }
	public SelectList TeamsSelectList { get; set; }
	public string ErrorMessage { get; set; }

	[BindProperty]
	public TournamentModel NewTournament { get; set; }

	[BindProperty]
	public List<int> SelectedTeamsIds { get; set; }

	public CreateModel()
	{
		Teams = new List<TeamModel>();
	}


	public IActionResult OnGet()
	{
		Teams = GlobalConfig.Connection.GetTeam_All();
		TeamsSelectList = new SelectList(Teams, "Id", "TeamName");

		return Page();
	}

	public IActionResult OnPost()
	{
		if (ValidateTournamentModel())
		{
			foreach (var id in SelectedTeamsIds)
			{
				NewTournament.EnteredTeams.Add(GlobalConfig.Connection.GetTeam_ById(id));
			}

			TournamentLogic.CreateRounds(NewTournament);

			GlobalConfig.Connection.CreateTournament(NewTournament);

			NewTournament.AlertUsersToNewRound();


			return RedirectToPage("./Details", new { tournamentId = NewTournament.Id }); 
		}
		else
		{
			OnGet();
			return Page();
		}
	}


	private bool ValidateTournamentModel()
	{
		var output = true;

		output = ModelState.IsValid;


		if (!ModelState.IsValid)
		{
			output = false;
		}

		if (SelectedTeamsIds.Count < 2)
		{
			output = false;
			ErrorMessage = "Tournament needs to have at least two teams competing";
		}

		return output;

	}
}
