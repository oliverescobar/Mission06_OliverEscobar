using Microsoft.AspNetCore.Mvc;
using Mission06_OliverEscobar.Models;
using SQLitePCL;
using System.Diagnostics;

namespace Mission06_OliverEscobar.Controllers
{
    public class HomeController : Controller
    {

        private HiltonMoviesContext _context;

        public HomeController(HiltonMoviesContext temp)
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieDB()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MovieDB(Application response)
        {
            _context.Application.Add(response);
            _context.SaveChanges();
            return View("Confirmation", response);
        }

//        [HttpPost]



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
