using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityWebApp.Models;

namespace UniversityWebApp.Gateway
{
    public class GradeGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["UniversityManageAppDB"].ConnectionString;
        public List<Grade> GetAllGrades()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM Grades";
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Grade> grades = new List<Grade>();
            while (reader.Read())
            {
                Grade grade = new Grade
                {
                    Id = (int)reader["Id"],
                    Name = reader["Name"].ToString()
                };

                grades.Add(grade);
            }
            reader.Close();
            connection.Close();
            return grades;
        }
    }
}