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
    public class SaveStudentResultGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["UniversityManageAppDB"].ConnectionString;

        public bool Check(SaveStubentResult aSaveStubentResult)
        {
            var connection = new SqlConnection(connectionString);
            var command = new SqlCommand();
            command.CommandText = "SELECT * FROM EnrolledCourse WHERE StudentRegistrationId='" + aSaveStubentResult.StudentRegId + "' AND CourseId='" + aSaveStubentResult.CourseId + "' and Result!='" + 0 + "'";
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            return reader.HasRows;
        }

        public string SaveResult(SaveStubentResult saveStubentResult)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "UPDATE EnrolledCourse SET Result= '" + saveStubentResult.GradeId + "' WHERE StudentRegistrationId='" + saveStubentResult.StudentRegId + "' AND CourseId='" + saveStubentResult.CourseId + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            int rowAffected = cmd.ExecuteNonQuery();
            if (rowAffected > 0)
            {
                return "Result Saved";
            }
            con.Close();
            return "Result not Saved";
        }

        public List<EnrolledCourseList> GateCourseList(int id)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM EnrolledCourse WHERE StudentRegistrationId='"+ id+"'";
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<EnrolledCourseList> _enrolledCourseLists = new List<EnrolledCourseList>();
            while (reader.Read())
            {
                EnrolledCourseList _enrolledCourseList = new EnrolledCourseList
                {
                    Id = (int)reader["CourseId"],
                    Code = reader["Code"].ToString()
                };

                _enrolledCourseLists.Add(_enrolledCourseList);
            }
            reader.Close();
            connection.Close();
            return _enrolledCourseLists;
        }
    }
}