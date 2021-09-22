
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
	/// <summary>
	/// Represents one math in the tournament
	/// </summary>
	public class MatchupModel
	{
		/// <summary>
		/// The set of teams that were involved in this math
		/// </summary>
		public List<MatchupEntryModel> Entries { get; set; } = new();
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
