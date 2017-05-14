using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(RemotePushService.Startup))]

namespace RemotePushService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}