using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Data.Interfaces;
using WebApplication1.Data.Repositories;
using WebApplication1.Models;

namespace WebApplication1.Controllers.Api
{

    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        readonly IMoviesRepository _repo;

        public MoviesController(ApplicationDbContext db)
        {
            _repo = new MoviesRepository(db);
        }


        // GET: api/movies
        [HttpGet]
        public IActionResult GetAll()
        {
            var movies = _repo.GetAll();
            return new OkObjectResult(movies);
        }

        // GET api/movies/1
        [HttpGet("{id}")]
        public IActionResult GetMovie(int id)
        {
            var movie = _repo.GetMovie(id);

            if (movie.Id == 0)
            {
                return new NotFoundObjectResult(new { error = "Movie not found.", id });
            }

            return new OkObjectResult(movie);
        }

        // POST: api/movies/create
        [HttpPost("create")]
        public IActionResult CreateMovies(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }

            _repo.CreateMovie(movie);

            return new OkObjectResult(movie);
        }

        // PUT: api/movies/update
        [HttpPut("update")]
        public IActionResult UpdateMovie(int id, Movie movie)
        {
            if (!ModelState.IsValid)
            { 
                return new BadRequestObjectResult(ModelState); 
            }

            var movieInDb = _repo.UpdateMovie(id, movie);

            return !movieInDb ?
                new ObjectResult(new { movieInDb }) { StatusCode = 400 } :
                new OkObjectResult(new { movieInDb });
        }

        // DELETE api/movies/delete
        [HttpDelete("delete")]
        public IActionResult DeleteMovie(int id)
        {
            if (!_repo.DeleteMovie(id))
                return new NotFoundObjectResult(new { error = "Movie not found.", id });

            return new OkObjectResult(new { id, result = "Movie was deleted." }) { StatusCode = 201 };
        }


    }
}