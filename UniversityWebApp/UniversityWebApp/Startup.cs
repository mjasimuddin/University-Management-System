using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UniversityWebApp.Startup))]
namespace UniversityWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
