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
    public class EnrollCourseGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["UniversityManageAppDB"].ConnectionString;
        public bool Check(EnrollCourse _enrollCourse)
        {
            var connection = new SqlConnection(connectionString);
            var command = new SqlCommand();
            command.CommandText = "SELECT * FROM EnrolledCourse WHERE StudentRegistrationId='" + _enrollCourse.StudentRegId + "' AND CourseId='" + _enrollCourse.CourseId + "' AND Result=1";
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            return reader.HasRows;
        }
        public string SaveEnroll(EnrollCourse _enrollCourse)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO EnrolledCourse (StudentRegistrationId, CourseId, Date,Result) VALUES ('" + _enrollCourse.StudentRegId + "','" + _enrollCourse.CourseId + "','"
            + _enrollCourse.Date + "')";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            int rowAffected = cmd.ExecuteNonQuery();
            con.Close();
            if (rowAffected > 0)
            {
                return "Course enroll success";
            }

            return "Course enroll failed";

        }
    }
}