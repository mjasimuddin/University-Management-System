using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityWebApp.Models;

namespace UniversityWebApp.Gateway
{
    public class StartTimeGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["UniversityManageAppDB"].ConnectionString;

        public List<StartTime> GetAllTimes()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM StartTime";
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<StartTime> startTimes = new List<StartTime>();
            while (reader.Read())
            {
                StartTime startTime = new StartTime
                {
                    Id = (int)reader["Id"],
                    StartId = reader["StartTime"].ToString()
                };

                startTimes.Add(startTime);
            }
            reader.Close();
            connection.Close();
            return startTimes;
        }
    }
}