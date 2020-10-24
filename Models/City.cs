using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WrittenTest.Models
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }

        public City(int id,  string cityName )
        {
            CityId = id;
            CityName = cityName;
        }
        public City()
        {

        }
    }
}