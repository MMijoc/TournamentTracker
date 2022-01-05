using Microsoft.AspNetCore.Mvc.RazorPages;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerWebApp.Pages.Tournaments.Teams;

public class DetailsModel : PageModel
{
	public TeamModel Team { get; set; }


	public void OnGet(int teamId)
	{
		Team = GlobalConfig.Connection.GetTeam_ById(teamId);
		Team.TeamMembers = GlobalConfig.Connection.GetTeamMembers_ByTeamId(teamId);
	}
}
