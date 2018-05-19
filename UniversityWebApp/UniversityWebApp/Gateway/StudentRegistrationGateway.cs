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
    public class StudentRegistrationGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["UniversityManageAppDB"].ConnectionString;
        public bool Check(StudentRegistration aStudentRegistration)
        {
            string todaysDate = aStudentRegistration.Date;

            string dateString = String.Format("{0:dd/MM/yyyy}", todaysDate);
            var connection = new SqlConnection(connectionString);
            var command = new SqlCommand();
            command.CommandText = "SELECT * FROM StudentRegistration WHERE Email='" + aStudentRegistration.Email + "'";
            //command.CommandText = "INSERT INTO DummyDateCheck (Date) VALUES ('" + dateString + "')";
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            return reader.HasRows;
        }

        private string year;
        public string GenerateRegNo(StudentRegistration aStudentRegistration)
        {
            var connection = new SqlConnection(connectionString);
            var command = new SqlCommand();
            command.CommandText = "SELECT Code FROM Departments WHERE Id='" + aStudentRegistration.DepartmentId + "'";
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            Department department = null;
            if (reader.Read())
            {
                department = new Department
                {
                    Code = reader["Code"].ToString()
                };
            }
            string Code = department.Code;
            string todaysDate = aStudentRegistration.Date;
            //string strDate = "26/07/2011"; //Format – dd/MM/yyyy
            //split string date by separator, here I'm using '/'
            string[] arrDate = todaysDate.Split('/');
            //now use array to get specific date object
            string year = arrDate[2];
            string regNo = Code + "-" + year + "-" + Count(aStudentRegistration);
            return regNo;
        }
        public string Count(StudentRegistration aStudentRegistration)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["UniversityManageAppDB"].ConnectionString;
            var connection = new SqlConnection(connectionString);
            var command = new SqlCommand();
            command.CommandText = "SELECT COUNT(DepartmentId) FROM StudentRegistration WHERE DepartmentId='" + aStudentRegistration.DepartmentId + "' ";
            //command.CommandText = "INSERT INTO DummyDateCheck (Date) VALUES ('" + dateString + "')";
            command.Connection = connection;
            connection.Open();
            int count = (int)command.ExecuteScalar();
            count = count + 1;
            string regNo;
            if (count < 10)
            {
                regNo = count.ToString();
                regNo = "00" + regNo;
                return regNo;
            }
            else if (count < 100)
            {
                regNo = count.ToString();
                regNo = "0" + regNo;
                return regNo;
            }
            regNo = count.ToString();
            return regNo;
        }
        public string Register(StudentRegistration aStudentRegistration)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO StudentRegistration (Name, Email, ContactNo, Date, Address, " +
            "DepartmentId, RegNo) VALUES ('" + aStudentRegistration.Name + "','" + aStudentRegistration.Email + "','"
            + aStudentRegistration.ContactNo + "','" + aStudentRegistration.Date + "'" + ",'" + aStudentRegistration.Address
            + "','" + aStudentRegistration.DepartmentId + "','" + aStudentRegistration.RegNo + "')";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            int rowAffected = cmd.ExecuteNonQuery();
            con.Close();
            if (rowAffected > 0)
            {
                return "Student Registration Successful";
            }
            return "Student Registration Failed";
        }

        public StudentRegistration LastStudent()
        {

            int lastId = LastId();
            var connection = new SqlConnection(connectionString);
            var command = new SqlCommand();
            command.CommandText = "SELECT * FROM StudentRegistration WHERE Id='" + lastId + "'";
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            StudentRegistration laStudentRegistration = null;
            if (reader.Read())
            {
                laStudentRegistration = new StudentRegistration
                {
                    Name = reader["Name"].ToString(),
                    Email = reader["Email"].ToString(),
                    Address = reader["Address"].ToString(),
                    ContactNo = reader["ContactNo"].ToString(),
                    Date = reader["Date"].ToString(),
                    RegNo = reader["RegNo"].ToString()
                };
            }
            return laStudentRegistration;
        }

        public int LastId()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["UniversityManageAppDB"].ConnectionString;
            var connection = new SqlConnection(connectionString);
            var command = new SqlCommand();
            command.CommandText = "SELECT MAX(Id) FROM StudentRegistration";
            command.Connection = connection;
            connection.Open();
            int lastId = (int)command.ExecuteScalar();
            return lastId;
        }
        public List<StudentRegistration> GetRegStudentList(int id)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM StudentRegistration WHERE DepartmentId=" + id+"";
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            var studentRegistrations = new List<StudentRegistration>();
            while (reader.Read())
            {
                var studentRegistration = new StudentRegistration
                {
                    Id = (int)reader["Id"],
                    RegNo = reader["RegNo"].ToString()
                };

                studentRegistrations.Add(studentRegistration);
            }
            reader.Close();
            connection.Close();
            return studentRegistrations;
        }
        public List<StudentRegistration> GetStudentDetails(int id)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM StudentRegistration WHERE Id='" + id + "'";
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            var _studentRegistrations = new List<StudentRegistration>();
            while (reader.Read())
            {
                var _studentRegistration = new StudentRegistration();

                _studentRegistration.Name = reader["Name"].ToString();
                _studentRegistration.Email = reader["Email"].ToString();
                    //Name = reader["Name"].ToString(),
                    //Email = reader["Email"].ToString()
                

                _studentRegistrations.Add(_studentRegistration);
            }
            reader.Close();
            connection.Close();
            return _studentRegistrations;
        }
    }
}