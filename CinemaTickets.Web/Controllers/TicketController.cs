using CinemaTickets.Web.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaTickets.Web.Controllers
{
    public class TicketController : Controller
    {
        public ActionResult VisualizeTickets()
        {
            var model = CacheViewModel.tickets;
            return View(model);
        }
    }
}