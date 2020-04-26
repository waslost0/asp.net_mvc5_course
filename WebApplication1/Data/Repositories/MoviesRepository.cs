using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Data.Repositories
{
    public class MoviesRepository : IMoviesRepository

    {
        private readonly ApplicationDbContext _db;
        public MoviesRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Movie> GetAll()
        {
            return _db.Movies.Include(g => g.Genre).ToList();
        }

        public Movie GetMovie(int id)
        {
            var customer = _db.Movies.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return new Movie { };
            }
            return customer;
        }

        public void CreateMovie(Movie movie)
        {
            _db.Movies.Add(movie);
            _db.SaveChanges();
        }

        public bool DeleteMovie(int id)
        {
            var movieInDb = _db.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
            {
                return false;
            }

            _db.Movies.Remove(movieInDb);
            _db.SaveChanges();
            return true;
        }


        public bool UpdateMovie(int id, Movie movie)
        {
            var movieInDb = _db.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
            {
                return false;
            }

            _db.Movies.Update(movieInDb);
            _db.SaveChanges();
            return true;
        }
    }
}
