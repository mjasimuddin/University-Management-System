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
    public class CourseAssignTeacherGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["UniversityManageAppDB"].ConnectionString;

        public bool AssignedOrNot(CourseAssignTeacher courseAssignTeacher)
        {
            var connection = new SqlConnection(connectionString);
            var command = new SqlCommand();
            command.CommandText = "SELECT * FROM Course WHERE Id='" + courseAssignTeacher.CourseId + "' AND AssignTo!='" + 0 + "'";
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            return reader.HasRows;
        }

        public string AssignCourseToTeacher(CourseAssignTeacher courseAssignTeacher)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "UPDATE Course SET AssignTo='" + courseAssignTeacher.TeacherId + "' WHERE Id='" + courseAssignTeacher.CourseId + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            int rowAffected = cmd.ExecuteNonQuery();
            if (rowAffected > 0)
            {
                return "Course Assigned";
            }
            con.Close();
            return "Course Assign Failed";
        }

        public void UpdateRemainingCredit(CourseAssignTeacher courseAssignTeacher)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            double newRemCredit = courseAssignTeacher.RemainingCredit - courseAssignTeacher.CourseCredit;
            cmd.CommandText = "UPDATE SaveTeacher SET RemainingCredit='" + newRemCredit + "' WHERE Id='" + courseAssignTeacher.TeacherId + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}