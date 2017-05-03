using CinemaTickets.DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTickets.Services.Services
{
    public interface IProjectionService
    {
        IQueryable<Projection> GetAllProjections();
        Projection GetProjectionById(int id);
        void AddProjection(Projection projection);
        IQueryable<Projection> GetProjectionsByMovie(int movieID);
        IQueryable<Projection> GetProjectionsByHall(int hallID);
    }
}
