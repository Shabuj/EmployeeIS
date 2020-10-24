using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using WrittenTest.Models;

namespace WrittenTest.DAL
{
    public class CityGateway
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["Employee"].ConnectionString;
        public List<City> GetCityList()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM City";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            var cityList = new List<City>();
            while (reader.Read())
            {
                int Id = Convert.ToInt32(reader["CityId"]);
                string Name = reader["CityName"].ToString();

                City Dept = new City(Id, Name);
                cityList.Add(Dept);
            }
            reader.Close();
            connection.Close();
            return cityList;
        }

        public void SaveCity(City city)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO City(CityName) VALUES('" + city.CityName + "')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}