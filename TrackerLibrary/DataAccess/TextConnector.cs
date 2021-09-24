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

		public PersonModel CreatePerson(PersonModel model)
		{
			List<PersonModel> peopel = PeopleFile.FullFilePath().LoadFile().ConvertToPersonModels();

			var currentId = 1;
			if (peopel.Count > 0)
			{
				currentId = peopel.OrderByDescending(x => x.Id).First().Id + 1;
			}
			model.Id = currentId;

			peopel.Add(model);

			peopel.SaveToPeopleFile(PeopleFile);

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

		public List<PersonModel> GetPerson_All()
		{
			return PeopleFile.FullFilePath().LoadFile().ConvertToPersonModels();
		}
	}
}
