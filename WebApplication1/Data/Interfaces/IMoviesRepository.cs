using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data.Interfaces
{
    public interface IMoviesRepository
    {
        IEnumerable<Movie> GetAll();

        Movie GetMovie(int id);

        void CreateMovie(Movie movie);

        bool UpdateMovie(int id, Movie movie);

        bool DeleteMovie(int id);


    }
}
