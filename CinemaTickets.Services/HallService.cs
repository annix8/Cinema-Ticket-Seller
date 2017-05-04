using CinemaTickets.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaTickets.DataModel.Models;
using CinemaTickets.DataModel;

namespace CinemaTickets.Services
{
    public class HallService : IHallService
    {
        private CinemaTicketsDbContext _context;
        public HallService()
        {
            this._context = new CinemaTicketsDbContext();
        }
        public void AddHall(Hall hall)
        {
            this._context.Halls.Add(hall);
            this._context.SaveChanges();
        }

        public IQueryable<Hall> GetAllHalls()
        {
            return this._context.Halls;
        }

        public Hall GetHallById(int id)
        {
            return this._context.Halls.FirstOrDefault(h => h.HallID == id);
        }
    }
}
