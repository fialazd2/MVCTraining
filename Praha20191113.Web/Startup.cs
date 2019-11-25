using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Praha20191113.Web.Startup))]
namespace Praha20191113.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
