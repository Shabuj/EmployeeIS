using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WrittenTest.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string  DepartmentName { get; set; }

        public Department(int id,string name)
        {
            DepartmentId = id;
            DepartmentName = name;
        }
        public Department()
        {

        }
        

    }
}