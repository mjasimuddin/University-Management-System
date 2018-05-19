using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityWebApp.Models;

namespace UniversityWebApp.Gateway
{
    public class DesignationTeacherGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["UniversityManageAppDB"].ConnectionString;
        public List<DesignationTeacher> GetAllDesignation()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM DesignationTeacher";
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<DesignationTeacher> designations = new List<DesignationTeacher>();
            while (reader.Read())
            {
                DesignationTeacher designation = new DesignationTeacher
                {
                    Id = (int)reader["Id"],
                    Name = reader["Name"].ToString()
                };

                designations.Add(designation);
            }
            reader.Close();
            connection.Close();
            return designations;
        }
    }
}