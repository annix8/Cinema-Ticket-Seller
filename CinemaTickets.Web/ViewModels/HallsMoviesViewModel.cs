using CinemaTickets.DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaTickets.Web.ViewModels
{
    public class HallsMoviesViewModel
    {
        public IList<Hall> Halls { get; set; }
        public IList<Movie> Movies { get; set; }
    }
}