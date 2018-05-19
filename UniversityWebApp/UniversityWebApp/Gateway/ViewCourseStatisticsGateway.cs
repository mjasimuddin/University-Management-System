using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityWebApp.Models;

namespace UniversityWebApp.Gateway
{
    public class ViewCourseStatisticsGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["UniversityManageAppDB"].ConnectionString;

        public List<ViewCourseStatistics> GetAllStatistics(int id)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM VW_CourseStatistics WHERE DepartmentId='" + id + "'";
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<ViewCourseStatistics> viewCourseStatisticses = new List<ViewCourseStatistics>();
            while (reader.Read())
            {
                ViewCourseStatistics viewCourseStatistics = new ViewCourseStatistics
                {
                    CourseCode = reader["Code"].ToString(),
                    CourseName = reader["Name"].ToString(),
                    SemesterName = reader["SemesterName"].ToString(),
                    AssignedTo = reader["TeacherName"].ToString()
                };

                viewCourseStatisticses.Add(viewCourseStatistics);
            }
            reader.Close();
            connection.Close();
            return viewCourseStatisticses;

        }
    }
}