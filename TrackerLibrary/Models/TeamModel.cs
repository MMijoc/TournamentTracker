using System.ComponentModel.DataAnnotations;

namespace TrackerLibrary.Models;

public class TeamModel
{
	/// <summary>
	/// The unique identifier for the Team
	/// </summary>
	public int Id { get; set; }

	/// <summary>
	/// Name of the team
	/// </summary>
	[Required]
	public string TeamName { get; set; }

	/// <summary>
	/// List of persons who are in the team
	/// </summary>
	public List<PersonModel> TeamMembers { get; set; } = new List<PersonModel>();
}
