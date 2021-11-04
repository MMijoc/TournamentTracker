using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerUI
{
	public partial class TournamentViewerForm : Form
	{
		private TournamentModel tournament;
		BindingList<int> rounds = new BindingList<int>();
		BindingList<MatchupModel> selectedMatchups = new BindingList<MatchupModel>();
		public TournamentViewerForm(TournamentModel tournamentModel)
		{
			InitializeComponent();

			tournament = tournamentModel;

			tournament.OnTournamentComplete += Tournament_OnTournamentComplete;

			WireUpLists();

			LoadFormData();

			LoadRounds();
		}

		private void Tournament_OnTournamentComplete(object sender, DateTime e)
		{
			this.Close();
		}

		private void LoadFormData()
		{
			tournamentName.Text = tournament.TournamentName;
		}

		private void LoadRounds()
		{
			rounds.Clear();

			rounds.Add(1);
			int currentRound = 1;

			foreach (List<MatchupModel> matchups in tournament.Rounds)
			{
				if (matchups.First().MatchupRound > currentRound)
				{
					currentRound = matchups.First().MatchupRound;
					rounds.Add(currentRound);
				}
			}

			LoadMatchups(1);
		}

		private void WireUpLists()
		{
			roundDropdown.DataSource = rounds;
			matchupListbox.DataSource = selectedMatchups;
			matchupListbox.DisplayMember = "DisplayName";
		}

		private void RoundDropdown_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			LoadMatchups((int)roundDropdown.SelectedItem);
		}

		private void LoadMatchups(int round)
		{
			foreach (List<MatchupModel> matchups in tournament.Rounds)
			{
				if (matchups.First().MatchupRound == round)
				{
					selectedMatchups.Clear();
					foreach (MatchupModel m in matchups)
					{
						if (m.Winner == null || !unplayedOnlyCheckbox.Checked)
						{
							selectedMatchups.Add(m); 
						}
					}
				}
			}

			if (selectedMatchups.Count > 0)
			{
				LoadMatchup(selectedMatchups.First()); 
			}

			DisplayMatchupInfo();
		}

		private void DisplayMatchupInfo()
		{
			bool isVisible = (selectedMatchups.Count > 0);

			teamOneName.Visible = isVisible;
			teamOneScoreLabel.Visible = isVisible;
			teamOneScoreValue.Visible = isVisible;
			teamTwoName.Visible = isVisible;
			teamTwoScoreLabel.Visible = isVisible;
			teamTwoScoreValue.Visible = isVisible;
			versusLabel.Visible = isVisible;
			scoreButton.Visible = isVisible;
		}

		private void LoadMatchup(MatchupModel m)
		{
			// When unplayedOnlyCheckbox_CheckedChanged is run it will clear the selectedMatchups which
			// will in turn cause the matchupListbox_SelectedIndexChanged to be run and that will run LoadMatchup with the unreferenced
			// argument that will cause an exception
			// However when the program is run without debugging this error does not occur and program runs just fine, but running it
			// with debugging cause the error ¯\_(ツ)_/¯
			if (m == null)
			{
				return;
			}

			for (int i = 0; i < m.Entries.Count; i++)
			{
				if (i == 0)
				{
					if (m.Entries[0].TeamCompeting != null)
					{
						teamOneName.Text = m.Entries[0].TeamCompeting.TeamName;
						teamOneScoreValue.Text = m.Entries[0].Score.ToString();

						teamTwoName.Text = "<bye>";
						teamTwoScoreValue.Text = "0";
					}
					else
					{
						teamOneName.Text = "Not yet set!";
						teamOneScoreValue.Text = "";
					}
				}

				if (i == 1)
				{
					if (m.Entries[1].TeamCompeting != null)
					{
						teamTwoName.Text = m.Entries[1].TeamCompeting.TeamName;
						teamTwoScoreValue.Text = m.Entries[1].Score.ToString();
					}
					else
					{
						teamTwoName.Text = "Not yet set!";
						teamTwoScoreValue.Text = "";
					}
				}
			}
		}

		private void MatchupListbox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			LoadMatchup((MatchupModel)matchupListbox.SelectedItem);
		}

		private void UnplayedOnlyCheckbox_CheckedChanged(object sender, System.EventArgs e)
		{
			LoadMatchups((int)roundDropdown.SelectedItem);
		}

		private void ScoreButton_Click(object sender, System.EventArgs e)
		{
			string errorMessage = ValidateData();
			if (errorMessage.Length > 0)
			{
				MessageBox.Show($"Input Error: {errorMessage}");
				return;
			}

			MatchupModel m = (MatchupModel)matchupListbox.SelectedItem;

			for (int i = 0; i < m.Entries.Count; i++)
			{
				if (i == 0)
				{
					if (m.Entries[0].TeamCompeting != null)
					{
						bool scoreValid = double.TryParse(teamOneScoreValue.Text, out double teamOneScore);

						if (scoreValid)
						{
							m.Entries[0].Score = teamOneScore;
						}
						else
						{
							MessageBox.Show("Enter a valid score for team 1.");
							return;
						}

					}
				}

				if (i == 1)
				{
					bool scoreValid = double.TryParse(teamTwoScoreValue.Text, out double teamTwoScore);

					if (scoreValid)
					{
						m.Entries[1].Score = teamTwoScore;
					}
					else
					{
						MessageBox.Show("Enter a valid score for team 2.");
						return;
					}
				}
			}

			try
			{
				TournamentLogic.UpdateTournamentResults(tournament);
			}
			catch (Exception ex)
			{
				MessageBox.Show($"The application had the following error {ex.Message}");
				return;
			}

			LoadMatchups((int)roundDropdown.SelectedItem);
		}

		private string ValidateData()
		{
			string output = "";

			bool scoreOneValid = double.TryParse(teamOneScoreValue.Text, out double teamOneScore);
			bool scoreTwoValid = double.TryParse(teamTwoScoreValue.Text, out double teamTwoScore);

			if (!scoreOneValid)
			{
				output = "The Score One value is not valid number.";
			}
			else if (!scoreTwoValid)
			{
				output = "The Score Two value is not valid number.";
			}
			else if (teamOneScore == 0 && teamTwoScore == 0)
			{
				output = "You did not enter a score for either team.";
			}
			else if (teamOneScore == teamTwoScore)
			{
				output = "We do not allow ties in this application.";
			}

			return output;
		}
	}
}
