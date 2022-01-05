using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerWebApp.Pages.Tournaments.Teams;

public class CreateTeamModel : PageModel
{
	public List<PersonModel> AvailableTeamMemebers { get; set; }
	public SelectList TeamMemebersSelectList { get; set; }
	public string ErrorMessage { get; set; }

	[BindProperty]
	public TeamModel NewTeam { get; set; }

	[BindProperty]
	public List<int> SelectedTeamMemeberIds { get; set; }
	[BindProperty]
	public PersonModel NewPerson { get; set; }


	public void OnGet()
	{
		AvailableTeamMemebers = GlobalConfig.Connection.GetPerson_All();
		TeamMemebersSelectList = new SelectList(AvailableTeamMemebers, "Id", "FullName");
	}
	public IActionResult OnPostCreateNewTeam()
	{
		if (ValidateTeamModel())
		{
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
		if (ValidatePersonModel() == true)
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


	private bool ValidatePersonModel()
	{
		if (string.IsNullOrEmpty(NewPerson.FirstName))
		{
			return false;
		}

		if (string.IsNullOrEmpty(NewPerson.LastName))
		{
			return false;
		}

		if (string.IsNullOrEmpty(NewPerson.EmailAddress))
		{
			return false;
		}

		return true;
	}
	private bool ValidateTeamModel()
	{
		var output = true;
		if (string.IsNullOrEmpty(NewTeam.TeamName))
		{
			output = false;
		}

		if (SelectedTeamMemeberIds.Count < 1)
		{
			ErrorMessage = "Team must have at least one member";
			output =  false;
		}

		return output;
	}
}
