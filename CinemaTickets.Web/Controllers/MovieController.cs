using CinemaTickets.Services;
using CinemaTickets.Services.Services;
using CinemaTickets.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaTickets.Web.Controllers
{
    public class MovieController : Controller
    {
        private IMovieService _movieService;
        public MovieController()
        {
            this._movieService = new MovieService();
        }
        // GET: Movie
        public ActionResult Index()
        {
            var username = HttpContext.User.Identity.Name;

            if (username == "")
            {
                return RedirectToAction("Login", "Account");
            }

            var movies = this._movieService.GetAllMovies().ToList();

            var model = new MoviesViewModel()
            {
                Movies = movies
            };

            return View(model);
        }

        public ActionResult MovieDetails(int id)
        {
            var movieFromDb = this._movieService.GetMovieById(id);
            return View(movieFromDb);
        }
    }
}