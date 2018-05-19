using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityWebApp.Models;

namespace UniversityWebApp.Gateway
{
    public class SemesterGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["UniversityManageAppDB"].ConnectionString;
        public List<Semester> GetAllSemesters()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM Semester";
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Semester> semesters = new List<Semester>();
            while (reader.Read())
            {
                Semester semester = new Semester
                {
                    Id = (int)reader["Id"],
                    Name = reader["Name"].ToString()
                };

                semesters.Add(semester);
            }
            reader.Close();
            connection.Close();
            return semesters;
        }
    }
}