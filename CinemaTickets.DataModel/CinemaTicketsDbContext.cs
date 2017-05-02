using CinemaTickets.DataModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.DataModel
{
    public class CinemaTicketsDbContext : DbContext
    {
        public CinemaTicketsDbContext() : base("Cinema")
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Projection> Projections { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
