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
        public ProjectionController()
        {
            this._projectionService = new ProjectionService();
        }

        public ActionResult Index(Movie movie)
        {
            var projectionForSelectedMovie = this._projectionService.GetProjectionsByMovie(movie.MovieID).ToList();
            ViewBag.MovieTitle = movie.Title;
            return View(projectionForSelectedMovie);
        }
    }
}