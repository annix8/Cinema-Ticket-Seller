using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.DataModel.Models
{
    public class Movie
    {
        public int MovieID { get; set; }
        public string Title { get; set; }
        public string Rating { get; set; }
        public string Language { get; set; }
        public int Minutes { get; set; }
        public string Producer { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
    }
}
