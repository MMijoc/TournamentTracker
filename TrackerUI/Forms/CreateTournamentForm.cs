using System.Collections.Generic;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.Models;
using TrackerLibraryFrame;
using TrackerUIFrame;

namespace TrackerUI
{
	public partial class CreateTournamentForm : Form, IPrizeRequester, ITeamRequester
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
			CreatePrizeForm prizeForm = new CreatePrizeForm(this);
			prizeForm.Show();
		}

		public void PrizeComplete(PrizeModel model)
		{
			selectedPrizes.Add(model);
			WireUpLists();
		}

		public void TeamComplete(TeamModel model)
		{
			selectedTeams.Add(model);
			WireUpLists();
		}

		private void CreateNewTeamLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CreateTeamForm teamForm = new CreateTeamForm(this);
			teamForm.Show();
		}

		private void RemoveSelectedPlayerButton_Click(object sender, System.EventArgs e)
		{
			TeamModel team = (TeamModel)tournamentTeamsListBox.SelectedItem;
			if (team != null)
			{
				selectedTeams.Remove(team);
				availableTeams.Add(team);
				WireUpLists();
			}

		}

		private void RemoveSelectedPrizeButton_Click(object sender, System.EventArgs e)
		{
			PrizeModel prize = (PrizeModel)prizesListBox.SelectedItem;

			if (prize != null)
			{
				selectedPrizes.Remove(prize);
				WireUpLists();
			}
		}

		private void CreateTournamentButton_Click(object sender, System.EventArgs e)
		{
			// Validate data
			bool feeAcceptable = decimal.TryParse(entryFeeValue.Text, out decimal fee);
			if (feeAcceptable == false)
			{
				MessageBox.Show("Invalid entry fee!",
					"Invalid Fee",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);

				return;
			}

			TournamentModel model = new TournamentModel();
			model.TournamentName = tournamentNameValue.Text;
			model.EntryFee = fee;
			model.Prizes = selectedPrizes;
			model.EnteredTeams = selectedTeams;

			TournamentLogic.CreateRounds(model);

			GlobalConfig.Connection.CreateTournament(model);

			model.AlertUsersToNewRound();

			TournamentViewerForm form = new TournamentViewerForm(model);
			form.Show();
			this.Close();
		}
	}
}
