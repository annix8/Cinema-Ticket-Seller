using CinemaTickets.DataModel;
using CinemaTickets.DataModel.Models;
using CinemaTickets.Services;
using CinemaTickets.Services.Services;
using CinemaTickets.Web.Cache;
using CinemaTickets.Web.Dtos;
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
            var projectionForSelectedMovie = this._projectionService
                .GetProjectionsByMovie(movie.MovieID)
                .Where(p => p.TimeOfProjection > DateTime.Now)
                .OrderBy(p => p.TimeOfProjection)
                .ToList();

            Session["movieTitle"] = movie.Title;

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
            var date = new DateTime(year, month, day, hours, minutes, 0);

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
                    return new HttpStatusCodeResult(400, "Something went wrong! :(");
                }

                var projection = new Projection
                {
                    Hall = hallFromDb,
                    Movie = movieFromDb,
                    TimeOfProjection = date
                };
                context.Projections.Add(projection);

                var seats = projection.Hall.Seats.ToList();
                foreach (var seat in seats)
                {
                    context.Tickets.Add(new Ticket
                    {
                        IsSold = false,
                        Projection = projection,
                        Seat = seat
                    });
                }

                context.SaveChanges();
            }

            return new HttpStatusCodeResult(200, "OK");
        }

        [HttpPost]
        public ActionResult RedirectProjectionData(FormCollection data)
        {
            try
            {
                var kidsRetirees = int.Parse(data["kidsRetirees"]);
                var students = int.Parse(data["students"]);
                var adults = int.Parse(data["adults"]);
                var projectionID = int.Parse(data["projectionID"]);
                var totalPrice = decimal.Parse(data["totalPrice"]);
                var projectionTime = data["projectionTime"].Split(' ');
                Session["ticketDate"] = projectionTime[0];
                Session["ticketHour"] = projectionTime[1] + projectionTime[2];

                var seatDtos = new List<SeatDTO>();
                using (var context = new CinemaTicketsDbContext())
                {
                    var projection = context.Projections.FirstOrDefault(p => p.ProjectionID == projectionID);
                    var hallNumber = context.Halls.FirstOrDefault(h => h.HallID == projection.HallID).HallNumber;
                    Session["hallNumber"] = hallNumber;
                    var tickets = projection.Tickets.ToList();

                    foreach (var ticket in tickets)
                    {
                        var seatDto = new SeatDTO
                        {
                            Column = ticket.Seat.Column,
                            Row = ticket.Seat.Row,
                            HallID = ticket.Seat.HallID,
                            SeatID = ticket.Seat.SeatID
                        };

                        if (ticket.IsSold)
                        {
                            seatDto.IsTaken = true;
                        }
                        else
                        {
                            seatDto.IsTaken = false;
                        }
                        seatDtos.Add(seatDto);
                    }
                }

                var model = new SeatViewModel()
                {
                    Adults = adults,
                    KidsRetirees = kidsRetirees,
                    SeatDtos = seatDtos,
                    Students = students,
                    TotalPrice = totalPrice,
                    ProjectionID = projectionID
                };
                CacheViewModel.CacheModel(model);
            }

            catch (Exception e)
            {
                return new HttpStatusCodeResult(400, "Something went wrong! :(");
            }

            return new HttpStatusCodeResult(200, "OK");
        }
    }
}