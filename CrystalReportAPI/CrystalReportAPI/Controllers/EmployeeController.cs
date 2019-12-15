using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Http.Cors;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalReport.Data;


namespace CrystalReportAPI.Controllers
{
    [EnableCors(origins: "http://localhost:54001", headers: "*", methods: "*")]
    public class EmployeeController : ApiController
    {
        // GET: api/Employee
        EmployeeDAC dac = new EmployeeDAC(); 
        [HttpGet]
        [Route("api/Employee/GetAll")]
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
        [HttpGet]
        [Route("api/Employee/GetReport")]
        public string GetReport()
        {
            ReportDocument reportDocument = new ReportDocument();
            List<Employee> employees = GetAll().ToList();
            reportDocument.Load(Path.Combine(HostingEnvironment.MapPath("~/CrystalReport1.rpt")));
            reportDocument.SetDataSource(employees);

    Stream s = reportDocument.ExportToStream(ExportFormatType.PortableDocFormat);
            MemoryStream ms = new MemoryStream();
            s.CopyTo(ms);
            return Convert.ToBase64String(ms.ToArray());
        }
    }
}
