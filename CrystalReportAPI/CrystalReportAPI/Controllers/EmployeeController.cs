using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CrystalReport.Data;


namespace CrystalReportAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        // GET: api/Employee
        EmployeeDAC dac = new EmployeeDAC(); 

        public IEnumerable<Employee> GetAll()
        {
            List<Employee> employees = dac.GetAll();
            return employees;
            
        }

        // GET: api/Employee/5
        public IEnumerable<Employee> Search(int id)
        {
           List<Employee> employees = dac.Search(id);
            return employees;
            
        }

        // POST: api/Employee
        public int Post(Employee employee)
        {
            int result = dac.Save(employee);
            return result;
        }

        // PUT: api/Employee/5
        public int Update(Employee employee)
        {
            int result = dac.Update(employee);
            return result;
        }

        // DELETE: api/Employee/5
        public int Delete(int id)
        {
            int result = dac.Delete(id);
            return result;
        }
    }
}
