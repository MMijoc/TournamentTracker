using System.Configuration;
using TrackerLibrary.DataAccess;
using TrackerLibraryFrame.Enums;

namespace TrackerLibrary
{
	public static class GlobalConfig
	{
		public const string PrizesFile = "PrizeModels.csv";
		public const string PeopleFile = "PersonModels.csv";
		public const string TeamFile = "TeamModels.csv";
		public const string TournamentFile = "TournamentModels.csv";
		public const string MatchupFile = "MatchupModels.csv";
		public const string MatchupEntryFile = "MatchupEntryModels.csv";
		public static IDataConnection Connection { get; private set; }
		public static void InitializeConnections(DatabaseType databaseType)
		{
			if (databaseType == DatabaseType.Sql)
			{
				var sql = new SqlConnector();
				Connection = sql;
			}
			else if (databaseType == DatabaseType.TextFile)
			{
				var text = new TextConnector();
				Connection = text;
			}
		}
		public static string CnnString(string name)
		{
			return ConfigurationManager.ConnectionStrings[name].ConnectionString;
		}

		public static string AppKeyLookup(string key)
		{
			return ConfigurationManager.AppSettings[key];
		}
	}
}
