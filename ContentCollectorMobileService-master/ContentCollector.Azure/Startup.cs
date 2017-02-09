using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ContentCollector.Azure.Startup))]

namespace ContentCollector.Azure
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}