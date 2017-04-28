using CinemaTickets.DataModel.Models;
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
        private IEmployeeService _employeeService;
        public string username { get { return HttpContext.User.Identity.Name; } set { } }
        public MovieController()
        {
            this._movieService = new MovieService();
            this._employeeService = new EmployeeService();
        }
        // GET: Movie
        public ActionResult Index()
        {
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
            ViewBag.MovieTitle = movieFromDb.Title;
            return View(movieFromDb);
        }

        public ActionResult MoviePanel()
        {
            var userFromDb = this._employeeService.GetEmployeeByEmail(username);
            return View(userFromDb);
        }

        //TODO: add logic for inserting movie into db
        public ActionResult AddMovie()
        {
            return View(new Movie() {Title = "asdasdsads" });
        }
    }
}