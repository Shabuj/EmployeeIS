using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using WrittenTest.Models;

namespace WrittenTest.DAL
{

    public class DepartmentGateway
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["Employee"].ConnectionString;
        public List<Department> GetDepartmentList()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Department";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            var departmentList = new List<Department>();
            while (reader.Read())
            {
                int Id = Convert.ToInt32(reader["DepartmentId"]);
                string Name = reader["DepartmentName"].ToString();
               
                Department Dept = new Department(Id, Name);
                departmentList.Add(Dept);
            }
            reader.Close();
            connection.Close();
            return departmentList;
        }

        public void SaveDepartment(Department dept)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO Department(DepartmentName) VALUES('" + dept.DepartmentName + "')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}