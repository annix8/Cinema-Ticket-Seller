using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.DataModel.Models
{
    public class Ticket
    {
        public int TicketID { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeID { get; set; }
        public Projection Projection { get; set; }
        public int ProjectionID { get; set; }
        public int SeatNumber { get; set; }
        public int RowNumber { get; set; }
    }
}
