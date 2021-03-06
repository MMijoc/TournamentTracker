using System.Collections.Generic;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerUI
{
	public partial class TournamentDashboardForm : Form
	{
		List<TournamentModel> tournaments = GlobalConfig.Connection.GetTournaments_All();
		public TournamentDashboardForm()
		{
			InitializeComponent();

			WireUpLists();
		}

		private void WireUpLists()
		{
			loadExistingTournamentDropdown.DataSource = tournaments;
			loadExistingTournamentDropdown.DisplayMember = "TournamentName";
		}

		private void CreateTournamentButton_Click(object sender, System.EventArgs e)
		{
			CreateTournamentForm frm = new CreateTournamentForm();
			frm.Show();
		}

		private void LoadTournamentButton_Click(object sender, System.EventArgs e)
		{
			TournamentModel tm = (TournamentModel)loadExistingTournamentDropdown.SelectedItem;
			TournamentViewerForm form = new TournamentViewerForm(tm);
			form.Show();
		}
	}
}
