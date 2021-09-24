using TrackerLibrary.Models;
using TrackerLibraryFrame.DataAccess.TextHelpers;
using System.Linq;

namespace TrackerLibrary.DataAccess
{
	class TextConnector : IDataConnection
	{
		private const string PrizesFile = "PrizeModels.csv";
		//TODO - Wire up the CreatePrize for text files
		public PrizeModel CreatePrize(PrizeModel model)
		{
			// Load the text file
			// Convert the text to List<PrizeModel>
			var prizes = PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModels();

			// Find the new ID
			var currentId = 1;
			if (prizes.Count > 0)
			{
				currentId = prizes.OrderByDescending(x => x.Id).First().Id + 1;

			}
			model.Id = currentId;

			// Add new record with the new ID (max + 1)
			prizes.Add(model);

			// Convert the prizes to list<string>
			// Save the list<string> to the txt file
			prizes.SaveToPrizeFile(PrizesFile);

			return model;
		}
	}
}
