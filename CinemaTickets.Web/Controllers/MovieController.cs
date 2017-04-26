using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaTickets.Web.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            var username = HttpContext.User.Identity.Name;

            if (username == "")
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }
    }
}