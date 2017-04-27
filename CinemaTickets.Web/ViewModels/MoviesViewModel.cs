using CinemaTickets.DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaTickets.Web.ViewModels
{
    public class MoviesViewModel
    {
        public IList<Movie> Movies { get; set; }
    }
}