﻿namespace TrackerLibrary.Models;

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
	/// The ID from the database that will be used to look up the winner
	/// </summary>
	public int WinnerId { get; set; }
	/// <summary>
	/// The winner of the match
	/// </summary>
	public TeamModel Winner { get; set; }
	/// <summary>
	/// Which round this math is a part of
	/// </summary>
	public int MatchupRound { get; set; }

	public string DisplayName
	{
		get
		{
			string output = "";
			foreach (MatchupEntryModel me in Entries)
			{
				if (me.TeamCompeting != null)
				{
					if (output.Length == 0)
					{
						output = me.TeamCompeting.TeamName;
					}
					else
					{
						output += $" vs. {me.TeamCompeting.TeamName}";
					}
				}
				else
				{
					output = "Matchup not yet determined!";
					break;
				}
			}

			return output;
		}
	}
}
