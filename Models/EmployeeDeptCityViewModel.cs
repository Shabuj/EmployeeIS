using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WrittenTest.Models
{
    public class EmployeeDeptCityViewModel
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public string City { get; set; }

        public EmployeeDeptCityViewModel(int employeeId, string name, string gender,  string department, string city)
        {
             EmployeeId = employeeId;
             Name    = name;
             Gender  = gender;
             Department = department;
             City = city;

        }

        public EmployeeDeptCityViewModel()
        {
        }
    }
}