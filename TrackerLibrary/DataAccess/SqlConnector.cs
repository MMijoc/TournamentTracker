using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess
{
	public class SqlConnector : IDataConnection
	{
		private const string dbName = "Tournaments";

		/// <summary>
		/// Save new person to the databse.
		/// </summary>
		/// <param name="model">The perosn information</param>
		/// <returns>The person information, including the unique identifier.</returns>
		public PersonModel CreatePerson(PersonModel model)
		{
			using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(dbName)))
			{
				var p = new DynamicParameters();
				p.Add("@FirstName", model.FirstName);
				p.Add("@LastName", model.LastName);
				p.Add("@EmailAddress", model.EmailAddress);
				p.Add("@CellphoneNumber", model.CellphoneNumber);
				p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

				connection.Execute("dbo.spPeoples_Insert", p, commandType: CommandType.StoredProcedure);

				model.Id = p.Get<int>("@Id");

				return model;
			}
		}

		/// <summary>
		/// Save new prize to the database.
		/// </summary>
		/// <param name="model">The prize information</param>
		/// <returns>The prize information, including the unique identifier.</returns>
		public PrizeModel CreatePrize(PrizeModel model)
		{
			using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(dbName)))
			{
				var p = new DynamicParameters();
				p.Add("@PlaceNumber", model.PlaceNumber);
				p.Add("@PlaceName", model.PlaceName);
				p.Add("@PrizeAmount", model.PrizeAmount);
				p.Add("@PrizePercentage", model.PrizePercentage);
				p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

				connection.Execute("dbo.spPrizes_Insert", p, commandType: CommandType.StoredProcedure);

				model.Id = p.Get<int>("@Id");

				return model;
			}

		}

		public TeamModel CreateTeam(TeamModel model)
		{
			using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(dbName)))
			{
				var p = new DynamicParameters();
				p.Add("@TeamName", model.TeamName);
				p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

				connection.Execute("dbo.spTeams_Insert", p, commandType: CommandType.StoredProcedure);

				model.Id = p.Get<int>("@Id");

				foreach (var teamMemeber in model.TeamMembers)
				{
					p = new DynamicParameters();
					p.Add("@TeamId", model.Id);
					p.Add("@PersonId", teamMemeber.Id);

					connection.Execute("dbo.spTeamMembers_Insert", p, commandType: CommandType.StoredProcedure);
				}

				return model;
			}
		}

		public void CreateTournament(TournamentModel model)
		{
			using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(dbName)))
			{
				SaveTournament(connection, model);
				SaveTournamentPrizes(connection, model);
				SaveTournamentEntries(connection, model);

			}
		}

		private void SaveTournament(IDbConnection connection, TournamentModel model)
		{
			var p = new DynamicParameters();
			p.Add("@TournamentName", model.TournnamentName);
			p.Add("@EntryFee", model.EntryFee);
			p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

			connection.Execute("dbo.spTournaments_Insert", p, commandType: CommandType.StoredProcedure);

			model.Id = p.Get<int>("@Id");
		}

		private void SaveTournamentPrizes(IDbConnection connection, TournamentModel model)
		{
			foreach (var prize in model.Prizes)
			{
				var p = new DynamicParameters();
				p.Add("@TournamentId", model.Id);
				p.Add("@PrizeId", prize.Id);
				p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

				connection.Execute("dbo.spTeamMembers_Insert", p, commandType: CommandType.StoredProcedure);
			}
		}

		private void SaveTournamentEntries(IDbConnection connection, TournamentModel model)
		{
			foreach (var team in model.EnteredTeams)
			{
				var p = new DynamicParameters();
				p.Add("@TournamentId", model.Id);
				p.Add("@PrizeId", team.Id);
				p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

				connection.Execute("dbo.spTournamentEntries_Insert", p, commandType: CommandType.StoredProcedure);
			}
		}

		public List<PersonModel> GetPerson_All()
		{
			List<PersonModel> output;

			using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(dbName)))
			{
				output = connection.Query<PersonModel>("dbo.spPeople_GetAll").ToList();
			}

			return output;
		}

		public List<TeamModel> GetTeam_All()
		{
			List<TeamModel> output;

			using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(dbName)))
			{
				output = connection.Query<TeamModel>("dbo.spTeam_GetAll").ToList();

				foreach (var team in output)
				{
					var p = new DynamicParameters();
					p.Add("@TeamId", team.Id);

					team.TeamMembers = connection.Query<PersonModel>("dbo.spTeamMembers_GetByTeam", p, commandType: CommandType.StoredProcedure).ToList();
				}
			}

			return output;
		}
	}
}
