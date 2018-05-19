using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityWebApp.Models;

namespace UniversityWebApp.Gateway
{
    public class DaysGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["UniversityManageAppDB"].ConnectionString;
        public List<Days> GetAllDays()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM Days";
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Days> days = new List<Days>();
            while (reader.Read())
            {
                Days day = new Days
                {
                    Id = (int)reader["Id"],
                    Name = reader["Name"].ToString()
                };

                days.Add(day);
            }
            reader.Close();
            connection.Close();
            return days;
        }
    }
}