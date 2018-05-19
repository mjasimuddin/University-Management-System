using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityWebApp.Models;

namespace UniversityWebApp.Gateway
{
    public class SaveCourseGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["UniversityManageAppDB"].ConnectionString;
        public bool Check(SaveCourse aCourse)
        {
            var connection = new SqlConnection(connectionString);
            var command = new SqlCommand();
            command.CommandText = "SELECT * FROM Course WHERE Code='" + aCourse.Code + "' OR Name='" + aCourse.Name + "'";
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            return reader.HasRows;
        }
        public string Save(SaveCourse aCourse)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO Course (Code, Name, Credit, Description, DepartmentId, Semester) VALUES ('" + aCourse.Code + "','" + aCourse.Name +
                "','" + aCourse.Credit + "','" + aCourse.Description + "'" + ",'" + aCourse.DepartmentId + "','" + aCourse.Semester + "')";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            int rowAffected = cmd.ExecuteNonQuery();
            if (rowAffected > 0)
            {
                return "New course inserted";
            }
            con.Close();
            return "New course not inserted";

        }
        public List<SaveCourse> GetAllCourses(int id)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM Course WHERE DepartmentId=" + id;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<SaveCourse> courses = new List<SaveCourse>();
            while (reader.Read())
            {
                SaveCourse course = new SaveCourse
                {
                    Id = (int)reader["Id"],
                    Name = reader["Name"].ToString(),
                    Code = reader["Code"].ToString(),
                    Credit = (double)reader["Credit"],
                };

                courses.Add(course);
            }
            reader.Close();
            connection.Close();
            return courses;
        }
        public List<SaveCourse> GateCourseDetail(int id)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM Course WHERE Id=" + id;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<SaveCourse> courses = new List<SaveCourse>();
            while (reader.Read())
            {
                SaveCourse course = new SaveCourse
                {
                    Id = (int)reader["Id"],
                    Name = reader["Name"].ToString(),
                    Code = reader["Code"].ToString(),
                    Credit = (double)reader["Credit"]
                };

                courses.Add(course);
            }
            reader.Close();
            connection.Close();
            return courses;
        }
    }
}