using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerWebApp.Pages.Tournaments.Teams;

public class ViewTeamsModel : PageModel
{
	public List<TeamModel> Teams { get; set; }

	[BindProperty(SupportsGet = true)]
	public string SearchTerm { get; set; }


	public void OnGet()
	{
		Teams = GlobalConfig.Connection.GetTeam_All();

		if (string.IsNullOrEmpty(SearchTerm))
		{
			Teams = GlobalConfig.Connection.GetTeam_All();
		}
		else
		{
			Teams = GlobalConfig.Connection.GetTeam_All().
				Where(t => t.TeamName.ToLower().Contains(SearchTerm.ToLower())).ToList();
		}
	}
}
