using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wwwPostgresSQL.Models;
using Npgsql;
using wwwPostgresSQL.Interfaces;

namespace wwwPostgresSQL.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        private IDataAccess _dataAccess;
        public IActionResult Index()
        {
            var model = _dataAccess.Execute("select * from public.employee limit 1000;");

            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
