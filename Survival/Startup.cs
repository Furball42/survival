using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Survival.Startup))]
namespace Survival
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
