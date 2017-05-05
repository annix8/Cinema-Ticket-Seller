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
        public ActionResult Index(FormCollection data)
        {
            var kidsRetirees = int.Parse(data["kidsRetirees"]);
            var students = int.Parse(data["students"]);
            var adults = int.Parse(data["adults"]);
            var projectionID = int.Parse(data["projectionID"]);
            var totalPrice = decimal.Parse(data["totalPrice"]);
            return View();
        }
    }
}