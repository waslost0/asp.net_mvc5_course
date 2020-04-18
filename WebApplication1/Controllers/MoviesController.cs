using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class MoviesController : Controller
    {
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
            var movies = GetMovies();
            if (movies == null)
            {
                return NotFound();
            }
            return View(movies);
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 0, Name = "Slark"},
                new Movie { Id = 1 , Name = "Flash"}
            };
        }

        [Route("movies/released/{year:int:regex(\\d{{4}})}/{month:int:range(1, 12)}")]
        public IActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}
