﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TrackerLibrary.Models;
using TrackerLibraryFrame;

namespace TrackerLibrary
{
	public static class TournamentLogic
	{
		public static void CreateRounds(TournamentModel model)
		{
			var randomizedTeams = RandomizeTeamOrder(model.EnteredTeams);
			var rounds = FindNumberOfRounds(randomizedTeams.Count);
			int byes = NumberOfByes(rounds, randomizedTeams.Count);

			model.Rounds.Add(CreateFirstRound(byes, randomizedTeams));

			CreateOtherRounds(model, rounds);

		}

		public static void UpdateTournamentResults(TournamentModel model)
		{
			int startingRound = model.CheckCurrentRound();
			List<MatchupModel> toScore = new List<MatchupModel>();

			foreach (List<MatchupModel> round in model.Rounds)
			{
				foreach (MatchupModel rm in round)
				{
					if ((rm.Entries.Any(x => x.Score != 0) || rm.Entries.Count == 1))
					{
						toScore.Add(rm);
					}
				}
			}

			MarkWinnerInMatchups(toScore);
			AdvanceWinners(toScore, model);
			toScore.ForEach(x => GlobalConfig.Connection.UpdateMatchup(x));

			int endingRound = model.CheckCurrentRound();
			// we have advanced a round -> alert users
			if (endingRound > startingRound)
			{
				model.AlertUsersToNewRound();
			}
		}

		public static void AlertUsersToNewRound(this TournamentModel model)
		{
			int currentRoundNumber = model.CheckCurrentRound();
			List<MatchupModel> currentRound = model.Rounds.Where(x => x.First().MatchupRound == currentRoundNumber).First();

			foreach (MatchupModel matchup in currentRound)
			{
				foreach (MatchupEntryModel me in matchup.Entries)
				{
					foreach (PersonModel p in me.TeamCompeting.TeamMembers)
					{
						AlertPersonToNewRound(p, me.TeamCompeting.TeamName, matchup.Entries.Where(x => x.TeamCompeting != me.TeamCompeting).FirstOrDefault());
					}
				}
			}
		}

		private static void AlertPersonToNewRound(PersonModel p, string teamName, MatchupEntryModel competitor)
		{
			if (p.EmailAddress.Length == 0)
			{
				return;
			}

			string to = "";
			string subject = "";
			StringBuilder body = new StringBuilder();

			if (competitor != null)
			{
				subject = $"You have a new matchup with {competitor.TeamCompeting.TeamName}";

				body.AppendLine("<h1>You have a new matchup</h1>");
				body.Append("<strong>Competitor: </strong>");
				body.Append(competitor.TeamCompeting.TeamName);
				body.AppendLine();
				body.AppendLine();
				body.AppendLine("Have a great time!");
				body.AppendLine("~Tournament Tracker");
			}
			else
			{
				subject = "You have a bye week this round";

				body.AppendLine("Enjoy your round off!");
				body.AppendLine("~Tournament Tracker");
			}

			to = p.EmailAddress;

			EmailLogic.SendEmail(to, subject, body.ToString());
		}

		private static int CheckCurrentRound(this TournamentModel model)
		{
			int output = 1;

			foreach (List<MatchupModel> round in model.Rounds)
			{
				// if every matchup has a winner
				if (round.All(x => x.Winner != null))
				{
					output++;
				}
			}

			return output;
		}

		private static void AdvanceWinners(List<MatchupModel> models, TournamentModel tournament)
		{
			foreach (MatchupModel m in models)
			{
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
			}
	
		}

		private static void MarkWinnerInMatchups(List<MatchupModel> models)
		{
			string greaterWins = ConfigurationManager.AppSettings["greaterWins"];

			foreach (MatchupModel m in models)
			{
				// Checks for bye week entry
				if (m.Entries.Count == 1)
				{
					m.Winner = m.Entries[0].TeamCompeting;
					continue;
				}

				// 0 -> false, or low score wins
				if (greaterWins == "0")
				{
					if (m.Entries[0].Score < m.Entries[1].Score)
					{
						m.Winner = m.Entries[0].TeamCompeting;
					}
					else if (m.Entries[1].Score < m.Entries[0].Score)
					{
						m.Winner = m.Entries[1].TeamCompeting;
					}
					else
					{
						throw new Exception("This application does not allow ties!");
					}
				}
				else
				{
					// !=0 means true, or greater score wins
					if (m.Entries[0].Score > m.Entries[1].Score)
					{
						m.Winner = m.Entries[0].TeamCompeting;
					}
					else if (m.Entries[1].Score > m.Entries[0].Score)
					{
						m.Winner = m.Entries[1].TeamCompeting;
					}
					else
					{
						throw new Exception("This application does not allow ties!");
					}
				} 
			}
		}

		private static void CreateOtherRounds(TournamentModel model, int rounds)
		{
			int round = 2;
			var previousRound = model.Rounds[0];
			var currentRound = new List<MatchupModel>();
			var currentMatchup = new MatchupModel();

			while (round <= rounds)
			{
				foreach (var match in previousRound)
				{
					currentMatchup.Entries.Add(new MatchupEntryModel { ParentMatchup = match });
					if (currentMatchup.Entries.Count > 1)
					{
						currentMatchup.MatchupRound = round;
						currentRound.Add(currentMatchup);
						currentMatchup = new MatchupModel();
					}
				}

				model.Rounds.Add(currentRound);
				previousRound = currentRound;
				currentRound = new List<MatchupModel>();
				round += 1;
			}
		}

		private static List<MatchupModel> CreateFirstRound(int byes, List<TeamModel> teams)
		{
			List<MatchupModel> output = new List<MatchupModel>();
			var current = new MatchupModel();

			foreach (var team in teams)
			{
				current.Entries.Add(new MatchupEntryModel { TeamCompeting = team });
				if (byes > 0 || current.Entries.Count > 1)
				{
					current.MatchupRound = 1;
					output.Add(current);
					current = new MatchupModel();

					if (byes > 0)
					{
						byes -= 1;
					}
				}
			}

			return output;
		}

		private static int NumberOfByes(int rounds, int numberOfTeams)
		{
			int output = 0;
			int totalTeams = 1;

			for (int i = 1; i <= rounds; i++)
			{
				totalTeams *= 2;
			}

			output = totalTeams - numberOfTeams;

			return output;
		}

		private static int FindNumberOfRounds(int teamCount)
		{
			int output = 1;
			int value = 2;

			while (value < teamCount)
			{
				output += 1;
				value *= 2;
			}

			return output;
		}

		private static List<TeamModel> RandomizeTeamOrder(List<TeamModel> teams)
		{
			return teams.OrderBy(x => Guid.NewGuid()).ToList();
		}


	}
}
