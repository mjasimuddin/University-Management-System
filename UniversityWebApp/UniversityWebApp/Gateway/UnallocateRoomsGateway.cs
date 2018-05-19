using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace UniversityWebApp.Gateway
{
    public class UnallocateRoomsGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["UniversityManageAppDB"].ConnectionString;

        public string Unallocate()
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "UPDATE AllocateClassRooms SET Allocate= '" + 0 + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            int rowAffected = cmd.ExecuteNonQuery();
            if (rowAffected > 0)
            {
                return "Unallocate Successfull";
            }
            con.Close();
            return "Unallocate Failed";
        }
    }
}