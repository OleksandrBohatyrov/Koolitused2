using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Koolitused.Startup))]
namespace Koolitused
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            AutofacConfig.Configure();
            ConfigureAuth(app);
            
        }
    }
}
