using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CatalcaliWebAppV2.Startup))]
namespace CatalcaliWebAppV2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
