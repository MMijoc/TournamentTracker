using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrackerLibrary;
using TrackerLibrary.DataAccess;
using TrackerLibrary.Models;

namespace TrackerWebApp.Pages.Tournaments;

public class CreateModel : PageModel
{
	[BindProperty]
	public TournamentModel NewTournament { get; set; }

	public List<TeamModel> Teams { get; set; }

	public SelectList TeamsSelectList { get; set; }

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
		foreach (var id in SelectedTeamsIds)
		{
			NewTournament.EnteredTeams.Add(GlobalConfig.Connection.GetTeam_ById(id));
		}

		TournamentLogic.CreateRounds(NewTournament);

		GlobalConfig.Connection.CreateTournament(NewTournament);

		NewTournament.AlertUsersToNewRound();


		return RedirectToPage("./Details", new { tournamentId = NewTournament.Id });
	}
}
