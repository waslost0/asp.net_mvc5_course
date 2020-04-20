using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public MoviesController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek" };

            var customers = new List<Customer>
            {

            };

            var viewMovel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewMovel);
        }


        public IActionResult Index(int? pageIndex, string sortBy)
        {
            var movies = _db.Movies.Include(m => m.Genre).ToList();
            if (movies == null)
            {
                return NotFound();
            }
            return View(movies);
        }

        public IActionResult Details(int id)
        {
            var movie = _db.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            return View(movie);
        }


        [Route("movies/released/{year:int:regex(\\d{{4}})}/{month:int:range(1, 12)}")]
        public IActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}
