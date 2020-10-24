using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WrittenTest.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Gender { get; set; }
        public int DepartmentId { get; set; }
        public int CityId { get; set; }

        public virtual ICollection<Department> Departments { get; set; }

        public virtual ICollection<City> Cities { get; set; }

        public Employee(int id, string employeeName, string gender, int deptId, int cityId)
        {
            EmployeeId = id;
            EmployeeName = employeeName;
            Gender = gender;
            DepartmentId = deptId;
            CityId = cityId;
        }
        public Employee()
        {

        }
    }
}