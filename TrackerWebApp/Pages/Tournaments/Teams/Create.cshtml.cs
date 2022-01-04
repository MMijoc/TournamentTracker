using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerWebApp.Pages.Tournaments.Teams;

public class CreateTeamModel : PageModel
{
	[BindProperty]
	public TeamModel NewTeam { get; set; }
	public List<PersonModel> AvailableTeamMemebers { get; set; }
	[BindProperty]
	public PersonModel NewPerson { get; set; }

	public SelectList TeamMemebersSelectList { get; set; }

	[BindProperty]
	public List<int> SelectedTeamMemeberIds { get; set; }

	public void OnGet()
	{
		AvailableTeamMemebers = GlobalConfig.Connection.GetPerson_All();
		TeamMemebersSelectList = new SelectList(AvailableTeamMemebers, "Id", "FullName");
	}

	public IActionResult OnPostCreateNewTeam()
	{
		foreach (var id in SelectedTeamMemeberIds)
		{
			NewTeam.TeamMembers.Add(GlobalConfig.Connection.GetPerson_ById(id));
		}
		GlobalConfig.Connection.CreateTeam(NewTeam);

		return RedirectToPage("./Create");
	}

	public IActionResult OnPostCreateNewPerson()
	{
		GlobalConfig.Connection.CreatePerson(NewPerson);

		return RedirectToPage("./Create");
	}
}
