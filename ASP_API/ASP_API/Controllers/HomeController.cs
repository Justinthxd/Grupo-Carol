using ASP_API.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;

namespace ASP_API.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var http = new HttpClient();
            var response = await http.GetStringAsync("https://api.covidtracking.com/v1/us/current.json");
            var response2 = await http.GetStringAsync("https://api.covidtracking.com/v1/states/current.json");
        
            dynamic aux = JsonConvert.DeserializeObject(response);
            dynamic aux2 = JsonConvert.DeserializeObject(response2);

            var list = new List<dynamic>();

            list.Add(aux);
            list.Add(aux2);

            return View(list);
        }

        public async Task<IActionResult> Alabama()
        {
            var http = new HttpClient();
            var response = await http.GetStringAsync("https://api.covidtracking.com/v1/states/al/current.json");
            Alabama aux = JsonConvert.DeserializeObject<Alabama>(response);

            return View(aux);
        }

        public async Task<IActionResult> Idaho()
        {
            var http = new HttpClient();
            var response = await http.GetStringAsync("https://api.covidtracking.com/v1/states/id/current.json");
            dynamic aux = JsonConvert.DeserializeObject(response);
            return View(aux);
        }

        public async Task<IActionResult> Minnesota()
        {
            var http = new HttpClient();
            var response = await http.GetStringAsync("https://api.covidtracking.com/v1/states/mn/current.json");
            dynamic aux = JsonConvert.DeserializeObject(response);
            return View(aux);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}