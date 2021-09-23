using System.Collections.Generic;

namespace TrackerLibrary.Models
{
	/// <summary>
	/// Represents one math in the tournament
	/// </summary>
	public class MatchupModel
	{
		private static readonly List<MatchupEntryModel> matchupEntryModels = new List<MatchupEntryModel>();

		/// <summary>
		/// The set of teams that were involved in this math
		/// </summary>
		public List<MatchupEntryModel> Entries { get; set; } = matchupEntryModels;
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
