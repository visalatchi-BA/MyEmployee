using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLitePCL;

namespace MyEmployee.Model
{
    public class Employee
    {
        [PrimaryKey]
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

    }
}
