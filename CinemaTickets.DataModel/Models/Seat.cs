using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.DataModel.Models
{
    public class Seat
    {
        public int SeatID { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public int HallID { get; set; }
        public int ProjectionID { get; set; }
    }
}
