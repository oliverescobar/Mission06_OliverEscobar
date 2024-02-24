using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            ViewBag.Categories = _context.Categories.ToList()
                .OrderBy(x => x.CategoryName)
                .ToList();
            return View("MovieDB", new Application());
        }

        [HttpPost]
        public IActionResult MovieDB(Application response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();
                return View("Confirmation", response);
            }
            else
            {
                ViewBag.Categories = _context.Categories.ToList()
                    .OrderBy(x => x.CategoryName)
                    .ToList();
                return View(response);
            }
        }

//        [HttpPost]

        public IActionResult MovieList()
        {
            var Movie = _context.Movies
                .OrderBy(x => x.Title).ToList();

            return View(Movie);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);
            ViewBag.Categories = _context.Categories.ToList()
                .OrderBy(x => x.CategoryName)
                .ToList();
            return View("MovieDB", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Application updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();
            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);
            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Application removedMovie)
        {
            _context.Movies.Remove(removedMovie);
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}
