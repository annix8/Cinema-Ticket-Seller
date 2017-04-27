using CinemaTickets.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaTickets.DataModel.Models;
using CinemaTickets.DataModel;

namespace CinemaTickets.Services
{
    public class MovieService : IMovieService
    {
        private CinemaTicketsDbContext _context;
        public MovieService()
        {
            _context = new CinemaTicketsDbContext();
        }
        public void AddMovie(Movie movie)
        {
            this._context.Movies.Add(movie);
        }

        public IQueryable<Movie> GetAllMovies()
        {
            return this._context.Movies;
        }

        public Movie GetMovieById(int id)
        {
            return this._context.Movies.FirstOrDefault(m => m.MovieID == id);
        }
    }
}
