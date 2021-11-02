using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
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
						selectedMatchups.Add(m);
					}
				}
			}

			if (selectedMatchups.Count > 0)
			{
				LoadMatchup(selectedMatchups.First());
			}
		}

		private void LoadMatchup(MatchupModel m)
		{
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
	}
}
