using System.ComponentModel.DataAnnotations;

namespace TrackerLibrary.Models;

public class TournamentModel
{
	public event EventHandler<DateTime> OnTournamentComplete;

	/// <summary>
	/// The unique identifier for the tournament
	/// </summary>
	public int Id { get; set; }

	/// <summary>
	/// Name given to this tournament
	/// </summary>
	/// 
	[Required]
	public string TournamentName { get; set; }

	/// <summary>
	/// The amount of money each team needs to put up to enter.
	/// </summary>
	/// 
	[Required]
	[Range(0, double.MaxValue)]
	public decimal EntryFee { get; set; }

	/// <summary>
	/// The set of teams that have been entered
	/// </summary>
	/// 
	public List<TeamModel> EnteredTeams { get; set; } = new List<TeamModel>();

	/// <summary>
	/// The list of prizes for the various places.
	/// </summary>
	public List<PrizeModel> Prizes { get; set; } = new List<PrizeModel>();

	/// <summary>
	/// The match-ups per round
	/// </summary>
	public List<List<MatchupModel>> Rounds { get; set; } = new List<List<MatchupModel>>();

	public void CompleteTournament()
	{
		OnTournamentComplete?.Invoke(this, DateTime.Now);
	}
}
