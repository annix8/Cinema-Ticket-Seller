using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc3;
using CinemaTickets.Services;
using CinemaTickets.DataModel;
using CinemaTickets.Services.Contracts;
using CinemaTickets.Web.Controllers;
using CinemaTickets.Web.Models;

namespace CinemaTickets.Web
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());

            container.RegisterType<CinemaTicketsDbContext>(
                        new InjectionFactory(c => new CinemaTicketsDbContext()));

            container.RegisterType<IEmployeeService, EmployeeService>();
            container.RegisterType<IHallService, HallService>();
            container.RegisterType<IImageService, ImageService>();
            container.RegisterType<IMovieService, MovieService>();
            container.RegisterType<IProjectionService, ProjectionService>();

            return container;
        }
    }
}