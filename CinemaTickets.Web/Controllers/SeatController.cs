using CinemaTickets.DataModel;
using CinemaTickets.DataModel.Models;
using CinemaTickets.Web.Cache;
using CinemaTickets.Web.Constants;
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

            List<decimal> ticketTypesPrices = new List<decimal>();
            List<Ticket> boughtTickets = new List<Ticket>();

            if (kidsRetirees != 0)
                for (int i = 1; i <= kidsRetirees; i++)
                {
                    ticketTypesPrices.Add(TicketPrices.kidsRetirees);
                }

            if (students != 0)
                for (int i = 1; i <= students; i++)
                {
                    ticketTypesPrices.Add(TicketPrices.students);
                }

            if (adults != 0)
                for (int i = 1; i <= adults; i++)
                {
                    ticketTypesPrices.Add(TicketPrices.adults);
                }


            using (var context = new CinemaTicketsDbContext())
            {
                var tickets = context.Projections.FirstOrDefault(p => p.ProjectionID == projectionID).Tickets.ToList();
                var counter = 0;
                foreach (var ticket in tickets)
                {
                    foreach (var seat in seats)
                    {
                        if (ticket.SeatID == seat)
                        {
                            ticket.IsSold = true;
                            ticket.Price = ticketTypesPrices[counter];
                            counter++;
                            boughtTickets.Add(ticket);
                        }
                    }
                }
                context.SaveChanges();
            }
            CacheViewModel.CacheModel(boughtTickets);
            return new HttpStatusCodeResult(200, "OK");
        }
    }
}