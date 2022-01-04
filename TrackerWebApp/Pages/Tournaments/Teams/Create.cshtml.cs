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
	[TempData]
	public string ErrorMessage { get; set; }

	[BindProperty]
	public List<int> SelectedTeamMemeberIds { get; set; }

	public void OnGet()
	{
		AvailableTeamMemebers = GlobalConfig.Connection.GetPerson_All();
		TeamMemebersSelectList = new SelectList(AvailableTeamMemebers, "Id", "FullName");
	}

	public IActionResult OnPostCreateNewTeam()
	{
		if (ModelState.IsValid)
		{
			if (SelectedTeamMemeberIds.Count < 1)
			{
				TempData["ErrorMessage"] = "Team must have at least one member";
				//OnGet();
				return Page();
			}

			foreach (var id in SelectedTeamMemeberIds)
			{
				NewTeam.TeamMembers.Add(GlobalConfig.Connection.GetPerson_ById(id));
			}
			GlobalConfig.Connection.CreateTeam(NewTeam);

			return RedirectToPage("./Create"); 
		}
		else
		{
			OnGet();
			return Page();
		}
	}

	public IActionResult OnPostCreateNewPerson()
	{
		if (ModelState.IsValid)
		{
			GlobalConfig.Connection.CreatePerson(NewPerson);

			return RedirectToPage("./Create"); 
		}
		else
		{
			OnGet();
			return Page();
		}
	}
}
