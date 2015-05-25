using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ADPortal.Startup))]
namespace ADPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
