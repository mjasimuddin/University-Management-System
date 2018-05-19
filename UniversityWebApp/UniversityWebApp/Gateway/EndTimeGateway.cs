using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityWebApp.Models;

namespace UniversityWebApp.Gateway
{
    public class EndTimeGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["UniversityManageAppDB"].ConnectionString;

        public List<EndTime> GetAllTimes()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM EndTime";
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<EndTime> endTimes = new List<EndTime>();
            while (reader.Read())
            {
                EndTime endTime = new EndTime
                {
                    Id = (int)reader["Id"],
                    EndId = reader["EndTime"].ToString()
                };

                endTimes.Add(endTime);
            }
            reader.Close();
            connection.Close();
            return endTimes;
        }
    }
}