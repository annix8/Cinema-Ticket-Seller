using CinemaTickets.DataModel.Models;
using CinemaTickets.Services.Contracts;
using CinemaTickets.Web.ViewModels;
using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace CinemaTickets.Web.Controllers
{
    public class MovieController : Controller
    {
        private IMovieService _movieService;
        private IEmployeeService _employeeService;
        private IImageService _imageService;

        public MovieController(IMovieService movieService, IEmployeeService employeeService,
            IImageService imageService)
        {
            this._movieService = movieService;
            this._employeeService = employeeService;
            this._imageService = imageService;
        }


        public ActionResult Index()
        {
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
            if (movieFromDb == null)
            {
                return View("Error");
            }
            ViewBag.MovieTitle = movieFromDb.Title;

            return View(movieFromDb);
        }

        [Authorize]
        public ActionResult MoviePanel()
        {
            var userFromDb = this._employeeService.GetEmployeeByEmail(User.Identity.Name);
            return View(userFromDb);
        }

        [Authorize]
        public ActionResult AddMovie()
        {
            var movies = this._movieService.GetAllMovies().ToList();
            var model = new MoviesViewModel
            {
                Movies = movies
            };

            return View(model);
        }

        [Authorize]
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

        [Authorize]
        [HttpPost]
        public ActionResult DeleteMovie(int movieID)
        {
            try
            {
                this._movieService.DeleteMovie(movieID);
            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(400, "Bad Request");
            }
            return new HttpStatusCodeResult(200, "OK");
        }
    }
}