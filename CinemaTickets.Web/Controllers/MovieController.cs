using CinemaTickets.DataModel.Models;
using CinemaTickets.Services;
using CinemaTickets.Services.Services;
using CinemaTickets.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaTickets.Web.Controllers
{
    public class MovieController : Controller
    {
        private IMovieService _movieService;
        private IEmployeeService _employeeService;
        private IImageService _imageService;
        public string username { get { return HttpContext.User.Identity.Name; } set { } }
        public MovieController()
        {
            this._movieService = new MovieService();
            this._employeeService = new EmployeeService();
            this._imageService = new ImageService();
        }
        // GET: Movie
        public ActionResult Index()
        {
            if (!CheckLoggedInUser())
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
            if(movieFromDb == null)
            {
                return View("Error");
            }
            ViewBag.MovieTitle = movieFromDb.Title;

            return View(movieFromDb);
        }

        public ActionResult MoviePanel()
        {
            if (!CheckLoggedInUser())
            {
                return RedirectToAction("Login", "Account");
            }

            var userFromDb = this._employeeService.GetEmployeeByEmail(username);
            return View(userFromDb);
        }

        public ActionResult AddMovie()
        {
            var movies = this._movieService.GetAllMovies().ToList();
            var model = new MoviesViewModel
            {
                Movies = movies
            };

            return View(model);
        }
        [HttpPost]
        public ActionResult AddMovie(FormCollection data)
        {
            if (Request.Files["files"] != null)
            {
                using (var binaryReader = new BinaryReader(Request.Files["files"].InputStream))
                {
                    var Imagefile = binaryReader.ReadBytes(Request.Files["files"].ContentLength);
                    var image = new Image
                    {
                        ImageData = Imagefile
                    };
                    this._imageService.AddImage(image);

                    var movie = new Movie
                    {
                        Description = data["description"],
                        Genre = data["genre"],
                        Language = data["language"],
                        Minutes = int.Parse(data["minutes"]),
                        Producer = data["producer"],
                        Rating = data["rating"],
                        Title = data["title"],
                        ImageID = image.ImageID
                    };

                    this._movieService.AddMovie(movie);
                }
                return new HttpStatusCodeResult(200, "OK");
            }
            return new HttpStatusCodeResult(400, "Bad request");
        }

        private bool CheckLoggedInUser()
        {
            if (username == "")
            {
                return false;
            }
            return true;
        }
    }
}