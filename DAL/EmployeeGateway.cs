using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using WrittenTest.Models;

namespace WrittenTest.DAL
{

    public class EmployeeGateway
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["Employee"].ConnectionString;
        public List<EmployeeDeptCityViewModel> GetEmployees()
        {
            
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT Employee.EmployeeId, Employee.EmployeeName, Employee.Gender, Department.DepartmentName, City.CityName FROM Employee INNER JOIN Department ON Employee.DepartmentId = Department.DepartmentId INNER JOIN City ON Employee.CityId = City.CityId ORDER BY Employee.EmployeeId DESC ";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            var employeeList= new List<EmployeeDeptCityViewModel>();
            while(reader.Read())
            {
                int Id = Convert.ToInt32(reader["EmployeeId"]);
                string Name = reader["EmployeeName"].ToString();
                string Gender = reader["Gender"].ToString();
                string Department = reader["DepartmentName"].ToString();
                string City = reader["CityName"].ToString();

                EmployeeDeptCityViewModel employeeDept = new EmployeeDeptCityViewModel(Id,Name, Gender, Department, City);

                employeeList.Add(employeeDept);
            }
            reader.Close();
            connection.Close();
            return employeeList;
        }

        public Employee EmployeeItemById(int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Employee WHERE Employee.EmployeeId='" + id + "' ";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            var employee = new Employee();
            while (reader.Read())
            {
                int Id = Convert.ToInt32(reader["EmployeeId"]);
                string Name = reader["EmployeeName"].ToString();
                string Gender = reader["Gender"].ToString();
                int DeptId = Convert.ToInt32(reader["DepartmentId"]);
                int CityId = Convert.ToInt32(reader["CityId"]);

                Employee employeeDept = new Employee(Id, Name, Gender, DeptId, CityId);
                employee = employeeDept;

            }

            reader.Close();
            connection.Close();
            return employee;
        }

        public void UpdateEmployee(Employee employee)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "UPDATE Employee SET EmployeeName ='" + employee.EmployeeName + "', Gender = '" + employee.Gender + "', DepartmentId ='" + employee.DepartmentId + "', CityId = '" + employee.CityId + "' WHERE EmployeeId='"+employee.EmployeeId+"'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public EmployeeDeptCityViewModel employeeDetailsById(int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT Employee.EmployeeId,Employee.EmployeeName, Employee.Gender, Department.DepartmentName, City.CityName FROM Employee INNER JOIN Department ON Employee.DepartmentId = Department.DepartmentId INNER JOIN City ON Employee.CityId = City.CityId WHERE Employee.EmployeeId='" + id + "' ";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            var employee = new EmployeeDeptCityViewModel();
            while (reader.Read())
            {
                int Id = Convert.ToInt32(reader["EmployeeId"]);
                string Name = reader["EmployeeName"].ToString();
                string Gender = reader["Gender"].ToString();
                string Department = reader["DepartmentName"].ToString();
                string City = reader["CityName"].ToString();

                EmployeeDeptCityViewModel employeeDept = new EmployeeDeptCityViewModel(Id, Name, Gender, Department, City);
                employee = employeeDept;

            }

            reader.Close();
            connection.Close();
            return employee;
        }

        public void DeleteEmployeeById(int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "DELETE FROM Employee WHERE EmployeeId='"+id+"'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public EmployeeDeptCityViewModel  DeleteEmployeeItem(int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT Employee.EmployeeId,Employee.EmployeeName, Employee.Gender, Department.DepartmentName, City.CityName FROM Employee INNER JOIN Department ON Employee.DepartmentId = Department.DepartmentId INNER JOIN City ON Employee.CityId = City.CityId WHERE Employee.EmployeeId='" + id+"' ";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            var employee = new EmployeeDeptCityViewModel();
            while (reader.Read())
            {
                int Id = Convert.ToInt32(reader["EmployeeId"]);
                string Name = reader["EmployeeName"].ToString();
                string Gender = reader["Gender"].ToString();
                string Department = reader["DepartmentName"].ToString();
                string City = reader["CityName"].ToString();

                EmployeeDeptCityViewModel employeeDept = new EmployeeDeptCityViewModel(Id, Name, Gender, Department, City);
                employee = employeeDept;

            }
           
            reader.Close();
            connection.Close();
            return employee;

        }

        public void CreateEmployee(Employee employee)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO Employee(EmployeeName,Gender,DepartmentId,CityId) VALUES('" + employee.EmployeeName + "','" + employee.Gender + "','" + employee.DepartmentId + "','" + employee.CityId + "')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

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
              
                Department dept = new Department(Id,Name);
                departmentList.Add(dept);
            }
            reader.Close();
            connection.Close();
            return departmentList;
        }

        public List<City> GetCityList()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["Employee"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM City";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            var cityList = new List<City>();
            while (reader.Read())
            {
                int Id = Convert.ToInt32(reader["CityId"]);
                string cityName = reader["CityName"].ToString();

                City city = new City(Id,cityName);
                cityList.Add(city);
            }
            reader.Close();
            connection.Close();
            return cityList;
        }
    }
}