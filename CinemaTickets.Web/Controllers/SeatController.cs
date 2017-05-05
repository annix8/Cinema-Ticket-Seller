using CinemaTickets.DataModel;
using CinemaTickets.Web.Dtos;
using CinemaTickets.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaTickets.Web.Controllers
{
    public class SeatController : Controller
    {
        [HttpPost]
        public ActionResult Index()
        {
            return View();
        }
    }
}