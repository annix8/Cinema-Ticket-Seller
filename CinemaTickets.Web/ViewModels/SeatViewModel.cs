using CinemaTickets.Web.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaTickets.Web.ViewModels
{
    public class SeatViewModel
    {
        public IList<SeatDTO> SeatDtos { get; set; }
        public decimal TotalPrice { get; set; }
        public int KidsRetirees { get; set; }
        public int Students { get; set; }
        public int Adults { get; set; }
    }
}