using CinemaTickets.DataModel;
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
    public class ProjectionController : Controller
    {
        private IProjectionService _projectionService;
        private IMovieService _movieService;
        private IHallService _hallService;
        public ProjectionController()
        {
            this._projectionService = new ProjectionService();
            this._movieService = new MovieService();
            this._hallService = new HallService();
        }

        public ActionResult Index(Movie movie)
        {
            var projectionForSelectedMovie = this._projectionService.GetProjectionsByMovie(movie.MovieID).Where(p => p.TimeOfProjection > DateTime.Now).OrderBy(p => p.TimeOfProjection).ToList();
            ViewBag.MovieTitle = movie.Title;
            return View(projectionForSelectedMovie);
        }

        public ActionResult CreateProjection()
        {
            var allMovies = this._movieService.GetAllMovies().ToList();
            var allHalls = this._hallService.GetAllHalls().ToList();

            var model = new HallsMoviesViewModel()
            {
                Halls = allHalls,
                Movies = allMovies
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult CreateProjection(FormCollection data)
        {
            var hallID = int.Parse(data["hallID"]);
            var movieID = int.Parse(data["movieID"]);
            var year = int.Parse(data["year"]);
            var month = int.Parse(data["month"]);
            var day = int.Parse(data["day"]);
            var hours = int.Parse(data["hours"]);
            var minutes = int.Parse(data["minutes"]);
            var date = new DateTime(year,month,day,hours,minutes,0);

            var context = new CinemaTicketsDbContext();
            using (context)
            {
                var projectionWithSameDate = context.Projections.FirstOrDefault(p => p.TimeOfProjection == date && p.HallID == hallID);

                if (!(projectionWithSameDate == null))
                {
                    return new HttpStatusCodeResult(400, "There already is a projection set for that time for this hall");
                }

                var hallFromDb = context.Halls.FirstOrDefault(h => h.HallID == hallID);
                var movieFromDb = context.Movies.FirstOrDefault(m => m.MovieID == movieID);
                if (hallFromDb == null || movieFromDb == null)
                {
                    return new HttpStatusCodeResult(400,"Something went wrong! :(");
                }
                var projection = new Projection
                {
                    Hall = hallFromDb,
                    Movie = movieFromDb,
                    TimeOfProjection = date
                };
                context.Projections.Add(projection);
                context.SaveChanges();
            }
            
            return new HttpStatusCodeResult(200,"OK");
        }
    }
}