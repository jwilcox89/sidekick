using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(sidekick.testing.Startup))]
namespace sidekick.testing
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
