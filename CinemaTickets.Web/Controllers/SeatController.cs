﻿using CinemaTickets.DataModel;
using CinemaTickets.DataModel.Models;
using CinemaTickets.Web.Cache;
using CinemaTickets.Web.Constants;
using CinemaTickets.Web.Dtos;
using CinemaTickets.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaTickets.Web.Controllers
{
    public class SeatController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            var model = CacheViewModel.svm;
            return View(model);
        }

        [Authorize]
        public ActionResult BuyTickets(FormCollection data)
        {
            var kidsRetirees = int.Parse(data["kidsRetirees"]);
            var students = int.Parse(data["students"]);
            var adults = int.Parse(data["adults"]);
            var projectionID = int.Parse(data["projectionID"]);
            var seats = data["seats"].Split(',').Select(int.Parse).ToArray();

            List<decimal> ticketTypesPrices = new List<decimal>();
            var ticketsBought = new Dictionary<Ticket, int[]>();

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
                try
                {
                    var tickets = context.Projections.FirstOrDefault(p => p.ProjectionID == projectionID).Tickets.ToList();
                    var counter = 0;
                    var usernameEmail = User.Identity.Name;
                    foreach (var ticket in tickets)
                    {
                        foreach (var seat in seats)
                        {
                            if (ticket.SeatID == seat)
                            {
                                var userSoldCurrentTicket = context.Employees.FirstOrDefault(e => e.Email == usernameEmail);
                                var currentSeat = ticket.Seat;
                                ticket.IsSold = true;
                                ticket.Price = ticketTypesPrices[counter];
                                ticket.Employee = userSoldCurrentTicket;
                                counter++;
                                ticketsBought[ticket] = new int[] { currentSeat.Row, currentSeat.Column };
                            }
                        }
                    }
                    context.SaveChanges();
                }
                catch(OptimisticConcurrencyException ex)
                {

                }
            }
            CacheViewModel.CacheModel(ticketsBought);
            return new HttpStatusCodeResult(200, "OK");
        }
    }
}