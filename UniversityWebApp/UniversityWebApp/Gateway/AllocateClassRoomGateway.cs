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
    public class AllocateClassRoomGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["UniversityManageAppDB"].ConnectionString;

        public bool Check(AllocateClassroom _allocateClassroom)
        {
            var connection = new SqlConnection(connectionString);
            var command = new SqlCommand();
            command.CommandText = "SELECT * FROM AllocateClassRooms WHERE RoomId='" + _allocateClassroom.RoomId + "' AND DaysId='" + _allocateClassroom.DaysId + "' AND StartId='" + _allocateClassroom.StartId + "' AND Allocate=1";
            //command.CommandText = "INSERT INTO DummyDateCheck (Date) VALUES ('" + dateString + "')";
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            return reader.HasRows;
        }
        public string Allocate(AllocateClassroom allocateClassroom)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO AllocateClassRooms (DepartmentId, CourseId, RoomId, DaysId, StartId, " +
            "EndId) VALUES ('" + allocateClassroom.DepartmentId + "','" + allocateClassroom.CourseId + "','"
            + allocateClassroom.RoomId + "','" + allocateClassroom.DaysId + "'" + ",'" + allocateClassroom.StartId
            + "','" + allocateClassroom.EndId + "')";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            int rowAffected = cmd.ExecuteNonQuery();
            con.Close();
            if (rowAffected > 0)
            {
                return "Allocated";
            }
            return "Allocation failed";
        }
    }
}