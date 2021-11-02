
namespace TrackerLibrary.Models
{
	/// <summary>
	/// Represents one team in a match-up
	/// </summary>
	public class MatchupEntryModel
	{
		/// <summary>
		/// The unique identifier for the matchup entry.
		/// </summary>
		public int Id { get; set; }
		/// <summary>
		/// Represents id for the team
		/// </summary>
		public int TeamCompetingId { get; set; }
		/// <summary>
		/// The id for the parent match-up
		/// </summary>
		public int ParentMatchupId { get; set; }

		/// <summary>
		/// Represents one team in the match-up
		/// </summary>
		public TeamModel TeamCompeting { get; set; }
		/// <summary>
		/// Represents the score for this particular team
		/// </summary>
		public double Score { get; set; }
		/// <summary>
		/// Represents the match-up that this team came
		/// from as the winner
		/// </summary>
		public MatchupModel ParentMatchup { get; set; }
	}
}