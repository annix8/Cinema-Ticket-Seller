using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.DataModel.Models
{
    public class Hall
    {
        public Hall()
        {
            this.Seats = new HashSet<Seat>();
        }
        public int HallID { get; set; }
        public int HallNumber { get; set; }
        public virtual ICollection<Seat> Seats { get; set; }
    }
}
