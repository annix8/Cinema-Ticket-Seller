using Microsoft.Owin;
using Microsoft.AspNet.Identity;
using Owin;
using System.Reflection;
using CinemaTickets.Services.Services;
using CinemaTickets.Services;

[assembly: OwinStartupAttribute(typeof(CinemaTickets.Web.Startup))]
namespace CinemaTickets.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
