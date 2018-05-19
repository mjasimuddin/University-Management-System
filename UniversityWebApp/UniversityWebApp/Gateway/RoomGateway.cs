using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityWebApp.Models;

namespace UniversityWebApp.Gateway
{
    public class RoomGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["UniversityManageAppDB"].ConnectionString;
        public List<Rooms> GetAllRooms()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM Rooms";
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Rooms> rooms = new List<Rooms>();
            while (reader.Read())
            {
                Rooms room = new Rooms
                {
                    Id = (int)reader["Id"],
                    RoomNo = reader["RoomNo"].ToString()
                };

                rooms.Add(room);
            }
            reader.Close();
            connection.Close();
            return rooms;
        }
    }
}