using CinemaTickets.DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaTickets.Web.Controllers
{
    public class ProjectionController : Controller
    {
        public ActionResult Index(Movie movie)
        {
            return View(movie);
        }
    }
}