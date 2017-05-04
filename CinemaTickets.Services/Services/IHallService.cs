using CinemaTickets.DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.Services.Services
{
    public interface IHallService
    {
        IQueryable<Hall> GetAllHalls();
        void AddHall(Hall hall);
        Hall GetHallById(int id);

    }
}
