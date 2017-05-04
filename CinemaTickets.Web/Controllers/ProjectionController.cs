using CinemaTickets.DataModel.Models;
using CinemaTickets.Services;
using CinemaTickets.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaTickets.Web.Controllers
{
    public class ProjectionController : Controller
    {
        private IProjectionService _projectionService;
        private IMovieService _movieService;
        public ProjectionController()
        {
            this._projectionService = new ProjectionService();
            this._movieService = new MovieService();
        }

        public ActionResult Index(Movie movie)
        {
            var projectionForSelectedMovie = this._projectionService.GetProjectionsByMovie(movie.MovieID).ToList();
            ViewBag.MovieTitle = movie.Title;
            return View(projectionForSelectedMovie);
        }

        public ActionResult CreateProjection()
        {
            var allMovies = this._movieService.GetAllMovies().ToList();
            return View();
        }
    }
}