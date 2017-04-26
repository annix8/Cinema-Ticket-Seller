using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CinemaTickets.DataModel.Models;
using CinemaTickets.DataModel;

namespace CinemaTickets.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //temporary here...it takes the email of the logged in user
            //TODO: connect this to the employees table in db
            var username = HttpContext.User.Identity.Name;

            var context = new CinemaTicketsDbContext();
            context.Database.Initialize(true);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}