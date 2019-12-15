using CrystalReportClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;


namespace CrystalReportClient.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            string apiUrl = "http://localhost:50909/api/Employee/GetAll";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(apiUrl);
            //string urlParameters = "?api_key=123";
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("").Result;
            List<Employee> employees = new List<Employee>();
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.

                // var dataObjects = response.Content.Re;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                employees = response.Content.ReadAsAsync<List<Employee>>().Result;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            //Make any other calls using HttpClient here.

            //Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();
            return View(employees);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}