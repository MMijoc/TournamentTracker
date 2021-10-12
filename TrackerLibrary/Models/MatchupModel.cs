using System.Collections.Generic;

namespace TrackerLibrary.Models
{
	/// <summary>
	/// Represents one math in the tournament
	/// </summary>
	public class MatchupModel
	{
		/// <summary>
		/// The unique identifier for the matchup
		/// </summary>
		public int Id { get; set; }
		/// <summary>
		/// The set of teams that were involved in this math
		/// </summary>
		public List<MatchupEntryModel> Entries { get; set; } = new List<MatchupEntryModel>();
		/// <summary>
		/// The winner of the match
		/// </summary>
		public TeamModel Winner { get; set; }
		/// <summary>
		/// Which round this math is a part of
		/// </summary>
		public int MatchupRound { get; set; }
	}
}
