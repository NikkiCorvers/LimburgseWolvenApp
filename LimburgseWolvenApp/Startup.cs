using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LimburgseWolvenApp.Startup))]
namespace LimburgseWolvenApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
