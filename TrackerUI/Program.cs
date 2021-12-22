using System;
using System.Windows.Forms;
using TrackerLibraryFrame.Enums;

// TODO - Move to .NET 6

namespace TrackerUI
{
	static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			//Initialize the database connections
			TrackerLibrary.GlobalConfig.InitializeConnections(DatabaseType.Sql);

			Application.Run(new TournamentDashboardForm());
		}
	}
}
