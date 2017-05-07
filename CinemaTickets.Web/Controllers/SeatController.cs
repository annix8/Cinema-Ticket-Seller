using CinemaTickets.DataModel;
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
    public class SeatController : Controller
    {
        public ActionResult Index()
        {
            var model = CacheViewModel.svm;
            return View(model);
        }

        public ActionResult BuyTickets(FormCollection data)
        {
            var kidsRetirees = int.Parse(data["kidsRetirees"]);
            var students = int.Parse(data["students"]);
            var adults = int.Parse(data["adults"]);
            var projectionID = int.Parse(data["projectionID"]);
            var seats = data["seats"].Split(',').Select(int.Parse).ToArray();
            return new HttpStatusCodeResult(200, "OK");
        }
    }
}