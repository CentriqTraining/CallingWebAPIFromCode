using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private IHttpClientFactory _fact;
        public HomeController(IHttpClientFactory factory)
        {
            _fact = factory;
        }
        public IActionResult Index()
        {
            string url = "http://centriqdata.azurewebsites.net/data/chuck";

            var client = _fact.CreateClient();
            var result = client.GetStringAsync(url).GetAwaiter().GetResult(); 
            var all = JsonConvert.DeserializeObject<List<Employee>>(result);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
