using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaTickets.Web.Controllers
{
    public class HallController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}