using System.Collections.Generic;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerUI
{
	public partial class CreateTournamentForm : Form
	{

		List<TeamModel> availableTeams = GlobalConfig.Connection.GetTeam_All();
		List<TeamModel> selectedTeams = new List<TeamModel>();
		List<PrizeModel> selectedPrizes = new List<PrizeModel>();

		public CreateTournamentForm()
		{
			InitializeComponent();

			WireUpLists();
		}

		private void WireUpLists()
		{
			selectTeamDropdown.DataSource = null;
			selectTeamDropdown.DataSource = availableTeams;
			selectTeamDropdown.DisplayMember = "TeamName";

			tournamentTeamsListBox.DataSource = null;
			tournamentTeamsListBox.DataSource = selectedTeams;
			tournamentTeamsListBox.DisplayMember = "TeamName";

			prizesListBox.DataSource = null;
			prizesListBox.DataSource = selectedPrizes;
			prizesListBox.DisplayMember = "PlaceName";
		}

		private void AddTeamButton_Click(object sender, System.EventArgs e)
		{

			TeamModel t = (TeamModel)selectTeamDropdown.SelectedItem;
			if (t != null)
			{
				availableTeams.Remove(t);
				selectedTeams.Add(t);

				WireUpLists();
			}
		}

		private void CreatePrizeButton_Click(object sender, System.EventArgs e)
		{
			// Call the CreatePrizeForm

			CreatePrizeForm prizeForm = new CreatePrizeForm();
			prizeForm.Show();
		}
	}
}
