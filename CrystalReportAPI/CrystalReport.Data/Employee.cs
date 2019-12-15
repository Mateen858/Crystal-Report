using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrystalReport.Data
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateofBirth { get; set; }
        public float Salary { get; set; }

    }
}