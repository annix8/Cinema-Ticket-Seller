using CinemaTickets.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaTickets.DataModel.Models;
using CinemaTickets.DataModel;

namespace CinemaTickets.Services
{
    public class ProjectionService : IProjectionService
    {
        private CinemaTicketsDbContext _context;
        public ProjectionService(CinemaTicketsDbContext ctx)
        {
            this._context = ctx;
        }
        public void AddProjection(Projection projection)
        {
            this._context.Projections.Add(projection);
            this._context.SaveChanges();
        }

        public IQueryable<Projection> GetAllProjections()
        {
            return this._context.Projections;
        }

        public IQueryable<Projection> GetProjectionsByHall(int hallID)
        {
            return this._context.Projections.Where(proj => proj.HallID == hallID);
        }

        public Projection GetProjectionById(int id)
        {
            return this._context.Projections.FirstOrDefault(proj => proj.ProjectionID == id);
        }

        public IQueryable<Projection> GetProjectionsByMovie(int movieID)
        {
            return this._context.Projections.Where(proj => proj.MovieID == movieID);
        }
    }
}
