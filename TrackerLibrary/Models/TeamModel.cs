using System.Collections.Generic;

namespace TrackerLibrary.Models
{
	public class TeamModel
	{
		/// <summary>
		/// The unique identifier for the Team
		/// </summary>
		public int Id { get; set; }
		/// <summary>
		/// Name of the team
		/// </summary>
		public string TeamName { get; set; }
		/// <summary>
		/// List of persons who are in the team
		/// </summary>
		public List<PersonModel> TeamMembers { get; set; } = new List<PersonModel>();
	}
}
