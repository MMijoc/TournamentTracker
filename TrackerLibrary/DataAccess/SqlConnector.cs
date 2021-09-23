﻿using System.Data;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess
{
	public class SqlConnector : IDataConnection
	{
		//TODO - Make the CreatePrize method actually save to the database
		/// <summary>
		/// Save new prize to the database.
		/// </summary>
		/// <param name="model">The prize information</param>
		/// <returns>The prize information, including the unique identifier.</returns>
		public PrizeModel CreatePrize(PrizeModel model)
		{
			using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("Tournaments")))
			{

			}

			return model;
		}
	}
}
