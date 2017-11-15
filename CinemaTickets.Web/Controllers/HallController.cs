using CinemaTickets.DataModel;
using CinemaTickets.DataModel.Models;
using CinemaTickets.Services.Contracts;
using System;
using System.Linq;
using System.Web.Mvc;

namespace CinemaTickets.Web.Controllers
{
    public class HallController : Controller
    {
        private IHallService _hallService;
        public HallController(IHallService hallService)
        {
            this._hallService = hallService;
        }
        public ActionResult Index()
        {
            var allHalls = this._hallService.GetAllHalls().ToList();
            return View(allHalls);
        }

        [Authorize]
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
                using (var context = new CinemaTicketsDbContext())
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
            catch (Exception e)
            {
                return new HttpStatusCodeResult(400, e.Message);

            }

            return new HttpStatusCodeResult(200, "Success");
        }

        [Authorize]
        [HttpPost]
        public ActionResult DeleteHall(int hallID)
        {
            try
            {
                this._hallService.DeleteHall(hallID);
            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(400, "Something went wrong :(");
            }

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
        }
    }
}