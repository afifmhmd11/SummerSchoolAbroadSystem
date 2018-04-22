using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PSM2.Startup))]
namespace PSM2
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
