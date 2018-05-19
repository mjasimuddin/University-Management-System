using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityWebApp.Models;

namespace UniversityWebApp.Gateway
{
    public class ViewStudentResultGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["UniversityManageAppDB"].ConnectionString;

        public List<ViewStudentResult> GetAllResults(int id)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM VW_StudentResult WHERE StudentRegistrationId='" + id + "'";
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<ViewStudentResult> _viewStudentResults = new List<ViewStudentResult>();
            while (reader.Read())
            {
                ViewStudentResult _viewStudentResult = new ViewStudentResult
                {
                    CourseCode = reader["Code"].ToString(),
                    CourseName = reader["CourseName"].ToString(),
                    Grade = reader["GradeName"].ToString()
                };

                _viewStudentResults.Add(_viewStudentResult);
            }
            reader.Close();
            connection.Close();
            return _viewStudentResults;

        }
    }
}