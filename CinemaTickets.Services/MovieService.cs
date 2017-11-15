using CinemaTickets.Services.Contracts;
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
        public MovieService(CinemaTicketsDbContext ctx)
        {
            _context = ctx;
        }
        public void AddMovie(Movie movie)
        {
            this._context.Movies.Add(movie);
            this._context.SaveChanges();
        }

        public void DeleteMovie(int movieID)
        {
            var movieToDelete = this._context.Movies.FirstOrDefault(m => m.MovieID == movieID);
            this._context.Movies.Remove(movieToDelete);
            this._context.SaveChanges(); 
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
