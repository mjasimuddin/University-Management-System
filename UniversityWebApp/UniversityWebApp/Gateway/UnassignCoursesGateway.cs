using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace UniversityWebApp.Gateway
{
    public class UnassignCoursesGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["UniversityManageAppDB"].ConnectionString;

        public string Unassign()
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "UPDATE EnrolledCourse SET Result= '" + 0 + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            int rowAffected = cmd.ExecuteNonQuery();
            if (rowAffected > 0)
            {
                return "Unassign Successfull";
            }
            con.Close();
            return "Unassign Failed";
        }
    }
}