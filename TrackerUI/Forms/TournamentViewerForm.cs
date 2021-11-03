﻿using System.Collections.Generic;
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

			WireUpLists();

			LoadFormData();

			LoadRounds();
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

		private void roundDropdown_SelectedIndexChanged(object sender, System.EventArgs e)
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

		private void matchupListbox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			LoadMatchup((MatchupModel)matchupListbox.SelectedItem);
		}

		private void unplayedOnlyCheckbox_CheckedChanged(object sender, System.EventArgs e)
		{
			LoadMatchups((int)roundDropdown.SelectedItem);
		}

		private void ScoreButton_Click(object sender, System.EventArgs e)
		{
			MatchupModel m = (MatchupModel)matchupListbox.SelectedItem;
			double teamOneScore = 0;
			double teamTwoScore = 0;

			for (int i = 0; i < m.Entries.Count; i++)
			{
				if (i == 0)
				{
					if (m.Entries[0].TeamCompeting != null)
					{
						bool scoreValid = double.TryParse(teamOneScoreValue.Text, out teamOneScore);

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
					bool scoreValid = double.TryParse(teamTwoScoreValue.Text, out teamTwoScore);

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

			if (teamOneScore > teamTwoScore)
			{
				m.Winner = m.Entries[0].TeamCompeting;
			}
			else if (teamOneScore < teamTwoScore)
			{
				m.Winner = m.Entries[1].TeamCompeting;
			}
			else
			{
				MessageBox.Show("This program does not handle tie games");
			}

			foreach (List<MatchupModel> round in tournament.Rounds)
			{
				foreach (MatchupModel rm in round)
				{
					foreach (MatchupEntryModel me in rm.Entries)
					{
						if (me.ParentMatchup != null)
						{
							if (me.ParentMatchup.Id == m.Id)
							{
								me.TeamCompeting = m.Winner;
								GlobalConfig.Connection.UpdateMatchup(rm);
							} 
						}
					}
				}
			}

			LoadMatchups((int)roundDropdown.SelectedItem);

			GlobalConfig.Connection.UpdateMatchup(m);


		}
	}
}
