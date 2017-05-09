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

        public void DeleteHall(int id)
        {
            var hallToDelete = this._context.Halls.FirstOrDefault(h => h.HallID == id);
            this._context.Halls.Remove(hallToDelete);
            this._context.SaveChanges();
        }

        public IQueryable<Hall> GetAllHalls()
        {
            return this._context.Halls;
        }

        public Hall GetHallByHallNumber(int hallNumber)
        {
            return this._context.Halls.FirstOrDefault(h => h.HallNumber == hallNumber);
        }

        public Hall GetHallById(int id)
        {
            return this._context.Halls.FirstOrDefault(h => h.HallID == id);
        }
    }
}
