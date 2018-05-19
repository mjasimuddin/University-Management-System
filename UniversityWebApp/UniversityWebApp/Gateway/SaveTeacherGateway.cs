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
    public class SaveTeacherGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["UniversityManageAppDB"].ConnectionString;
        public bool Check(SaveTeacher aTeacher)
        {
            var connection = new SqlConnection(connectionString);
            var command = new SqlCommand();
            command.CommandText = "SELECT * FROM SaveTeacher WHERE Email='" + aTeacher.Email + "'";
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            return reader.HasRows;
        }
        public string Save(SaveTeacher aTeacher)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO SaveTeacher (Name, Address, Email, ContactNo, DesignationId, DepartmentId, Credit, RemainingCredit) VALUES ('" + aTeacher.Name + "','" + aTeacher.Address + "','" + aTeacher.Email + "','" + aTeacher.ContactNo + "'" + ",'" + aTeacher.DesignationId + "','" + aTeacher.DepartmentId + "','" + aTeacher.Credit + "','" + aTeacher.Credit + "')";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            int rowAffected = cmd.ExecuteNonQuery();
            con.Close();
            if (rowAffected > 0)
            {
                return "New Teacher inserted";
            }

            return "Teacher not inserted";

        }
        public List<SaveTeacher> GetAllTeachers(int id)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM SaveTeacher WHERE DepartmentId='"+id+"'";
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<SaveTeacher> teachers = new List<SaveTeacher>();
            while (reader.Read())
            {
                SaveTeacher teacher = new SaveTeacher
                {
                    Id = (int)reader["Id"],
                    Name = reader["Name"].ToString(),
                    Credit = (double)reader["Credit"],
                    RemainingCredit = (double)reader["RemainingCredit"]
                };

                teachers.Add(teacher);
            }
            reader.Close();
            connection.Close();
            return teachers;
        }
        public List<SaveTeacher> GetAllteacherDetais(int id)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM SaveTeacher WHERE Id=" + id;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            var teachers = new List<SaveTeacher>();
            while (reader.Read())
            {
                var teacher = new SaveTeacher()
                {
                    Id = (int)reader["Id"],
                    Name = reader["Name"].ToString(),
                    Credit = (double)reader["Credit"],
                    RemainingCredit = (double)reader["RemainingCredit"]
                };

                teachers.Add(teacher);
            }
            reader.Close();
            connection.Close();
            return teachers;
        }
    }
}