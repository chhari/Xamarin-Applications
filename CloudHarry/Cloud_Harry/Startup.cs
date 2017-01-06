using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Cloud_Harry.Startup))]

namespace Cloud_Harry
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}