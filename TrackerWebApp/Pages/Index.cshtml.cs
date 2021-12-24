using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrackerLibrary.DataAccess;
using TrackerLibrary.Models;

namespace TrackerWebApp.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;
		private readonly IDataConnection _dataConnection;

		public List<TournamentModel> Tournaments { get; set; }

		[BindProperty(SupportsGet = true)]
		public string SearchTerm { get; set; }

		public IndexModel(ILogger<IndexModel> logger, IDataConnection dataConnection)
		{
			_logger = logger;
			_dataConnection = dataConnection;
			Tournaments = _dataConnection.GetTournaments_All();
			SearchTerm = "";
		}

		public void OnGet()
		{
			if (string.IsNullOrEmpty(SearchTerm))
			{
				Tournaments = _dataConnection.GetTournaments_All();
			}
			else
			{
				Tournaments = _dataConnection.GetTournaments_All().
					Where(t => t.TournamentName.ToLower().Contains(SearchTerm.ToLower())).ToList();
			}

		}
	}
}