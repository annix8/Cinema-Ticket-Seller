using CinemaTickets.DataModel;
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
    public class HallController : Controller
    {
        private IHallService _hallService;
        public HallController()
        {
            this._hallService = new HallService();
        }
        public ActionResult Index()
        {
            var allHalls = this._hallService.GetAllHalls().ToList();
            return View(allHalls);
        }

        [HttpPost]
        public ActionResult CreateHall(int hallNumber)
        {
            var hallFromDb = this._hallService.GetHallByHallNumber(hallNumber);
            if (!(hallFromDb == null))
            {
                return new HttpStatusCodeResult(400, "There already is a hall with that number");
            }

            var hallToAdd = new Hall
            {
                HallNumber = hallNumber
            };

            try
            {
                using(var context = new CinemaTicketsDbContext())
                {
                    for (int row = 1; row <= 10; row++)
                    {
                        for (int col = 1; col <= 10; col++)
                        {
                            var seat = new Seat()
                            {
                                Hall = hallToAdd,
                                Row = row,
                                Column = col
                            };
                            context.Seats.Add(seat);
                        }
                    }
                    context.SaveChanges();
                }
                
            }
            catch(Exception e)
            {
                return new HttpStatusCodeResult(400, e.Message);

            }

            return new HttpStatusCodeResult(200, "Success");
        }
    }
}