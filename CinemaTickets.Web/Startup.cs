using Microsoft.Owin;
using Owin;

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
