using TrackerLibrary.Models;
using TrackerLibraryFrame.DataAccess.TextHelpers;
using System.Linq;
using System.Collections.Generic;

namespace TrackerLibrary.DataAccess
{
	class TextConnector : IDataConnection
	{
		private const string PrizesFile = "PrizeModels.csv";
		private const string PeopleFile = "PersonModels.csv";
		private const string TeamFile = "TeamModels.csv";


		public PersonModel CreatePerson(PersonModel model)
		{
			List<PersonModel> people = PeopleFile.FullFilePath().LoadFile().ConvertToPersonModels();

			var currentId = 1;
			if (people.Count > 0)
			{
				currentId = people.OrderByDescending(x => x.Id).First().Id + 1;
			}
			model.Id = currentId;

			people.Add(model);

			people.SaveToPeopleFile(PeopleFile);

			return model;
		}

		public PrizeModel CreatePrize(PrizeModel model)
		{
			List<PrizeModel> prizes = PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModels();

			var currentId = 1;
			if (prizes.Count > 0)
			{
				currentId = prizes.OrderByDescending(x => x.Id).First().Id + 1;
			}
			model.Id = currentId;

			prizes.Add(model);

			prizes.SaveToPrizeFile(PrizesFile);

			return model;
		}

		public TeamModel CreateTeam(TeamModel model)
		{
			List<TeamModel> teams = TeamFile.FullFilePath().LoadFile().ConvertToTeamsModels(PeopleFile);

			var currentId = 1;
			if (teams.Count > 0)
			{
				currentId = teams.OrderByDescending(x => x.Id).First().Id + 1;
			}
			model.Id = currentId;

			teams.Add(model);
			teams.SaveToTeamFile(TeamFile);
			return null;
		}

		public List<PersonModel> GetPerson_All()
		{
			return PeopleFile.FullFilePath().LoadFile().ConvertToPersonModels();
		}
	}
}
