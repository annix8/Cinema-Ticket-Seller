using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.DataModel.Models
{
    public class Projection
    {
        public int ProjectionID { get; set; }
        public Hall Hall { get; set; }
        public int HallID { get; set;}
        public Movie Movie { get; set; }
        public int MovieID { get; set; }

        public DateTime TimeOfProjection { get; set; }
    }
}
